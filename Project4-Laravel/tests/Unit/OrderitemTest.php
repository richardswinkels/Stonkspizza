<?php

namespace Tests\Unit;

use App\Models\Order;
use App\Models\Orderitem;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Tests\TestCase;

class OrderitemTest extends TestCase
{
    use RefreshDatabase;
    public function testPriceWithIngredientSmallSize()
    {
        //Arrange
        $this->seed();

        $orderitem = new Orderitem();
        $orderitem->pizza()->associate(1);
        $orderitem->size()->associate(1);
        $orderitem->save();
        $orderitem->ingredients()->attach(1);

        //Act
        $price = $orderitem->price();

        //Assert
        $this->assertEquals(0.4, $price, "Prijsberekening mislukt");
    }

    public function testPriceWithIngredientMediumSize()
    {
        //Arrange
        $this->seed();

        $orderitem = new Orderitem();
        $orderitem->pizza()->associate(1);
        $orderitem->size()->associate(2);
        $orderitem->save();
        $orderitem->ingredients()->attach(1);

        //Act
        $price = $orderitem->price();

        //Assert
        $this->assertEquals(0.5, $price, "Prijsberekening mislukt");
    }

    public function testPriceWithIngredientLargeSize()
    {
        //Arrange
        $this->seed();

        $orderitem = new Orderitem();
        $orderitem->pizza()->associate(1);
        $orderitem->size()->associate(3);
        $orderitem->save();
        $orderitem->ingredients()->attach(1);

        //Act
        $price = $orderitem->price();

        //Assert
        $this->assertEquals(0.6, $price, "Prijsberekening mislukt");
    }

    public function testPriceWithMultipleIngredientsSmallSize()
    {
        //Arrange
        $this->seed();

        $orderitem = new Orderitem();
        $orderitem->pizza()->associate(1);
        $orderitem->size()->associate(1);
        $orderitem->save();
        $orderitem->ingredients()->attach(1);
        $orderitem->ingredients()->attach(2);
        $orderitem->ingredients()->attach(3);

        //Act
        $price = $orderitem->price();

        //Assert
        $this->assertEquals(2.6, $price, "Optelling mislukt");
    }

    public function testPriceWithMultipleIngredientsMediumSize()
    {
        //Arrange
        $this->seed();

        $orderitem = new Orderitem();
        $orderitem->pizza()->associate(1);
        $orderitem->size()->associate(2);
        $orderitem->save();
        $orderitem->ingredients()->attach(1);
        $orderitem->ingredients()->attach(2);
        $orderitem->ingredients()->attach(3);

        //Act
        $price = $orderitem->price();

        //Assert
        $this->assertEquals(3.25, $price, "Optelling mislukt");
    }

    public function testPriceWithMultipleIngredientsLargeSize()
    {
        //Arrange
        $this->seed();

        $orderitem = new Orderitem();
        $orderitem->pizza()->associate(1);
        $orderitem->size()->associate(3);
        $orderitem->save();
        $orderitem->ingredients()->attach(1);
        $orderitem->ingredients()->attach(2);
        $orderitem->ingredients()->attach(3);

        //Act
        $price = $orderitem->price();

        //Assert
        $this->assertEquals(3.9, $price, "Optelling mislukt");
    }

    public function testPriceWithoutIngredients()
    {
        //Arrange
        $this->seed();

        $orderitem = new Orderitem();
        $orderitem->pizza()->associate(1);
        $orderitem->size()->associate(2);
        $orderitem->save();

        //Act
        $price = $orderitem->price();

        //Assert
        $this->assertEquals(0, $price, "Prijsberekening mislukt");
    }
}
