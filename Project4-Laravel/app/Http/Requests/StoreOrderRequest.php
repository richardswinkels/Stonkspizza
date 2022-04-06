<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreOrderRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array
     */
    public function rules()
    {
        return [
            'day' => 'required|date_format:d-m-Y',
            'time' => 'required|date_format:H:i',
            'firstname' => 'required',
            'lastname' => 'required',
            'address' => 'required',
            'phone' => 'required',
            'zipcode' => 'required',
            'email' => 'required|email',
        ];
    }

    /**
     * Get the error messages for the defined validation rules.
     *
     * @return array
     */
    public function messages()
    {
        return [
            'day.required' => 'Datum ontbreekt',
            'day.date_format' => 'Datum heeft onjuiste indeling',
            'time.required' => 'Tijdstip ontbreekt',
            'time.date_format' => 'Tijdstip heeft onjuiste indeling',
            'firstname.required' => 'Voornaam ontbreekt',
            'lastname.required' => 'Achternaam ontbreekt',
            'address.required' => 'Adres ontbreekt',
            'phone.required' => 'Telefoonnummer ontbreekt',
            'zipcode.required' => 'Postcode ontbreekt',
            'email.required' => 'E-mailadres ontbreekt',
            'email.email' => 'E-mailadres heeft onjuiste indeling',
        ];
    }
}
