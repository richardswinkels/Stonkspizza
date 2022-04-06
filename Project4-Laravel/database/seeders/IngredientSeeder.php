<?php

namespace Database\Seeders;

use App\Models\Ingredient;
use Illuminate\Database\Seeder;

class IngredientSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $ingredients = [
            ['id' => 1, 'name' => 'Bodemdeeg', 'price' => '0.50', 'quantity' => 100, 'unit_id' => '1'],
            ['id' => 2, 'name' => 'Mozerella', 'price' => '2.50', 'quantity' => 100, 'unit_id' => '1'],
            ['id' => 3, 'name' => 'Saus', 'price' => '0.25', 'quantity' => 100, 'unit_id' => '3'],
            ['id' => 4, 'name' => 'Ui', 'price' => '0.50', 'quantity' => 100, 'unit_id' => '2'],
            ['id' => 5, 'name' => 'Tomaat', 'price' => '0.80', 'quantity' => 100, 'unit_id' => '2'],
            ['id' => 6, 'name' => 'Kaas', 'price' => '0.40', 'quantity' => 100, 'unit_id' => '1'],
            ['id' => 7, 'name' => 'Ananas', 'price' => '0.90', 'quantity' => 100, 'unit_id' => '1'],
            ['id' => 8, 'name' => 'Ham', 'price' => '1.20', 'quantity' => 100, 'unit_id' => '1'],
        ];

        foreach ($ingredients as $ingredient) {
            Ingredient::create($ingredient);
        }
    }
}
