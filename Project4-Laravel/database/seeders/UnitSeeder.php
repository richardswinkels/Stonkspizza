<?php

namespace Database\Seeders;

use App\Models\Unit;
use Illuminate\Database\Seeder;
use App\Models\Ingredient;

class UnitSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        Unit::insert([
            'id' => '1',
            'name' => '100gr',
        ]);

        Unit::insert([
            'id' => '2',
            'name' => '1 stuk',
        ]);

        Unit::insert([
            'id' => '3',
            'name' => '100ml',
        ]);
    }
}
