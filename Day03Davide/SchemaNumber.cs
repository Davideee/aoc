using System.Security.Cryptography.X509Certificates;

namespace Day03Davide{
    public class SchemaNumber{
        public readonly int Row;

        public readonly int StartIndex;

        public readonly int EndIndex;

        public readonly int Value;

        public readonly List<Field> Fields = new();

        public SchemaNumber(int value, int row, int startIndex, int endIndex){
            Value = value;
            Row = row;
            StartIndex = startIndex;
            EndIndex = endIndex;
            for (int i = StartIndex; i < endIndex + 1; i++)
            {
                Fields.Add(new Field(Row, i));
            }
        }

        public override string ToString()
        {
            return $"Value: {Value}, Row: {Row}, StartIndex: {StartIndex}, EndIndex: {EndIndex}";
        }
    }
}