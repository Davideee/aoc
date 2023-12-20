using Day03.Davide;

namespace UnitTests;
[Ignore("Gesamte Klasse wird ignoriert.")]
public class Day03Test
{
   [Test]
   public void ReadNumbers()
   {
      EngineSchematicsReader engineSchematicsReader = new(new string[] { ".....+.58." });
      Assert.That(engineSchematicsReader.SchemaNumbers[0].Value, Is.EqualTo(58));
      Assert.That(engineSchematicsReader.SchemaNumbers[0].StartIndex, Is.EqualTo(7));

      EngineSchematicsReader engineSchematicsReader2 = new(new string[] { "617*......" });
      Assert.That(engineSchematicsReader2.SchemaNumbers[0].Value, Is.EqualTo(617));
      Assert.That(engineSchematicsReader2.SchemaNumbers[0].StartIndex, Is.EqualTo(0));
      Assert.That(engineSchematicsReader2.SchemaNumbers[0].EndIndex, Is.EqualTo(2));
   }

   [Test]
   public void SumValidSchemaNumbers()
   {
      EngineSchematicsReader esr1 = new(new string[] { "617*......" });
      Assert.That(esr1.SumValidSchemaNumbers, Is.EqualTo(617));

      EngineSchematicsReader esr2 = new(new string[] { "617*......", ".....+.58." });
      Assert.That(esr2.SumValidSchemaNumbers, Is.EqualTo(617));

      EngineSchematicsReader esr3 = new(new string[] { "617*......", ".....++58." });
      Assert.That(esr3.SumValidSchemaNumbers, Is.EqualTo(617 + 58));

      EngineSchematicsReader esr4 = new(new string[] { "617.......", "+....++58." });
      Assert.That(esr4.SumValidSchemaNumbers, Is.EqualTo(617 + 58));

      EngineSchematicsReader esr5 = new(new string[] { "..617.....", "+........." });
      Assert.That(esr5.SumValidSchemaNumbers, Is.EqualTo(0));

      EngineSchematicsReader esr6 = new(new string[] { "..617.....", ".%........" });
      Assert.That(esr6.SumValidSchemaNumbers, Is.EqualTo(617));
   }

   [Test]
   public void LetterOrDigit()
   {
      Assert.That(char.IsLetterOrDigit('*'), Is.False);
      Assert.That(char.IsLetterOrDigit('@'), Is.False);
      Assert.That(char.IsLetterOrDigit('/'), Is.False);
      Assert.That(char.IsLetterOrDigit('\\'), Is.False);
      Assert.That(char.IsLetterOrDigit('&'), Is.False);
      Assert.That(char.IsLetterOrDigit('+'), Is.False);
      Assert.That(char.IsLetterOrDigit('%'), Is.False);
      Assert.That(char.IsLetterOrDigit('$'), Is.False);
   }

   [Test]
   public void Integration()
   {
      string[] str = {
            "12.......*..",
            "+.........34",
            ".......-12..",
            "..78........",
            "..*....60...",
            "78..........",
            ".......23...",
            "....90*12...",
            "............",
            "2.2......12.",
            ".*.........*",
            "1.1.......56"
            };
      EngineSchematicsReader engineSchematicsReader = new(str);
      Assert.That(engineSchematicsReader.SumValidSchemaNumbers, Is.EqualTo(413));
   }
}





