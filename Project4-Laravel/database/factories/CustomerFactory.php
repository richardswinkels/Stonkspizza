<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

class CustomerFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array
     */
    public function definition()
    {
        return [
            'first_name' => $this->faker->firstName(),
            'last_name' => $this->faker->lastName(),
            'address' => $this->faker->streetAddress(),
            'phone' => $this->faker->phoneNumber(),
            'zipcode' => $this->faker->postcode(),
            'city' => $this->faker->city(),
            'pizza_points' => 10,
        ];
    }
}
