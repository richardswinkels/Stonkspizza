<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Support\Facades\Auth;

class StoreEmployeeRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return $this->user()->hasRole('admin');
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array
     */
    public function rules()
    {
        return [
            'name' => 'required|string|max:25',
            'password' => 'required|string',
            'email' => 'required|string|email|max:255|unique:users',
            'first_name' => 'string|max:255',
            'last_name' => 'string|max:255',
            'phone' => 'string|max:255',
            'birth_date' => 'date',
            'burger_service_nummer' => 'string|max:255',
            'address' => 'string|max:255',
            'zipcode' => 'string|max:255',
            'city' => 'string|max:255',
        ];
    }
}
