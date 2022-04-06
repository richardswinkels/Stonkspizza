<?php

namespace App\Http\Controllers\Pizza;

use App\Http\Controllers\Controller;
use App\Http\Requests\StorePizzaIngredientRequest;
use App\Http\Requests\StorePizzaRequest;
use App\Models\Ingredient;
use App\Models\Pizza;
use Illuminate\Http\Request;

class PizzaIngredientController extends Controller
{
    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StorePizzaIngredientRequest $request, $pizza_id)
    {
        $validated = $request->validated();

        $pizza = Pizza::findOrFail($pizza_id);
        $ingredientID = $request->input("ingredientID");
        $ingredient = Ingredient::findOrFail($ingredientID);

        if (!$pizza->ingredients->contains($ingredient)) {
            $pizza->ingredients()->attach($ingredient);
        }

        return redirect()->route('pizza.edit', $pizza_id);
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($pizza_id, $ingredient_id)
    {
        $pizza = Pizza::findOrFail($pizza_id);
        $ingredient = Ingredient::findOrFail($ingredient_id);

        $pizza->ingredients()->detach($ingredient);

        return redirect()->route('pizza.edit', $pizza_id);
    }
}
