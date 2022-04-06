<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreCartOrderitemRequest extends FormRequest
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
            'pizza_id' => 'required|integer',
            'formaat_id' => 'required|integer',
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
            'pizza_id.required' => 'Pizza id ontbreekt',
            'formaat_id.required' => 'Formaat id ontbreekt',
            'pizza_id.integer' => 'Pizza id moet geheel getal zijn',
            'formaat_id.integer' => 'Formaat id moet geheel getal zijn',
        ];
    }
}
