@extends('layouts.main')
@section('title')
    {{ __('Medewerkers') }}
    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-nav-link :href="route('employee.create')" :active="request()->routeIs('employee.create')">
            {{ __('Nieuwe medewerker') }}
        </x-nav-link>
    </div>
@endsection

@section('content')
<div class="container items-center">
    @foreach ($employees as $employee)
        <div class="container">
            <div class="grid grid-cols-1 md:grid-cols-6">
                <div>{{ $employee->id }}</div>
                <div>{{ $employee->last_name }}</div>
                <div>{{ $employee->city }}</div>
                <div class="inline-flex gap-1 mb-1">
                    <form action="{{ route('employee.edit', [$employee]) }}" method="get">
                        <x-button class="ml-3 bg-blue-500 w-32">
                            {{ __('Wijzig') }}
                        </x-button>
                    </form>
                    <form action="{{ route('employee.destroy', [$employee]) }}" method="post">
                        @method('delete')
                        @csrf
                        <x-button class="ml-3 bg-red-500 w-32">
                            {{ __('Verwijder') }}
                        </x-button>
                    </form>
                </div>
            </div>
        </div>
    @endforeach
</div>
@endsection
