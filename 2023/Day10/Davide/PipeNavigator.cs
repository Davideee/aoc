namespace Day10.Davide;

public class PipeNavigator {
    private readonly List<Tuple<int, int>> _routes = new();
    private readonly char[,] _fields;
    private Tuple<int, int> _currentPosition;

    private static readonly Direction Up = new(-1, 0, UpCondition);
    private static readonly Direction Down = new(1, 0, DownCondition);
    private static readonly Direction Left = new(0, -1, LeftCondition);
    private static readonly Direction Right = new(0, 1, RightCondition);

    private readonly Dictionary<char, List<Direction>> DirectionsMap = new() {
        {'7', new List<Direction> { Left, Down} },
        {'F', new List<Direction> { Right, Down} },
        {'L',new List<Direction> { Up, Right} },
        {'J', new List<Direction> { Up, Left} },
        {'|', new List<Direction> { Up, Down} },
        {'-', new List<Direction> { Left, Right} },
        {'S', new List<Direction> { Up, Down, Left, Right } },
    };

    private readonly Tuple<int, int> _start;
    private static bool LeftCondition(char c) => c is '-' or 'F' or 'L' or 'S';
    private static bool RightCondition(char c) => c is 'J' or '7' or '-' or 'S';
    private static bool DownCondition(char c) => c is '|' or 'J' or 'L' or 'S';
    private static bool UpCondition(char c) => c is '7' or 'F' or '|' or 'S';

    public PipeNavigator(char[,] fields, Tuple<int, int> start) {
        _currentPosition = start;
        _start = start;
        _fields = fields;

        _routes.Add(start);
        _routes.Add(start);
        FindPath();
    }

    public int GetFarestCount => (_routes.Count - 2) / 2;

    private void FindPath() {
        char positionChar = 'S';
        while (positionChar != 'S' || _routes[^2].Equals(_start)) {
            Tuple<int, int> newPosition = GoToNewPosition(DirectionsMap[positionChar]);
            _routes.Add(newPosition);
            positionChar = _fields[newPosition.Item1, newPosition.Item2];
            _currentPosition = newPosition;
        }
    }

    private Tuple<int, int> GoToNewPosition(List<Direction> directions) {
        foreach (var direction in directions) {
            Tuple<int, int> t = Tuple.Create(_currentPosition.Item1 + direction.Move.Item1, _currentPosition.Item2 + direction.Move.Item2);
            var c = GoToPosition(t);
            if (direction.MoveCondition(c)) {
                return t;
            }
        }
        throw new ArgumentException("Error, no new Position Found");
    }

    private char GoToPosition(Tuple<int, int> p) {
        if (p.Item1 == _routes[^2].Item1 && p.Item2 == _routes[^2].Item2) {
            return '.';
        }
        if (p.Item1 > 0 && p.Item2 > 0
            && p.Item1 < _fields.GetLength(0) && p.Item2 < _fields.GetLength(1)) {
            return _fields[p.Item1, p.Item2];
        }
        return '.';
    }
}