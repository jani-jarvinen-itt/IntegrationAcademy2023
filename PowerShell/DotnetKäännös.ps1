# Automaatioskripti .NET-sovelluksen kääntämiseen ja julkaisuun.
# Tehnyt N.N syyskuussa 2023.

# kansiot
$lähdekoodit = "C:\Integration\Koodit\DotNet\HelloWorld"
$kohdekansio = "C:\Install\Integration"

# käännetään .NET-sovellus
cd $lähdekoodit
dotnet build

# tarkistetaan onnistuiko käännös (last exit code = 0)
if ($LASTEXITCODE -eq 0) {

    # luodaan kohdekansiorakenne
    md -Force $kohdekansio

    # kopioidaan sovelluksen binäärit
    $binäärit = $lähdekoodit + "\bin\Debug\net7.0\*.*"
    copy $binäärit -Destination $kohdekansio
}
