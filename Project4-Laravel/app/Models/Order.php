<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Order extends Model
{
    use HasFactory;
    public $timestamps = true;
    protected $guarded = ['id'];

    public function orderitems()
    {
        return $this->hasMany(Orderitem::class);
    }

    public function status()
    {
        return $this->belongsTo(Status::class);
    }

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }

    public function price()
    {
        $price = 0.00;
        //Bereken totaalprijs van alle winkelwagenitems
        if($this->orderitems != null) {
            foreach ($this->orderitems as $orderitem) {
                $price += $orderitem->price();
            }
        }

        return $price;
    }
}


