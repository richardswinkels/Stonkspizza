<?php

namespace Database\Factories;

use Carbon\Carbon;
use Illuminate\Database\Eloquent\Factories\Factory;

class OrderFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array
     */
    public function definition()
    {
        return [
            'deliverytime' => Carbon::now()->addMinute(45),
            'updated_at' => Carbon::Now(),
            'created_at' => Carbon::Now(),
        ];
    }
}
