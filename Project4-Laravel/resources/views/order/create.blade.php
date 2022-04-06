@extends('layouts.default')
@section('content')
<a id="backtop" href="#top" onclick="hide()">^</a>
<header id="top" class="header1">
    <div class="header__bg1"></div>
    <h1 class="header__title" onclick="location.reload()" onmouseover="this.style.cursor='pointer'">Bestelling plaatsen</h1>
    @if (Route::has('login'))
        @auth
            <div class="header__log">
                <svg class="header__log--icon" width="24" height="24" viewBox="0 0 24 24">
                    <path d="M12,4A4,4 0 0,1 16,8A4,4 0 0,1 12,12A4,4 0 0,1 8,8A4,4 0 0,1 12,4M12,14C16.42,14 20,15.79 20,18V20H4V18C4,15.79 7.58,14 12,14Z"></path>
                </svg>
                <a class="header__log--text" href="{{ url('/dashboard') }}">Mijn account</a>
            </div>
        @else
            <div class="header__log">
                <svg class="header__log--icon" width="24" height="24" viewBox="0 0 24 24">
                    <path d="M12,4A4,4 0 0,1 16,8A4,4 0 0,1 12,12A4,4 0 0,1 8,8A4,4 0 0,1 12,4M12,14C16.42,14 20,15.79 20,18V20H4V18C4,15.79 7.58,14 12,14Z"></path>
                </svg>
                <a class="header__log--text" href="{{ route('login') }}">Inloggen</a>
            </div>
        @endauth
    @endif
</header>
<main style="margin-top: 2vw;">
@if($orderitems != null)
    <form method="POST" action="{{route('order.store')}}">
    @csrf
        <div class="order-form-container">
            <div class="order-form-item">
                <label>Voornaam:</label>
                <input name="firstname" type="text" value="{{ old('firstname', $customer->first_name) }}"/>
                @error('firstname')
                <div class="error">{{ $message }}</div>
                @enderror
            </div>
            <div class="order-form-item">
                <label>Achternaam:</label>
                <input name="lastname" type="text" value="{{ old('lastname', $customer->last_name) }}"/>
                @error('lastname')
                <div class="error">{{ $message }}</div>
                @enderror
            </div>
            <div class="order-form-item">
                <label>Adres:</label>
                <input name="address" type="text" value="{{ old('address', $customer->address) }}"/>
                @error('address')
                <div class="error">{{ $message }}</div>
                @enderror
            </div>
            <div class="order-form-item">
                <label>Postcode:</label>
                <input name="zipcode" type="text" value="{{ old('zipcode', $customer->zipcode) }}"/>
                @error('zipcode')
                <div class="error">{{ $message }}</div>
                @enderror
            </div>
            <div class="order-form-item">
                <label>E-mail:</label>
                <input name="email" type="email" value="{{ old('email', $user->email) }}"/>
                @error('email')
                <div class="error">{{ $message }}</div>
                @enderror
            </div>
            <div class="order-form-item">
                <label>Telefoonnummer:</label>
                <input name="phone" type="tel" value="{{ old('phone', $customer->phone) }}"/>
                @error('phone')
                <div class="error">{{ $message }}</div>
                @enderror
            </div>
            <div class="order-form-item">
                <label>Bezorgmoment:</label>
                <div>
                    <select name="day">
                        @foreach($deliverydays as $day)
                            <option value="{{$day->format('d-m-Y')}}">{{$day->format('d-m-Y')}}</option>
                        @endforeach
                    </select>
                    <select name="time">
                        @foreach($deliverytimes as $time)
                            <option value="{{$time->format('H:i')}}">{{$time->format('H:i')}}</option>
                        @endforeach
                    </select>
                </div>
                @error('day')
                <div class="error">{{ $message }}</div>
                @enderror
                @error('time')
                <div class="error">{{ $message }}</div>
                @enderror
            </div>
        </div>
    <button type="submit" id="order-button">Bestellen</button>
    </form>
    @else
    <p class="order-item-warning">Geen pizza's toegevoegd aan winkelwagentje.</p>
@endif
</main>
@endsection


