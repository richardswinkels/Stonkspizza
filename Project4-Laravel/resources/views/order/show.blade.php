@extends('layouts.default')
@section('content')
<a id="backtop" href="#top" onclick="hide()">^</a>
<header id="top" class="header1">
    <div class="header__bg1"></div>
        <h1 class="header__title" onclick="location.reload()" onmouseover="this.style.cursor='pointer'">Bestelling</h1>
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
    <img id="refresh-button" src="{{asset('images/10.png')}}" onClick="window.location.reload();"/>
    <p id="order-status-label">Bestelstatus:</p>
    <div class="order-status">
        @if($order->status->id == 1)
            <img src="{{asset('images/4.png')}}"/>
            <p>Besteld</p>
        @elseif($order->status->id == 2)
            <img src="{{asset('images/8.png')}}"/>
            <p>Wordt bereid</p>
        @elseif($order->status->id == 3)
            <img src="{{asset('images/7.png')}}"/>
            <p>In oven</p>
        @elseif($order->status->id == 4)
            <img src="{{asset('images/1.png')}}"/>
            <p>Onderweg</p>
        @elseif($order->status->id == 5)
            <img src="{{asset('images/9.png')}}"/>
            <p>Bezorgd</p>
        @elseif($order->status->id == 6)
            <img src="{{asset('images/11.png')}}"/>
            <p>Geannuleerd</p>
        @endif
    </div>
    <div class="order-items-container" >
        @if($order->orderitems != null)
            @foreach($order->orderitems as $orderitem_id => $orderitem)
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
                    </div>
                </div>
            @endforeach
            <div class="order-pricetotal">
                <p>Totaalprijs: €{{ number_format($order->price(), 2, ",", ".")}}</p>
                @if($order->status->id != 4 && $order->status->id != 5 && $order->status->id != 6)
                <form method="POST" action="{{route('order.update', $order->id)}}">
                    @csrf
                    @method('PUT')
                    <button type="submit"class="order-item-delete">Bestelling annuleren</button>
                </form>
                @endif
            </div>
        @endif
    </div>
</main>
@endsection

