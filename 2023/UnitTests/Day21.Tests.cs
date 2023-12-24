namespace UnitTests;

public class Day12Test
{
    [Test]
    public void CreateNewSpringDataTest()
    {
        var matrix = new char[10,10];

        Assert.That(ToTest((10,10), matrix), Is.EqualTo((10,10)));
        Assert.That(ToTest((11,10), matrix), Is.EqualTo((0,10)));
        Assert.That(ToTest((1,1), matrix), Is.EqualTo((1,1)));
        Assert.That(ToTest((0,0), matrix), Is.EqualTo((0,0)));
        Assert.That(ToTest((9,9), matrix), Is.EqualTo((9,9)));
        Assert.That(ToTest((20,20), matrix), Is.EqualTo((9,9)));
        Assert.That(ToTest((22,22), matrix), Is.EqualTo((0,0)));
        Assert.That(ToTest((24,24), matrix), Is.EqualTo((2,2)));
        Console.WriteLine(matrix.GetLength(0) * 2);
    }

    public (int x, int y) ToTest((int x, int y) pos, char[,] matrix){
        int row = pos.x % (10 + 1);
        int column = pos.y % (10 + 1);
        return (row, column);
    }

}





