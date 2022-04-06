@extends('layouts.main')
@section('title')
    {{ __('Maak een medewerker:') }}
@endsection

@section('content')
    <x-auth-card-app>
        <x-slot name="logo">
            <a href="/">
                <x-application-logo class="w-20 h-20 fill-current text-gray-500" />
            </a>
        </x-slot>
        <!-- Session Status -->
        <x-auth-session-status class="mb-4" :status="session('status')" />
        <!-- Validation Errors -->
        <x-auth-validation-errors class="mb-4" :errors="$errors" />

        <form method="POST" action="{{ route('employee.store') }}">
            @csrf
            <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-5">
                <div>
                    <!-- Name -->
                    <div>
                        <x-label for="name" :value="__('Gebruikersnaam *')" />

                        <x-input id="name" class="block mt-1 w-full" type="text" name="name" :value="old('name')" required autofocus />
                    </div>

                    <!-- Email Address -->
                    <div class="mt-4">
                        <x-label for="email" :value="__('Email *')" />

                        <x-input id="email" class="block mt-1 w-full" type="email" name="email" :value="old('email')" required />
                    </div>

                    <!-- Password -->
                    <div class="mt-4">
                        <x-label for="password" :value="__('Wachtwoord *')" />

                        <x-input id="password" class="block mt-1 w-full"
                                        type="password"
                                        name="password"
                                        required autocomplete="new-password" />
                    </div>
                </div>

                <div>
                    <!-- FirstName -->
                    <div>
                        <x-label for="first_name" :value="__('Voornaam')" />

                        <x-input id="first_name" class="block mt-1 w-full" type="text" name="first_name" :value="old('first_name')" required autofocus />
                    </div>

                    <!-- lastName -->
                    <div class="mt-4">
                        <x-label for="last_name" :value="__('Achternaam')" />

                        <x-input id="last_name" class="block mt-1 w-full" type="text" name="last_name" :value="old('last_name')" required autofocus />
                    </div>

                    <!-- phone -->
                    <div class="mt-4">
                        <x-label for="phone" :value="__('Telefoonnr')" />

                        <x-input id="phone" class="block mt-1 w-full" type="text" name="phone" :value="old('phone')" required autofocus />
                    </div>
                </div>

                <div>
                    <div class=">
                        <x-label for="personal_email" :value="__('Persoonlijke email')" />

                        <x-input id="personal_email" class="block mt-1 w-full" type="text" name="personal_email" :value="old('personal_email')" required autofocus />
                    </div>

                    <div class="mt-4">
                        <x-label for="burger_service_nummer" :value="__('Burger Service Nummer')" />

                        <x-input id="burger_service_nummer" class="block mt-1 w-full" type="text" name="burger_service_nummer" :value="old('burger_service_nummer')" required autofocus />
                    </div>

                    <div class="mt-4">
                        <x-label for="birth_date" :value="__('Geboortedatum')" />

                        <x-input id="birth_date" class="block mt-1 w-full" type="date" name="birth_date" :value="old('birth_date')" required autofocus />
                    </div>
                </div>

                <div>
                    <!-- addres -->
                    <div class="">
                        <x-label for="address" :value="__('Adres (straat en huisnr) *')" />

                        <x-input id="address" class="block mt-1 w-full" type="text" name="address" :value="old('address')" required autofocus />
                    </div>

                    <!-- zipcode -->
                    <div class="mt-4">
                        <x-label for="zipcode" :value="__('Postcode *')" />

                        <x-input id="zipcode" class="block mt-1 w-full" type="text" name="zipcode" :value="old('zipcode')" required autofocus />
                    </div>

                    <!-- city -->
                    <div class="mt-4">
                        <x-label for="city" :value="__('Woonplaats')" />

                        <x-input id="city" class="block mt-1 w-full" type="text" name="city" :value="old('city')" required autofocus />
                    </div>
                </div>
            </div>
            <div class="mt-2">
                <select class="form-control" name="roles[]" multiple="">
                    @foreach($roles as $role)
                        <option value="{{ $role->id }}">{{ $role->name }}</option>
                    @endforeach
                </select>
            </div>
            <div class="flex items-center justify-end mt-4">
                <x-button class="ml-3">
                    {{ __('Bewaar') }}
                </x-button>
            </div>
        </form>
    </x-auth-card-app>
@endsection
