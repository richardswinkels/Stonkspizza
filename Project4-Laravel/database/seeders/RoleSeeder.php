<?php

namespace Database\Seeders;

use App\Models\Role;
use Illuminate\Database\Seeder;

class RoleSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $roles = [
            ['id' => 1, 'name' => 'klant'],
            ['id' => 999, 'name' => 'admin'],
            ['id' => 2, 'name' => 'balie'],
            ['id' => 3, 'name' => 'bereiding'],
            ['id' => 4, 'name' => 'bezorging'],
            ['id' => 5, 'name' => 'management'],
        ];

        foreach ($roles as $role) {
            Role::create($role);
        }
    }
}
