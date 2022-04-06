<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\IngredientPizza;


class IngredientPizzaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $pizzaIngredients = [
            ['pizza_id' => 1, 'ingredient_id' => 1, 'quantity' => 1],
            ['pizza_id' => 1, 'ingredient_id' => 2, 'quantity' => 1],
            ['pizza_id' => 1, 'ingredient_id' => 3, 'quantity' => 1],
            ['pizza_id' => 1, 'ingredient_id' => 4, 'quantity' => 1],
            ['pizza_id' => 2, 'ingredient_id' => 1, 'quantity' => 1],
            ['pizza_id' => 2, 'ingredient_id' => 3, 'quantity' => 1],
            ['pizza_id' => 2, 'ingredient_id' => 6, 'quantity' => 1],
            ['pizza_id' => 2, 'ingredient_id' => 7, 'quantity' => 1],
            ['pizza_id' => 2, 'ingredient_id' => 8, 'quantity' => 1],
            ['pizza_id' => 3, 'ingredient_id' => 1, 'quantity' => 1],
            ['pizza_id' => 3, 'ingredient_id' => 4, 'quantity' => 1],
            ['pizza_id' => 3, 'ingredient_id' => 5, 'quantity' => 1],
            ['pizza_id' => 3, 'ingredient_id' => 8, 'quantity' => 1],

        ];
        foreach ($pizzaIngredients as $pizzaIngredient) {
            IngredientPizza::insert($pizzaIngredient);
        }
    }
}
