<?php

namespace App\Http\Controllers\Cart;

use App\Http\Controllers\Controller;
use App\Http\Requests\StoreCartOrderitemRequest;
use App\Models\Orderitem;
use App\Models\Pizza;
use App\Models\Size;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Session;

class CartOrderitemController extends Controller
{
    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreCartOrderitemRequest $request)
    {
        $validated = $request->validated();

        $pizza = Pizza::findOrFail($request->input('pizza_id'));
        $size = Size::findOrFail($request->input('formaat_id'));

        foreach($pizza->ingredients as $ingredient)
        {
            if($ingredient['quantity'] == 0)
            {
                return redirect()->route('pizza.edit', $pizza)->with(['info' => "Het ingrediënt " . $ingredient['name'] . " is helaas niet meer op voorraad, verwijder deze om verder te gaan."]);
            }
        }
        if (count($pizza->ingredients) <= 1) {
            return redirect()->route('pizza.edit', $pizza)->with(['info' => 'Voeg minimaal 1 ander ingrediënt toe dan bodemdeeg!']);
        }
        //Als pizza van huidige user is of niet custom is
        else if($pizza->user_id == auth()->user()->id || $pizza->is_custom == false)
        {
            //Maak nieuwe orderitem
            $orderitem = new Orderitem;
            $orderitem->pizza()->associate($pizza);
            $orderitem->size()->associate($size);
            $orderitem->save();

            //Voeg alle ingrediënten toe aan orderitem
            foreach ($pizza->ingredients as $ingredient) {
                $selectedPizzaQuantity = $ingredient->pivot->quantity;
                $orderitem->ingredients()->attach($ingredient, ['quantity' => $selectedPizzaQuantity]);
            }

            Session::push('cart.orderitems', $orderitem);
            return redirect()->route('cart.index');
        }
        else
        {
            abort(403);
        }
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($orderitem_id)
    {
        $orderitems = Session::get('cart.orderitems');
        unset($orderitems[$orderitem_id]);
        Session::put('cart.orderitems', $orderitems);
        return redirect()->route('cart.index');
    }
}
