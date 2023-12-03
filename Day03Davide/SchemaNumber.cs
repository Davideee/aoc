namespace Day03Davide{
    public class SchemaNumber{
        public readonly int Row;

        public readonly int StartIndex;

        public readonly int EndIndex;

        public readonly int Value;

        public SchemaNumber(int value, int row, int startIndex, int endIndex){
            Value = value;
            Row = row;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        public override string ToString()
        {
            return $"Value: {Value}, Row: {Row}, StartIndex: {StartIndex}, EndIndex: {EndIndex}";
        }
    }
}