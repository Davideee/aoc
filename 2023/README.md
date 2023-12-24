# AOC

Es geht los :)

# Voraussetzungen

Ich entwickle bei mir (mal) mit VSCode. Du benötigst das neuste .NET Sdk:

[.NET sdk](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

Dann VSCode so aufsetzen mit Extensions:

[VSCode](https://code.visualstudio.com/docs/csharp/get-started)

# Neuer Tag, neue Chance

Am besten für jeden Tag ein neues Projekt erstellen:

`dotnet new console -o Day24`

Dann Projekt zu Solution hinzufügen:

`dotnet sln add Day24\Day24.csproj`

Und noch den Datenordner mit Textfile erstellen: 

`mkdir DayXX/data`
`"Hello, World!" | Out-File -FilePath "DayXX/data/data.txt"`

Um den gesamten Inhalt des `data`-Ordners und seiner Unterverzeichnisse in das Ausgabeverzeichnis (Output Directory) beim Build zu kopieren, füge folgenden Zeilen in die `DayXX.csproj`-Datei ein:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <!-- Fügen Sie die folgenden Zeilen ein -->
  <ItemGroup>
    <None Update="data\**\*.*">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>

Noch **Program.cs** von Template Projekt kopieren und los :)

## Build / Run

1. Navigiere in das Verzeichnis: `cd DayXX`
2. Builden: `dotnet build`
3. ..oder ausführen `dotnet run`
