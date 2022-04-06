<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Seeder;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        User::create([
            'id' => '2',
                'name' => 'peter',
                'email' => 'peter@pizzasumma.nl',
                'password' => bcrypt('password'),
            ]);
        User::create([
        'id' => '3',
            'name' => 'mohammed',
            'email' => 'mohammed@pizzasumma.nl',
            'password' => bcrypt('password'),
        ]);
        User::create([
        'id' => '4',
            'name' => 'ginny',
            'email' => 'ginny@pizzasumma.nl',
            'password' => bcrypt('password'),
        ]);
        User::create([
        'id' => '5',
            'name' => 'michelle',
            'email' => 'michelle@pizzasumma.nl',
            'password' => bcrypt('password'),
        ]);
        User::create([
            'id' => '6',
                'name' => 'Hamza Al-Hussein',
                'email' => 'hah@test.test',
                'password' => bcrypt('password'),
        ]);
        User::create([
            'id' => '7',
                'name' => 'Koen van der Velden',
                'email' => 'kvv@test.test',
                'password' => bcrypt('password'),
        ]);
        User::create([
            'id' => '8',
                'name' => 'Ilse Gijsbrechts',
                'email' => 'ig@test.test',
                'password' => bcrypt('password'),
        ]);
    }
}
