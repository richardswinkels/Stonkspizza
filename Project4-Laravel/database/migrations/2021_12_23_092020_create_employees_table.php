<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateEmployeesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('employees', function (Blueprint $table) {
            $table->id();
            $table->string('first_name')->nullable();
            $table->string('last_name');
            $table->string('address')->nullable();
            $table->string('phone')->nullable();
            $table->string('zipcode')->nullable();
            $table->string('city')->nullable();
            $table->string('country')->nullable();
            // employee email is created in the user table
            $table->string('personal_email')->nullable();
            $table->date('birth_date')->nullable();
            $table->string('burger_service_nummer')->nullable();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('employees');
    }
}
