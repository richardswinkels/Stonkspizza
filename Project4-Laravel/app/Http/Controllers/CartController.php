<?php

namespace App\Http\Controllers;

use App\Models\Size;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Session;

class CartController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $pricetotal = 0.00;
        $orderitems = Session::get('cart.orderitems');
        //Bereken totaalprijs van alle winkelwagenitems
        if($orderitems != null) {
            foreach ($orderitems as $orderitem) {
                $pricetotal += $orderitem->price();
            }
        }

        return view('cart.index', compact('orderitems', 'pricetotal'));
    }
}
