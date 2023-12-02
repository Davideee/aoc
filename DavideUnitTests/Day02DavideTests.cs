using Day02Davide;

namespace DavideUnitTests;

public class Day02Davide
{
    [Test]
    public void ReadId()
    {
        PuzzleGame puzzleGame = new("Game 3234: sjfcnoksdc");

        Assert.That(puzzleGame.Id, Is.EqualTo(3234));

        PuzzleGame puzzleGame1 = new("Game 1: sjfcnoksdc");

        Assert.That(puzzleGame1.Id, Is.EqualTo(1));
    }

    [Test]
    public void ReadSamples()
    {
        string line = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        PuzzleGame puzzleGame = new(line);

    }
}

