namespace Day10.Davide;

public class Direction {
    public readonly Tuple<int, int> Move;
    public Func<char, bool> MoveCondition;

    public Direction(int x, int y, Func<char,bool> moveCondition) {
        Move = Tuple.Create(x, y);
        MoveCondition = moveCondition;
    }
}