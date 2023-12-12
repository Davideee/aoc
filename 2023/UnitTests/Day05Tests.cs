using Day05;

namespace UnitTests;
[Ignore("Gesamte Klasse wird ignoriert.")]
public class Day05Test
{
  [Test]
  public void TestNumberInRange()
  {
    MapRange r1 = new MapRange(0, 10);
    Assert.That(r1.NumberInsideRange(1), Is.True);
    Assert.That(r1.NumberInsideRange(5), Is.True);
    Assert.That(r1.NumberInsideRange(10), Is.True);
    Assert.That(r1.NumberInsideRange(11), Is.False);
  }

  [Test]
  public void TestOverlappingRange()
  {
    MapRange r1 = new(0, 10);
    MapRange r2 = new(2, 10);
    Assert.That(r1.OverlappingInput(r2), Is.True);
    Assert.That(r2.OverlappingInput(r1), Is.False);
  }
}





