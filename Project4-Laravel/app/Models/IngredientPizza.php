<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class IngredientPizza extends Model
{
    use HasFactory;
    protected $fillable = [
        'pizza_id',
        'ingredient_id',
        'quantity'
    ];
    protected $table = "ingredient_pizza";
}
