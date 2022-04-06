<?php

namespace App\Http\Controllers;

use App\Models\Employee;
use App\Http\Requests\StoreEmployeeRequest;
use App\Http\Requests\UpdateEmployeeRequest;
use App\Models\Role;
use App\Models\User;
use App\Models\UserRole;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Hash;

class EmployeeController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
        // **********************************************************************
    // DUJO 23-12-2021
    // __construct added voor check of user = admin
    public function __construct()
    {
        $this->middleware(function ($request, $next) {
            if(Auth::user()->hasRole('admin')){
                return $next($request);
            }else{
                return redirect(route('dashboard'));
            }
        });
    }
    // **********************************************************************
    public function index()
    {
        return view('employees.index', ['employees' => Employee::all()]);
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        $roles = Role::all()->except(1);
        return view('employees.create', ['roles' => $roles]);
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \App\Http\Requests\StoreEmployeeRequest  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreEmployeeRequest $request)
    {
        // user info van medewerker
        $user = new User();
        $user->password = Hash::make($request->password);
        $user->email = $request->email;
        $user->name = $request->name;
        $user->save();

        // employee info van medewerker
        $employee = new Employee();
        $employee->id = $user->id;
        $employee->first_name = $request->first_name;
        $employee->last_name = $request->last_name;
        $employee->phone = $request->phone;
        $employee->personal_email = $request->personal_email;
        $employee->birth_date = $request->birth_date;
        $employee->burger_service_nummer = $request->burger_service_nummer;
        $employee->address = $request->address;
        $employee->zipcode = $request->zipcode;
        $employee->city = $request->city;
        $employee->save();

        // role info van medewerker
        // dd($request->roles);
        foreach ($request->roles as $role_id) {
            $role = new UserRole();
            $role->user_id = $user->id;
            $role->role_id = $role_id;
            $role->save();
        }

        return redirect()->route('employee.index');
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\Employee  $employee
     * @return \Illuminate\Http\Response
     */
    public function show(Employee $employee)
    {
        return abort(403);
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  \App\Models\Employee  $employee
     * @return \Illuminate\Http\Response
     */
    public function edit(Employee $employee)
    {
        // DUJO 24-12-2021
        // Niet alleen de medewerkers info maar ook de user info meegeven
        return view('employees.edit', [
            'employee' => Employee::find($employee->id),
            'user' => User::find($employee->id),
            'roles' => Role::all()
        ]);
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \App\Http\Requests\UpdateEmployeeRequest  $request
     * @param  \App\Models\Employee  $employee
     * @return \Illuminate\Http\Response
     */
    public function update(UpdateEmployeeRequest $request, Employee $employee)
    {
        // user info van medewerker
        $user = User::find($employee->id);
        $user->password = Hash::make($request->password);
        $user->email = $request->email;
        $user->name = $request->name;
        $user->update();

        // employee info van medewerker
        $employee = Employee::find($employee->id);
        $employee->first_name = $request->first_name;
        $employee->last_name = $request->last_name;
        $employee->phone = $request->phone;
        $employee->personal_email = $request->personal_email;
        $employee->birth_date = $request->birth_date;
        $employee->burger_service_nummer = $request->burger_service_nummer;
        $employee->address = $request->address;
        $employee->zipcode = $request->zipcode;
        $employee->city = $request->city;
        $employee->update();

        // role info van medewerker
        // dd($request->roles);
        // foreach ($request->roles as $role_id) {
        //     $role = new UserRole();
        //     $role->user_id = $user->id;
        //     $role->role_id = $role_id;
        //     $role->save();
        // }

        return redirect()->route('employee.index');
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Employee  $employee
     * @return \Illuminate\Http\Response
     */
    public function destroy(Employee $employee)
    {
        // ************************************
        // DUJO 24-12-2021
        // Verwijder de user behorende bij de medewerker en de rollen in de UserRole tabel
        // ************************************

        // de user
        $user = User::find($employee->id);
        $user->delete();

        // de medewerker
        $employee->delete();

        // de rollen
        foreach (UserRole::where('user_id', $employee->id)->get() as $userRole) {
            $userRole->delete();
        }

        return redirect()->route('employee.index');
    }
}
