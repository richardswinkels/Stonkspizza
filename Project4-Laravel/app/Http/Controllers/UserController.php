<?php

namespace App\Http\Controllers;

use App\Models\Role;
use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;

class UserController extends Controller
{
    // **********************************************************************
    // DUJO 21-12-2021
    // __construct added voor check of user = admin

    public function __construct()
    {
        $this->middleware(function ($request, $next) {
            if(Auth::user()->hasRole('admin')){
                // $this->roles = Auth::user()->roles;
                return $next($request);
            }else{
                return redirect(route('dashboard'));
            }
        });
    }

    // **********************************************************************

    public function index(){
        return view('users.index', ['users' => User::all()]);
    }

    public function create(){
        // **********************************************************************
        // DUJO 23-12-2021
        // Voeg roles toe aan view
        $roles = Role::all();
        return view('users.create', ['roles' => $roles]);
        // **********************************************************************
    }

    public function store(Request $request){
        $user = new User();
        $user->password = Hash::make($request->password);
        $user->email = $request->email;
        $user->name = $request->name;
        $user->save();
        return redirect()->route('user.index');
    }

    public function edit(User $user){
        return view('users.edit', ['user' => User::find($user->id)]);
    }

    public function update(Request $request, User $user){
        $user->update($request->all());
        return redirect()->route('user.index');
    }

    public function destroy($id){
        $user = User::find($id);
        $user->delete();
        return redirect()->route('user.index');
    }
    public function show()
    {
        return abort(403);
    }
    
}
