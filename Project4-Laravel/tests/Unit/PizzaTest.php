<?php

namespace Tests\Unit;

use App\Http\Controllers\PizzaController;
use App\Http\Requests\StorePizzaRequest;
use App\Models\User;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Illuminate\Session\Store;
use Tests\TestCase;

class PizzaTest extends TestCase
{
    /**
     * A basic unit test example.
     *
     * @return void
     */
    Use RefreshDatabase;
    public function testPizzaStore()
    {
        //Arange
        $this->seed();
        $user = User::factory()->create();

        //Act
        $response = $this->actingAs($user)->post(route('pizza.store'), [
            'pizzaID' => 1,
        ]);

        //Assert
        $this->assertDatabaseHas('pizzas', ['id' => 4]);
    }
}
