<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use function Psy\debug;

class Ingredient extends Model
{
    use HasFactory;
    public $timestamps = false;

    public function pizzas()
    {
        return $this->belongsToMany(Pizza::class)->withPivot('quantity');
    }

    public function orderitems()
    {
        return $this->belongsToMany(Orderitem::class)->withPivot('quantity');
    }

    public function unit()
    {
        return $this->belongsTo(Unit::class);
    }
}
