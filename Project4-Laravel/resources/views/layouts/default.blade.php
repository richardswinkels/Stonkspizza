<!DOCTYPE html>
<html lang="en">
<head>
    <title>StonksPizza</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="{{ asset('/css/Default.css') }}">
</head>
<body>
@yield('content')
<footer>
    <div class="fb2">
        <div>
            <h3>Services</h3>
            <ul>
                <li><a href="#">Bestellen</a></li>
                <li><a href="#">Inloggen gebruiker</a></li>
                <li><a href="#">Inloggen personeel</a></li>
            </ul>
        </div>
        <div>
            <h3>About</h3>
            <ul>
                <li><a href="#">Over ons</a></li>
                <li><a href="#">Team</Table></a></li>
                <li><a href="#">Contact</Table></a></li>
            </ul>
        </div>
        <div>
            <h3>StonksPizza</h3>
            <p id="about">Cras quis ullamcorper ligula, ut scelerisque mauris. Praesent porta pharetra mi, nec consectetur nisi molestie vel. Praesent a lectus non nunc ullamcorper facilisis a vel nulla.</p>
        </div>
    </div>
    <p id="copyright">©StonksPizza 2021</p>
</footer>
<script>
    window.onscroll = function(ev) {
        if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
            document.getElementById("backtop").style.display = "block"
        }
        document.getElementById("backtop").addEventListener("click", click);

        function click() {
            document.getElementById("backtop").style.display = "none"
        }
    };
</script>
</body>
</html>

