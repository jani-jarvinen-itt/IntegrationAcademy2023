# Tulostaa kaikki ajossa olevat prosessit, jotka alkavat kirjaimella "P".
Get-Process | where { $_.ProcessName -like "P*" }
Get-Process -Name "P*"

# Etsii tietystä kansiosta ja kaikista sen alikansiosta *.log-tyyppiset tiedostot, ja poistaa ne, jos ne ovat vanhempia kuin 60 pv.

$aikaraja = (Get-Date).AddDays(-60)
dir | where { $_.LastWriteTime -lt $aikaraja } | del

# Kopioi kaikki ajettavat tiedostot tietystä lähdekansiosta kohdekansioon. Ajettavia tiedostoja ovat *.exe, *.dll ja *.cmd.

copy *.exe,*.dll,*.cmd -Recurse -Destination C:\Temp\

# Lukee WorldTime-palvelusta (http://worldtimeapi.org/) Helsingin kellonajan, ja jos viikonpäivä on tiistai, tulostaa ruudulle tekstin "Aika päivittää".

$kellonaika = Invoke-RestMethod http://worldtimeapi.org/api/timezone/Europe/Helsinki
if ($kellonaika.day_of_week -eq 2) { echo "Aika päivittää!" }

# Käyttää .NET-ohjelmointiympäristön luokkaa System.DateTime listataksesi kuluvan päivämäärän ja kellonajan.

[DateTime]::Now
