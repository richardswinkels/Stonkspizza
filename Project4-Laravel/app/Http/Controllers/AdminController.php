<?php

namespace App\Http\Controllers;

use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class AdminController extends Controller
{
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

    public function index(){
        return view('admin.index');
    }

    // public function dashboard(){
    //     return view('dashboard');
    // }

    // public function role(){
    //     return view('role.index', ['roles' => Role::all()]);
    // }

    // public function user(){
    //     return view('user.index', ['users' => User::all()]);
    // }

    // public function employee(){
    //     return view('employee.index', ['employees' => Employee::all()]);
    // }

    // public function customer(){
    //     return view('customer.index', ['customers' => Customer::all()]);
    // }

    public function resetpassword($id){
        $user = User::find($id);
        return view('admin.reset-password', ['user' => $user]);
    }

    public function updatepassword(Request $request, $id){
        User::find($id)->update([
            'password' => bcrypt($request->password)
        ]);
        return redirect()->route('admin.index');
    }
}
