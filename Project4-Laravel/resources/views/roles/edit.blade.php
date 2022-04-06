@extends('layouts.main')
@section('title')
    {{ __('Wijzig een rol:') }}
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

        <form method="POST" action="{{ route('role.update', [$role]) }}">
            @csrf
            @method('put')
            <div>
                <x-label for="name" :value="__('rol')" />
                <x-input id="name" class="block mt-1 w-full" type="text" name="name" value="{{ $role->name }}" required autofocus />
            </div>

            <div class="flex items-center justify-end mt-4">
                <x-button class="ml-3">
                    {{ __('Bewaar') }}
                </x-button>
            </div>
        </form>
    </x-auth-card-app>
@endsection
