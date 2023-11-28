# AOC 2023

Es geht los :)

# Voraussetzungen

Ich entwickle bei mir (mal) mit VSCode. Du benötigst das neuste .NET Sdk:

[.NET sdk](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

Dann VSCode so aufsetzen mit Extensions:

[VSCode](https://code.visualstudio.com/docs/csharp/get-started)

# Neuer Tag, neue Chance

Am besten für jeden Tag ein neues Projekt erstellen:

`dotnet new console -o DayXX`

Dann Projekt zu Solution hinzufügen:

`dotnet sln add DayXX\DayXX.csproj`

Und noch den Datenordner mit Textfile erstellen: 

`mkdir DayXX/data`
`"Hello, World!" | Out-File -FilePath "DayXX/data/data.txt"`

**Program.cs** von Template Projekt kopieren und los :)

## Build / Run

1. Navigiere in das Verzeichnis: `cd DayXX`
2. Builden: `dotnet build`
3. ..oder ausführen `dotnet run`
