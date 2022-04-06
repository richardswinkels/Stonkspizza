<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Orderitem extends Model
{
    use HasFactory;
    public $timestamps = false;

    public function size()
    {
        return $this->belongsTo(Size::class);
    }

    public function order()
    {
        return $this->belongsTo(Order::class);
    }

    public function pizza()
    {
        return $this->belongsTo(Pizza::class);
    }

    public function ingredients()
    {
        return $this->belongsToMany(Ingredient::class)->withPivot('quantity');;
    }

    public function price()
    {
        $price = 0;
        foreach ($this->ingredients as $ingredient)
        {
            $ingredientprice = $ingredient->price * $ingredient->pivot->quantity * $this->size->pricefactor;
            $price +=  $ingredientprice;
        }
        return $price;
    }
}
