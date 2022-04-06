<x-guest-layout>
    <x-auth-card>
        <x-slot name="logo">
            <a href="/">
                <x-application-logo class="w-20 h-20 fill-current text-gray-500" />
            </a>
        </x-slot>

        <!-- Validation Errors -->
        <x-auth-validation-errors class="mb-4" :errors="$errors" />

        <form method="POST" action="{{ route('register') }}">
            @csrf
            <div class="grid grid-cols-1 md:grid-cols-2 gap-5">
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

                    <!-- Confirm Password -->
                    <div class="mt-4">
                        <x-label for="password_confirmation" :value="__('Bevestig wachtwoord *')" />

                        <x-input id="password_confirmation" class="block mt-1 w-full"
                                        type="password"
                                        name="password_confirmation" required />
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

                    <!-- addres -->
                    <div class="mt-4">
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
            <div class="flex items-center justify-end mt-4">
                <a class="underline text-sm text-gray-600 hover:text-gray-900" href="{{ route('login') }}">
                    {{ __('Already registered?') }}
                </a>

                <x-button class="ml-4">
                    {{ __('Register') }}
                </x-button>
            </div>
        </form>
        <div class="text-sm text-gray-400">Invoer gemarkeerd met een * is verplicht</div>
    </x-auth-card>
</x-guest-layout>
