<?php

namespace Database\Seeders;

use App\Models\Employee;
use Illuminate\Database\Seeder;
use Carbon\Carbon;

class EmployeeSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        Employee::create([
            'id' => '1',
            'first_name' => 'samira',
            'last_name' => 'achternaam',
            'address' => 'straatnaam 1',
            'phone' => '06123456789',
            'zipcode' => '1111AB',
            'city' => 'Eindhoven',
            'personal_email' => 'user@domein.nl',
            'birth_date' => '2022-01-01',
            'burger_service_nummer' => '11111111111',
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
        ]);

        Employee::create([
            'id' => '2',
            'first_name' => 'peter',
            'last_name' => 'achternaam',
            'address' => 'straatnaam 1',
            'phone' => '06123456789',
            'zipcode' => '1111AB',
            'city' => 'Eindhoven',
            'personal_email' => 'user@domein.nl',
            'birth_date' => '2022-01-01',
            'burger_service_nummer' => '11111111111',
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
        ]);

        Employee::create([
            'id' => '3',
            'first_name' => 'mohammed',
            'last_name' => 'achternaam',
            'address' => 'straatnaam 1',
            'phone' => '06123456789',
            'zipcode' => '1111AB',
            'city' => 'Eindhoven',
            'personal_email' => 'user@domein.nl',
            'birth_date' => '2022-01-01',
            'burger_service_nummer' => '11111111111',
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
        ]);

        Employee::create([
            'id' => '4',
            'first_name' => 'ginny',
            'last_name' => 'achternaam',
            'address' => 'straatnaam 1',
            'phone' => '06123456789',
            'zipcode' => '1111AB',
            'city' => 'Eindhoven',
            'personal_email' => 'user@domein.nl',
            'birth_date' => '2022-01-01',
            'burger_service_nummer' => '11111111111',
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
        ]);

        Employee::create([
            'id' => '5',
            'first_name' => 'michelle',
            'last_name' => 'achternaam',
            'address' => 'straatnaam 1',
            'phone' => '06123456789',
            'zipcode' => '1111AB',
            'city' => 'Eindhoven',
            'personal_email' => 'user@domein.nl',
            'birth_date' => '2022-01-01',
            'burger_service_nummer' => '11111111111',
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
        ]);

        Employee::create([
            'id' => '6',
            'first_name' => 'Hamza',
            'last_name' => 'Al-Hussein',
            'address' => 'straatnaam 1',
            'phone' => '06123456789',
            'zipcode' => '1111AB',
            'city' => 'Eindhoven',
            'personal_email' => 'user@domein.nl',
            'birth_date' => '2022-01-01',
            'burger_service_nummer' => '11111111111',
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
        ]);

        Employee::create([
            'id' => '7',
            'first_name' => 'Koen',
            'last_name' => 'van der Velden',
            'address' => 'straatnaam 1',
            'phone' => '06123456789',
            'zipcode' => '1111AB',
            'city' => 'Eindhoven',
            'personal_email' => 'user@domein.nl',
            'birth_date' => '2022-01-01',
            'burger_service_nummer' => '11111111111',
            'created_at' => Carbon::now(),
            'updated_at' => Carbon::now(),
        ]);
    }
}
