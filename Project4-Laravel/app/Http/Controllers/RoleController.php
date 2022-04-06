<?php

namespace App\Http\Controllers;

use App\Models\Role;
use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class RoleController extends Controller
{
    // **********************************************************************
    // DUJO 21-12-2021
    // __construct added voor check of user = admin

    protected $roles;
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
        // $user = auth()->user();
        // dd($user->roles->toArray());
        // dd($user->roles[0]->name);
        // dd($user->name);
        return view('roles.index', ['roles' => Role::all()]);
    }

    public function create(){
        return view('roles.create');
    }

    public function store(Request $request){
        Role::create($request->all());
        return redirect()->route('role.index');
    }

    public function edit(Role $role){
        return view('roles.edit', ['role' => Role::find($role->id)]);
    }

    public function update(Request $request, Role $role){
        $role->update($request->all());
        return redirect()->route('role.index');
    }

    public function destroy($id){
        $role = Role::find($id);
        $role->delete();
        return redirect()->route('role.index');
    }
    public function show()
    {
        return abort(403);
    }
}
