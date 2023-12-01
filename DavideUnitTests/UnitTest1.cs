using Day01Davide;

namespace DavideUnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestLast()
    {
        int num = CalibrationReader.FindLastNumber("oneonetwotwo");
        Assert.That(num, Is.EqualTo(2));

        num = CalibrationReader.FindLastNumber("5fiveeightl8veight1pxfptklnhj");
        Assert.That(num, Is.EqualTo(1));

        num = CalibrationReader.FindLastNumber("cbpvqbddlllczgfmninenine3zqvptoneightx");
        Assert.That(num, Is.EqualTo(8));

        num = CalibrationReader.FindLastNumber("jfbtwoneninenine6dgxnqjgsteighttwo");
        Assert.That(num, Is.EqualTo(2));

        num = CalibrationReader.FindLastNumber("lflcrscclg35oneeightpmhhm1bkftvxqbmx1");
        Assert.That(num, Is.EqualTo(1));

        num = CalibrationReader.FindLastNumber("74nsvkm5nztmctpmngppzkphltpx");
        Assert.That(num, Is.EqualTo(5));  

        num = CalibrationReader.FindLastNumber("1122534");
        Assert.That(num, Is.EqualTo(4));     
    }

    [Test]
    public void TestFirst()
    {
        int num = CalibrationReader.FindFirstNumber("oneonetwotwo");
        Assert.That(num, Is.EqualTo(1));

        num = CalibrationReader.FindFirstNumber("5fiveeightl8veight1pxfptklnhj");
        Assert.That(num, Is.EqualTo(5));

        num = CalibrationReader.FindFirstNumber("cbpvqbddlllczgfmninenine3zqvptoneightx");
        Assert.That(num, Is.EqualTo(9));

        num = CalibrationReader.FindFirstNumber("jfbtwoneninenine6dgxnqjgsteighttwo");
        Assert.That(num, Is.EqualTo(2));

        num = CalibrationReader.FindFirstNumber("lflcrscclg35oneeightpmhhm1bkftvxqbmx1");
        Assert.That(num, Is.EqualTo(3));

        num = CalibrationReader.FindFirstNumber("74nsvkm5nztmctpmngppzkphltpx");
        Assert.That(num, Is.EqualTo(7));    

        num = CalibrationReader.FindFirstNumber("54165498");
        Assert.That(num, Is.EqualTo(5));    
    }
}