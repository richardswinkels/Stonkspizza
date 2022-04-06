@extends('layouts.main')
@section('title')
    {{ __('Wijzig een klant:') }}
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

        <form method="POST" action="{{ route('employee.update', [$employee]) }}">
            @csrf
            @method('put')
            <div class="grid grid-cols-1 md:grid-cols-3 gap-5">
                <div>
                    <div>
                        <x-label for="first_name" :value="__('Voornaam')" />
                        <x-input id="first_name" class="block mt-1 w-full" type="text" name="first_name" value="{{ $employee->first_name }}" required autofocus />
                    </div>

                    <div>
                        <x-label for="last_name" :value="__('Achternaam')" />
                        <x-input id="last_name" class="block mt-1 w-full" type="text" name="last_name" value="{{ $employee->last_name }}" required autofocus />
                    </div>

                    <div>
                        <x-label for="birth_date" :value="__('Geboortedatum')" />
                        <x-input id="birth_date" class="block mt-1 w-full" type="date" name="birth_date" value="{{ $employee->birth_date }}" required autofocus />
                    </div>

                    <div>
                        <x-label for="burger_service_nummer" :value="__('BurgerServiceNummer')" />
                        <x-input id="burger_service_nummer" class="block mt-1 w-full" type="text" name="burger_service_nummer" value="{{ $employee->burger_service_nummer }}" required autofocus />
                    </div>
                </div>
                <div>
                    <div>
                        <x-label for="phone" :value="__('Telefoonnr')" />
                        <x-input id="phone" class="block mt-1 w-full" type="text" name="phone" value="{{ $employee->phone }}" required autofocus />
                    </div>

                    <div>
                        <x-label for="phone" :value="__('Persoonlijke e-mail')" />
                        <x-input id="personal_email" class="block mt-1 w-full" type="text" name="personal_email" value="{{ $employee->personal_email }}" required autofocus />
                    </div>

                    <div>
                        <x-label for="address" :value="__('Adres')" />
                        <x-input id="address" class="block mt-1 w-full" type="text" name="address" value="{{ $employee->address }}" required autofocus />
                    </div>

                    <div>
                        <x-label for="zipcode" :value="__('Postcode')" />
                        <x-input id="zipcode" class="block mt-1 w-full" type="text" name="zipcode" value="{{ $employee->zipcode }}" required autofocus />
                    </div>

                    <div>
                        <x-label for="city" :value="__('Woonplaats')" />
                        <x-input id="city" class="block mt-1 w-full" type="text" name="city" value="{{ $employee->city }}" required autofocus />
                    </div>
                </div>
                <div>
                    <div>
                        <x-label for="email" :value="__('E-mailadres')" />
                        <x-input id="email" class="block mt-1 w-full" type="email" name="email" value="{{ $user->email }}" required autofocus />
                    </div>

                    <div>
                        <x-label for="name" :value="__('Gebruikersnaam')" />
                        <x-input id="name" class="block mt-1 w-full" type="text" name="name" value="{{ $user->name }}" required autofocus />
                    </div>
                </div>
            </div>
            <div class="mt-2">
                <select class="form-control" name="roles[]" multiple="">
                    @foreach($roles as $role)
                        <option value="{{ $role->id }}" {{ $user->roles()->get()->contains($role) ? 'selected' : '' }}>{{ $role->name }}</option>
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
