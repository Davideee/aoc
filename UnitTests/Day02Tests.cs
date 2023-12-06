using Day02;

namespace UnitTests;

public class Day02Test
{
    [Test]
    public void PuzzleGameReadId()
    {
        PuzzleGame puzzleGame = new("Game 3234: 3 blue");
        Assert.That(puzzleGame.Id, Is.EqualTo(3234));
        PuzzleGame puzzleGame1 = new("Game 1: 3 blue");
        Assert.That(puzzleGame1.Id, Is.EqualTo(1));
    }

    [Test]
    public void PuzzleGameReadSamples()
    {
        string line = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        PuzzleGame puzzleGame = new(line);
        Assert.That(puzzleGame.puzzleSamples.Count, Is.EqualTo(3));
    }

    [Test]
    public void PuzzleSampleParseSamples()
    {
        string line = " 3 blue, 4 red, 9 green ";
        PuzzleSample puzzleSample = new(line);
        Assert.That(puzzleSample.Red, Is.EqualTo(4));
        Assert.That(puzzleSample.Blue, Is.EqualTo(3));
        Assert.That(puzzleSample.Green, Is.EqualTo(9));
    }
}

