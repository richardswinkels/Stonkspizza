<?php

namespace App\Http\Controllers\Auth;

use App\Http\Controllers\Controller;
use App\Models\Customer;
use App\Models\User;
use App\Models\UserRole;
use App\Providers\RouteServiceProvider;
use Illuminate\Auth\Events\Registered;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;
use Illuminate\Validation\Rules;

class RegisteredUserController extends Controller
{
    /**
     * Display the registration view.
     *
     * @return \Illuminate\View\View
     */
    public function create()
    {
        return view('auth.register');
    }

    /**
     * Handle an incoming registration request.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\RedirectResponse
     *
     * @throws \Illuminate\Validation\ValidationException
     */
    public function store(Request $request)
    {
        // **********************************************************************
        // DUJO
        // 23-12-2021
        // validation uitgebreid met de customer info
        $request->validate([
            'name' => ['required', 'string', 'max:255'],
            'email' => ['required', 'string', 'email', 'max:255', 'unique:users'],
            'password' => ['required', 'confirmed', Rules\Password::defaults()],
            'first_name' => ['string', 'max:255'],
            'last_name' => ['string', 'max:255'],
            'phone' => ['string', 'max:255'],
            'address' => ['required', 'string', 'max:255'],
            'zipcode' => ['required', 'string', 'max:255'],
            'city' => ['string', 'max:255'],
        ]);
        // **********************************************************************

        $user = User::create([
            'name' => $request->name,
            'email' => $request->email,
            'password' => Hash::make($request->password),
        ]);


        event(new Registered($user));

        // **********************************************************************
        // DUJO
        // 17-12-2021
        // $user->id gebruiken om role klant (id=0) toe te voegen in user_role table
        UserRole::create([
            'user_id' => $user->id,
            'role_id' => 1,
        ]);
        // **********************************************************************

        // **********************************************************************
        // DUJO
        // 23-12-2021
        // $user->id gebruiken om klant aan te maken (one to one relation)
        Customer::create([
            'id' => $user->id,
            'first_name' => $request->first_name,
            'last_name' => $request->last_name,
            'phone' => $request->phone,
            'address' => $request->address,
            'zipcode' => $request->zipcode,
            'city' => $request->city,
            // Bij aanmaken klant krijgt hij/zij 10 pizza_points
            'pizza_points' => 10,
        ]);
        // **********************************************************************

        Auth::login($user);

        return redirect(RouteServiceProvider::HOME);
    }
}
