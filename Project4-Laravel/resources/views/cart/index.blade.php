@extends('layouts.default')
@section('content')
<a id="backtop" href="#top" onclick="hide()">^</a>
<header id="top" class="header1">
    <div class="header__bg1"></div>
    <h1 class="header__title" onclick="location.reload()" onmouseover="this.style.cursor='pointer'">Winkelwagen</h1>
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
    <div class="order-items-container" >
        @if($orderitems != null)
            @foreach($orderitems as $orderitem_id => $orderitem)
                <div class="order-item">
                    <img src="{{ asset('images/3.png') }}">
                    <div class="order-item-description">
                    <p>Pizza {{$orderitem->pizza->name}} - {{$orderitem->size->name}}</p>
                    @foreach($orderitem->ingredients as $ingredient)
                        <p>{{ $ingredient->name }}</p>
                    @endforeach
                    </div>
                    <div class="order-item-price">
                    <p>€{{ number_format($orderitem->price(), 2, ",", ".") }}</p>
                    <form method="POST" action="{{route('cartorderitem.destroy', $orderitem_id)}}">
                       @csrf
                       @method('DELETE')
                        <button type="submit"class="order-item-delete">Verwijderen</button>
                    </form>
                    </div>
                </div>
            @endforeach
            <div class="order-pricetotal">
                <p>Totaalprijs: €{{ number_format($pricetotal, 2, ",", ".")}}</p>
                <a href="{{route('order.create')}}">Verder naar bestellen</a>
            </div>
        @else
            <p class="order-item-warning">Geen pizza's toegevoegd aan winkelwagentje.</p>
        @endif
    </div>
</main>
@endsection
