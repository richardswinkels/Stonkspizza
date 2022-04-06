<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Size;


class SizesSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $sizes = [
            ['id' => 1, 'name' => 'Klein', 'pricefactor' => '0.80'],
            ['id' => 2, 'name' => 'Middel', 'pricefactor' => '1.00'],
            ['id' => 3, 'name' => 'Groot', 'pricefactor' => '1.20'],
        ];

        foreach ($sizes as $size) {
            Size::insert($size);
        }
    }
}
