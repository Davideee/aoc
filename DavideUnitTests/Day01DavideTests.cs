using Day01Davide;

namespace DavideUnitTests;

public class Tests
{

    [Test]
    public void TestFindLastNumber()
    {
        int num = CalibrationReader.FindFirstOrLastNumber("oneonetwotwo", true);
        Assert.That(num, Is.EqualTo(2));

        num = CalibrationReader.FindFirstOrLastNumber("5fiveeightl8veight1pxfptklnhj", true);
        Assert.That(num, Is.EqualTo(1));

        num = CalibrationReader.FindFirstOrLastNumber("cbpvqbddlllczgfmninenine3zqvptoneightx", true);
        Assert.That(num, Is.EqualTo(8));

        num = CalibrationReader.FindFirstOrLastNumber("jfbtwoneninenine6dgxnqjgsteighttwo", true);
        Assert.That(num, Is.EqualTo(2));

        num = CalibrationReader.FindFirstOrLastNumber("lflcrscclg35oneeightpmhhm1bkftvxqbmx1", true);
        Assert.That(num, Is.EqualTo(1));

        num = CalibrationReader.FindFirstOrLastNumber("74nsvkm5nztmctpmngppzkphltpx", true);
        Assert.That(num, Is.EqualTo(5));  

        num = CalibrationReader.FindFirstOrLastNumber("1122534", true);
        Assert.That(num, Is.EqualTo(4));

        num = CalibrationReader.FindFirstOrLastNumber("sadaskdj4dsfpkjsdiofj5", true);
        Assert.That(num, Is.EqualTo(5)); 

        num = CalibrationReader.FindFirstOrLastNumber("sadaskdj4dsfpkjsdiofjsadasd", true);
        Assert.That(num, Is.EqualTo(4));    

        num = CalibrationReader.FindFirstOrLastNumber("26", true);
        Assert.That(num, Is.EqualTo(6));      
    }

    [Test]
    public void TestFindFirstNumber()
    {
        int num = CalibrationReader.FindFirstOrLastNumber("oneonetwotwo");
        Assert.That(num, Is.EqualTo(1));

        num = CalibrationReader.FindFirstOrLastNumber("5fiveeightl8veight1pxfptklnhj");
        Assert.That(num, Is.EqualTo(5));

        num = CalibrationReader.FindFirstOrLastNumber("cbpvqbddlllczgfmninenine3zqvptoneightx");
        Assert.That(num, Is.EqualTo(9));

        num = CalibrationReader.FindFirstOrLastNumber("jfbtwoneninenine6dgxnqjgsteighttwo");
        Assert.That(num, Is.EqualTo(2));

        num = CalibrationReader.FindFirstOrLastNumber("lflcrscclg35oneeightpmhhm1bkftvxqbmx1");
        Assert.That(num, Is.EqualTo(3));

        num = CalibrationReader.FindFirstOrLastNumber("74nsvkm5nztmctpmngppzkphltpx");
        Assert.That(num, Is.EqualTo(7));    

        num = CalibrationReader.FindFirstOrLastNumber("54165498");
        Assert.That(num, Is.EqualTo(5));  

        num = CalibrationReader.FindFirstOrLastNumber("sadaskdj4dsfpkjsdiofj5");
        Assert.That(num, Is.EqualTo(4)); 

        num = CalibrationReader.FindFirstOrLastNumber("sadaskdj4dsfpkjsdiofjsadasd");
        Assert.That(num, Is.EqualTo(4));
        
        num = CalibrationReader.FindFirstOrLastNumber("26");
        Assert.That(num, Is.EqualTo(2));    

        num = CalibrationReader.FindFirstOrLastNumber("74nsvkm5nztmctpmngppzkphltpx");
        Assert.That(num, Is.EqualTo(7));      
    }

    [Test]
    public void TestIntegrationGetSum()
    {
        string[] stringList = [
            "74nsvkm5nztmctpmngppzkphltpx", //75
            "74nsvkm5nztmctpmngppzkphltpx", //75
            "pnjmlpbbeightskgdf6one", //81
            "lrfjxppqbdseven94ntnskpkdqeightsix5xskh" //75
            ];

        CalibrationReader calibrationReader = new (stringList);
        Assert.That(calibrationReader.GetSum, Is.EqualTo(75+75+81+75));
    }

    [Test]
    public void TestIntegrationGetSumSampleData()
    {
        string[] stringList = [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
            ];

        CalibrationReader calibrationReader = new (stringList);
        Assert.That(calibrationReader.GetSum, Is.EqualTo(281));
    }
}