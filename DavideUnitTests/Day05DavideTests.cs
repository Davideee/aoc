using Day05Davide;

namespace DavideUnitTests;

public class Day05Davide
{
    [Test]
    public void TestNumberInRange() {
      MapRange r1 = new MapRange(0,10);
      Assert.That(r1.NumberInsideRange(1), Is.True);
      Assert.That(r1.NumberInsideRange(5), Is.True);
      Assert.That(r1.NumberInsideRange(10), Is.True);
      Assert.That(r1.NumberInsideRange(11), Is.False);
    }

    [Test]
    public void TestOverlappingRange() {
      MapRange r1 = new MapRange(0,10);
      MapRange r2 = new MapRange(2,10);
      Assert.That(r1.OverlappingInput(r2), Is.True);
      Assert.That(r2.OverlappingInput(r1), Is.False);
    }
}





