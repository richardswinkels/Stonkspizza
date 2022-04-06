<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Role extends Model
{
    use HasFactory;
    protected $fillable = [
        'id',
        'name',
    ];

    // ************************************************************************
    // DUJO
    // 17-12-2021
    // added this to get the role's users (from the pivot table)
    public function users()
    {
        return $this->belongsTo(User::class, 'user_roles', 'role_id', 'user_id');
    }
    // ************************************************************************
}
