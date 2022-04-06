<?php

namespace App\Models;

use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Notifications\Notifiable;
use Illuminate\Support\Facades\Auth;
use Laravel\Sanctum\HasApiTokens;

class User extends Authenticatable
{
    use HasApiTokens, HasFactory, Notifiable;

    /**
     * The attributes that are mass assignable.
     *
     * @var array<int, string>
     */
    protected $fillable = [
        'name',
        'email',
        'password',
    ];

    /**
     * The attributes that should be hidden for serialization.
     *
     * @var array<int, string>
     */
    protected $hidden = [
        'password',
        'remember_token',
    ];

    /**
     * The attributes that should be cast.
     *
     * @var array<string, string>
     */
    protected $casts = [
        'email_verified_at' => 'datetime',
    ];

    // ************************************************************************
    // DUJO
    // 17-12-2021
    // added this to get the user's role (from the pivot table)
    public function roles()
    {
        // tweede parameter geeft de tussentabel (naam)
        return $this->belongsToMany(Role::class, 'user_roles', 'user_id', 'role_id');
    }
    // ************************************************************************
    // ************************************************************************
    // DUJO
    // 17-12-2021
    // check of de user een rol heeft
    public function hasRole(String $role)
    {
        $user = Auth::user();
        // dd($user);
        if(auth()->user()){
            $userId = auth()->user()->id;
            $roleId = Role::where('name', $role)->first()->id;
            $userRole = UserRole::where('role_id', $roleId)
                                ->where('user_id', $userId)
                                ->get();
            return $userRole->count() > 0;
        }
    }
    // ************************************************************************

    public function pizzas()
    {
        return $this->hasMany(Pizza::class);
    }
}
