# Ruben_Booking

Digital Bokningstjänst för Mötesrum
Gruppen ska utveckla en bokningstjänst där användare kan boka mötesrum för specifika tider och datum.

//Lägg till teknisk specifikation om hur en användare installerar och öppnar upp projektet på sin dator.
kör "npm i" i konsollen för att installera de paket som behövs för att kunna starta upp projektet.

KRAV
Systemet ska hantera:

    Inloggning och autentisering
    Visning av tillgängliga rum
    Bokning och avbokning av rum
    Administration av rum, inklusive skapande, redigering och radering
    Backend ska vara en .NET WebAPI, och frontend ska utvecklas i React eller Blazor beroende på gruppens fokus

Examinationskrav

    Funktionell applikation: Applikationen ska vara fungerande, med möjlighet att boka och hantera mötesrum samt implementera grundläggande säkerhetsåtgärder.
    Kodkvalitet: Kodstrukturen ska vara välorganiserad och följa SOLID-principer samt best practices för de valda teknologierna.
    Dokumentation: Det ska finnas en README-fil med installationsinstruktioner samt en teknisk specifikation som beskriver arkitektur, API-design och säkerhetsimplementering.
    Testning: Automatiska tester för både backend och frontend, samt dokumentation av manuella tester.

Tillägg

    Rum med upp till 8 person.
    Max 2 samtidiga bokningar per konsult/anställd.
    Boka max 3 månader fram.
    Bokningstid max 3 dagar.
    Konsult/anställd admin rättigheter.
    Följa polisens hemsida färger, typsnitt, design.
    Hårdkoda inlogg – men se skillnad vid bokning på inloggtyp.
    Konsult - email, id.
    Anställd - email, id, telefonnummer.
    Funktion visa om rummets teknik är ur funktion.
    Myndighet - GDPR.
    Kryptering till databas.

Test

    Backend - Gå till menyn "Test" -> Run all tests
    Frontend - Klicka på testikonen i verktygsfältet eller npm test via terminalen.

