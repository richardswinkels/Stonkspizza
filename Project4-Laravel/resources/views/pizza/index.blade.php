@extends('layouts.default')
@section('content')
    <a id="backtop" href="#top" onclick="hide()">^</a>
    <header id="top" class="header1">
    <div class="header__bg1"></div>
    <h1 class="header__title1" onclick="location.reload()" onmouseover="this.style.cursor='pointer'">Ons heerlijke menu</h1>
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

    <div class="Container1" style="margin-top: 2vw;">
    @foreach ($pizzas as $pizza)
                    <div class="FBlist">
                    @if (file_exists(public_path('\images\pizza' . $pizza->id . '.png')))
                        <img src="\imagespizza{{$pizza->id}}.png" id="pizzaimg" class="ImagesInList">
                    @else
                        <img src="{{ asset('images/3.png') }}" id="pizzaimg" class="ImagesInList">
                    @endif
                        <div style="margin-left: 20px; width: 1000px">
                            <div><strong>Naam:</strong> {{ $pizza->name }}</div>
                            <div id="price"><strong>Prijs:</strong> €{{ number_format($pizza->price(), 2, ",", ".")}}</div>
                            <div>
                            @foreach($pizza->ingredients as $ingredient => $object)
                            @if($object['quantity'] == 0)

                            @break
                        @elseif($ingredient === array_key_last($pizza->ingredients->toArray()))
                        <form method="post" action="{{route('cartorderitem.store')}}">
                                    @csrf
                                    <input type="hidden" name="pizza_id" value="{{ $pizza->id }}">
                                    <div><strong>Formaat:</strong>
                                        <select name="formaat_id" id="ddlViewBy">
                                            @foreach($sizes as $size)
                                                <option @if($size->name == 'Middel') selected @endif value="{{$size->id}}">{{$size->name}}</option>
                                            @endforeach
                                        </select>
                                    </div>
                                    <input type="image" src="{{ asset('images/4.png') }}" id="absolute2">

                                    @if ($errors->any())
                                        @foreach ($errors->all() as $error)
                                            <div class="error">{{$error}}</div>
                                        @endforeach
                                    @endif
                                </form>
                        @endif
                        @endforeach

                            </div>
                        </div>
                        <div style="width: 100%;">
                        <form method="post" action="{{ route('pizza.store') }}">
                            @csrf
                            <input id="absolute" type="image" src="{{ asset('images/6.png')}}" }}></input>
                            <input type="hidden" name="pizzaID" value="{{$pizza->id}}"></input>
                        </form>
                        </div>
                        @foreach($pizza->ingredients as $ingredient => $object)
                        @if($object['quantity'] == 0)
                        <p id="voorraad">Niet op voorraad</p>
                        @break
                        @elseif($ingredient === array_key_last($pizza->ingredients->toArray()))
                        <p id="voorraad1">Op voorraad</p>
                        @endif
                        @endforeach

                        </script>

                    </div>
     @endforeach
 </div>
@endsection
