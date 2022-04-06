<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     *
     * @return void
     */
    public function run()
    {
        $this->call([
            AdminUserSeeder::class,
            UserSeeder::class,
            EmployeeSeeder::class,
            RoleSeeder::class,
            UserRoleSeeder::class,
            UnitSeeder::class,
            IngredientSeeder::class,
            PizzaSeeder::class,
            SizesSeeder::class,
            StatusSeeder::class,
            IngredientPizzaSeeder::class
        ]);
        // \App\Models\User::factory(10)->create();
    }
}
