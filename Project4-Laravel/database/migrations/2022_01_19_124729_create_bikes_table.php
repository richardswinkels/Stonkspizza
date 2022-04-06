<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateBikesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('bikes', function (Blueprint $table) {
            $table->id();
            $table->foreignId('brand_id')->nullable(false)->references('id')->on('bikebrands')->cascadeOnDelete();
            $table->foreignId('model_id')->nullable(false)->references('id')->on('bikemodels')->cascadeOnDelete();
            $table->foreignId('employee_id')->nullable(false)->references('id')->on('employees')->cascadeOnDelete();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('bikes');
    }
}
