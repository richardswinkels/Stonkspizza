<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Cart\CartOrderitemController;
use App\Http\Requests\StoreOrderRequest;
use App\Models\Customer;
use App\Models\Order;
use App\Models\User;
use Carbon\Carbon;
use Carbon\CarbonPeriod;
use Cassandra\Custom;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Session;
use Illuminate\Support\Arr;

class OrderController extends Controller
{
    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        $customer = Customer::findOrFail(auth()->user()->id);
        $user = auth()->user();

        $startday = Carbon::now()->toDateString();
        $endday = Carbon::now()->addWeek(2)->toDateString();
        $perioddays = CarbonPeriod::create($startday, '1 day', $endday);
        $deliverydays = [];

        $starttime = Carbon::now()->setTime(12 ,0,0,0);
        $endtime = Carbon::now()->setTime(23 ,59,59,59);
        $periodtime = CarbonPeriod::create($starttime, '15 minutes', $endtime);
        $deliverytimes = [];

        foreach ($periodtime as $dt)
        {
            array_push($deliverytimes, $dt);
        }

        foreach ($perioddays as $dt)
        {
            array_push($deliverydays, $dt);
        }

        $pricetotal = 0.00;
        $orderitems = Session::get('cart.orderitems');
        if($orderitems != null) {
            foreach ($orderitems as $orderitem) {
                $pricetotal += $orderitem->price();
            }
        }
        return view('order.create', compact('orderitems', 'pricetotal', 'deliverytimes', 'deliverydays', 'customer', 'user'));
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreOrderRequest $request)
    {
        $validated = $request->validated();

       $orderitems = Session::get('cart.orderitems');
       //Als er orderitems aan winkelmandje zijn toegevoegd
       if($orderitems != null) {
           $day = $request->input('day');
           $time = $request->input('time');
           $datetime = Carbon::parse($day . $time);

           $customer = Customer::findOrFail(auth()->user()->id);
           $customer->first_name = $request->input('firstname');
           $customer->last_name = $request->input('lastname');
           $customer->address = $request->input('address');
           $customer->phone = $request->input('phone');
           $customer->zipcode = $request->input('zipcode');
           $customer->increment('pizza_points', 10);
           $customer->save();

           $user = User::findOrFail(auth()->user()->id);
           $user->email = $request->input('email');
           $user->save();

           $order = new Order();
           $order->deliverytime = $datetime;
           $order->customer_id = $customer->id;
           $order->save();

           foreach ($orderitems as $orderitem_id => $orderitem) {
               $orderitem->order()->associate($order->id);
               $orderitem->save();
           }
           Session::forget('cart.orderitems');
           return redirect()->route('order.show', $order->id);
       }
       else {
           return abort(403);
       }
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        $order = Order::findOrFail($id);
        if($order->customer_id == auth()->user()->id)
        {
            return view('order.show', compact('order'));
        }
        else {
            abort(403);
        }
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        $order = Order::findOrFail($id);
        $customer = Customer::findOrFail(auth()->user()->id);

        //Als order bij huidige user hoort en order niet onderweg, afgeleverd of al geannuleerd is
        if($order->customer_id == $customer->id && $order->status->id != 4 && $order->status->id != 5 && $order->status->id != 6)
        {
            //Update status naar geannuleerd
            $order->status()->associate(6);
            $order->save();

            //Verlaag pizzapunten
            if($customer->pizza_points != 0) {
                $customer->decrement('pizza_points', 10);
                $customer->save();
            }

            return redirect()->back();
        }
        else
        {
            return abort(403);
        }
    }

    public function edit()
    {
        return abort(403);
    }
}
