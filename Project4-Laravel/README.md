<p align="center"><img src="https://www.summacollege.nl/images/default-source/default-album/logo.png?sfvrsn=17f34f85_6/" width="400"></a></p>


## Project 4
### Summa College opleiding Software Development
Het project is onderdeel van de opleiding software developer. In dit project kun je aantonen dat je de voorgaande modules onder controle hebt. 

## Opnieuw pizza's
De context van het project is opnieuw een pizzaleverancier. Jouw klant is een pizzatent die online pizza verkoopt, op een locatie bereidt en ze daarna via een koerier thuis aflevert. De klant heet "Stonks Pizza"
Ze hadden het bedrijf "The Shabby Mess Makers(SMM)" de opdracht gegeven om een applicatie en website te maken. Helaas heeft SMM zich met een grote som geld uit de voeten gemaakt zonder iets te leveren. Dus het aan jullie om er nog iets van te maken. 
Ze gaan over 5 weken open en dus zal er snel iets geleverd moeten worden.

## Wat is er
Er zijn een groot aantal user stories die je kunt verdelen over je product team. Jouw leidinggevende wil dat je zowel bezig bent met web als met applicatie(C#) onderdelen. Dus het is niet de bedoeling dat 1 persoon de website maakt en 1 persoon de applicatie.

### Opzet
1. Bekijk alles wat je hebt (dag 1)
2. Zorg voor een goede ontwikkelomgeving en beschrijf die in een document (dag 1).
3. Zorg voor een goede testomgeving enb beschrijf die in een document (dag 1).
4. Zorg voor een goede projectomgeving (dag 1).
5. Maak een werkverdeling van de taken voor alle projectleden (dag 1).
6. Maak een gedetailleerde planning voor de eerste week en zorg er voor dat je al user stories af krijgt (dag 1).
7. Zorg er voor dat jouw werk in een eigen github repo terecht komt (week 1).

## Hoe te gebruiken
Deze repo is een standaard laravel app met breeze. Breeze is de component die gebruikt wordt voor authenticatie. Daarnaast is er een tabel customers en een tabel employees als uitbreiding op de users. De users hebben een rol die weeer is opgenomen in een tabel roles en een tabel user_roles. Alle migrations zijn al aanwezig en er is een seed gemaakt (testdata).
Je kunt deze repo clonen op je eigen systeem met het commando:
clone  https://github.com/summacollege/project4.git

Zodra je dat hebt gedaan kun je de .git folder weggooien en je eigen git repo aanmaken (en eigen github repo).
Natuurlijk moet je nog wat commando's en gebruiken om de boel aan de gang te krijgen en natuurlijk ook je .env weer aanmaken.
- composer update
- npm install && npm run dev (of npm run watch)
- rename .env.examnple naar .env
- maak database project4 en maak juiste instellingen in .env
- maak laravel key aan met commando: php artisan key:generate
- run php artisan migrate --seed

## License
Dit project is gemaakt met het framework laravel.
Het project wordt vrijgegeven onder MIT licentie.
The Laravel framework is open-sourced software licensed under the [MIT license](https://opensource.org/licenses/MIT).
