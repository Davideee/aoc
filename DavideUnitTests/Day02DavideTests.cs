using Day02Davide;

namespace DavideUnitTests;

public class Day02Davide
{
    [Test]
    public void ReadId()
    {
        PuzzleGame puzzleGame = new("Game 3234: sjfcnoksdc");

        Assert.That(puzzleGame.Id, Is.EqualTo(3232));
    }
}

