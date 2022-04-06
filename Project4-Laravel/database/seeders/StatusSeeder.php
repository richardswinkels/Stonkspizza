<?php

namespace Database\Seeders;

use App\Models\Status;
use Illuminate\Database\Seeder;

class StatusSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        Status::insert([
            'id' => '1',
            'name' => 'Besteld',
        ]);

        Status::insert([
            'id' => '2',
            'name' => 'Wordt bereid',
        ]);

        Status::insert([
            'id' => '3',
            'name' => 'In de oven',
        ]);

        Status::insert([
            'id' => '4',
            'name' => 'Onderweg',
        ]);

        Status::insert([
            'id' => '5',
            'name' => 'Bezorgd',
        ]);

        Status::insert([
            'id' => '6',
            'name' => 'Geannuleerd',
        ]);
    }
}
