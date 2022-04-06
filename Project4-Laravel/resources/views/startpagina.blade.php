@extends('layouts.default')
@section('content')
    <a id="backtop" href="#top" onclick="hide()">^</a>

    <header id="top" class="header">
    <div class="header__bg"></div>
    <h1 class="header__title" onclick="location.reload()" onmouseover="this.style.cursor='pointer'">StonksPizza</h1>
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

    <img src="images/1.png" class="Images" id="Spin">
    <p id="centeralignb"><strong>We bezorgen uw bestelling aan huis!</strong></p><br><br>
    <div class="inspringen">
        <div class="checkmark" style="float: left;"></div>
        <p class="inspringen1" style="font-size: 2vw;"> De bezorgtijd bedraagt gemiddeld slechts 20 minuten.</p><br>
        <div class="checkmark" style="float: left;"></div>
        <p class="inspringen1" style="font-size: 2vw;"> Geheel kosteloze bezorging.</p><br>
        <div class="checkmark" style="float: left;"></div>
        <p class="inspringen1" style="font-size: 2vw;"> Gespecialiseerde bezorgers.</p><br>
        <div class="checkmark" style="float: left;"></div>
        <p class="inspringen1" style="font-size: 2vw;"> Vervoerd onder warmtelamp.</p><br>
    </div>

    <div class="Area2">
        <div class="Area2_bg"></div>
        <p id="down"><strong>Vers uit onze oven!</strong></p><br>
        <div class="inspringen2">
            <div class="checkmark" style="float: left;"></div>
            <p class="inspringen1" style="font-size: 2vw;"> Alle pizza's zijn vers!</p><br>
            <div class="checkmark" style="float: left;"></div>
            <p class="inspringen1" style="font-size: 2vw;"> Groentes worden gekoeld bewaard.</p><br>
            <div class="checkmark" style="float: left;"></div>
            <p class="inspringen1" style="font-size: 2vw;"> Krokante pizza bodem is gegarandeerd.</p><br>
            <div class="checkmark" style="float: left;"></div>
            <p class="inspringen1" style="font-size: 2vw;"> Wij importeren deeg uit Italië.</p><br>
        </div>
        <img src="images/2.png" id="Spin1">
    </div>

    <p id="Besteltxt"><strong>Stel de lekkerste pizza uit uw leven samen door hieronder op de knop te klikken!</strong></p><br><br>


     <div class="buttons">
        <div class="container">
            <a href="{{ route('pizza.index') }}" class="btn effect01"><span>Bestellen</span></a>
        </div>
      </div>
@endsection
