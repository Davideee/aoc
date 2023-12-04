namespace Day03Davide{
    public class Gear{
        public readonly int Row;

        public readonly int StartIndex;

        public readonly int EndIndex;

        public readonly int Column;

        public readonly List<Field> Fields = new();

        public Gear(int row, int column, int height, int width){
            Row = row;
            Column = column;
            int startIndex = column == 0 ? 0 : column - 1;
            int endIndex = column == width ? width : column + 1;
            int topIndex = row == 0 ? 0 : row - 1;
            int bottomIndex = row == height ? height : row + 1;
            for (int i = startIndex; i < endIndex + 1; i++)
            {
                for (int j = topIndex; j < bottomIndex + 1; j++)
                {
                    Fields.Add(new Field(j, i));
                }
            }
        }
    }
}