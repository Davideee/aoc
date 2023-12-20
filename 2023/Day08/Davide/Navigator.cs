namespace Day08.Davide;

public class Navigator {
    private readonly int[] _navigate;
    private int _navigateCounts = 0;
    private readonly int[][] _network;
    private readonly int[] _targets;
    public int Counts = 0;
    public int Index { get; private set; }

    public Navigator(int[] navigate, int[][] network, int[] targets, int start) {
        _network = network;
        _navigate = navigate;
        _targets = targets;
        Index = start;
    }

    public long FindCountsToNextTarget() {
        long olcCounts = Counts;
        while (!_targets.Contains(Index) || olcCounts == Counts) {
            int navigate = GetNextNavigation();
            Index = _network[Index][navigate];
            Counts++;
        }
        return Counts;
    }

    private int GetNextNavigation() {
        if (_navigateCounts < _navigate.Length) {
            _navigateCounts++;
            return _navigate[_navigateCounts - 1];
        }
        _navigateCounts = 1;
        return _navigate[0];
    }
}