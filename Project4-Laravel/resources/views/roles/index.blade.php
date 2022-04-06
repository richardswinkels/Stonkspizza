@extends('layouts.main')
@section('title')
    {{ __('Rollen') }}
@endsection

@section('content')
<div class="container items-center">
    @foreach ($roles as $role)
        <div class="container">
            <div class="grid grid-cols-1 md:grid-cols-6">
                {{ $role->name }}
                <div class="inline-flex gap-1 mb-1">
                    <form action="{{ route('role.edit', [$role]) }}" method="get">
                        <x-button class="ml-3 bg-blue-500 w-32">
                            {{ __('Wijzig') }}
                        </x-button>
                        {{-- <button type="submit" name="edit" class="">Wijzig</button> --}}
                    </form>
                    <form action="{{ route('role.destroy', [$role]) }}" method="post">
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
