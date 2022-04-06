<?php

namespace Database\Seeders;

use App\Models\UserRole;
use Illuminate\Database\Seeder;

class UserRoleSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $userRoles = [
            ['user_id' => 1, 'role_id' => 999],
            ['user_id' => 2, 'role_id' => 2],
            ['user_id' => 3, 'role_id' => 3],
            ['user_id' => 4, 'role_id' => 4],
            ['user_id' => 5, 'role_id' => 5],
            ['user_id' => 6, 'role_id' => 1],
            ['user_id' => 7, 'role_id' => 1],
            ['user_id' => 8, 'role_id' => 1],
        ];

        foreach ($userRoles as $userRole) {
            UserRole::insert($userRole);
        }
    }
}
