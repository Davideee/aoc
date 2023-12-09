using System.Diagnostics;
using AocShared;

namespace Day08;

class Program {
    private static int[] _navigate;
    private static int _navigateCounts = 0;

    static void Main() {
        Part1();
        // Part2BruteForce();
        Part2Lcm();
    }


    private static void Part1() {
        Stopwatch stopwatch = new();
        stopwatch.Start();

        FileReader file = new();
        string[] nodes = CreateNodes(file);

        // Create network array
        int[][] network = CreateNetwork(nodes, file);
        // Get Start and End Node
        int start = Array.IndexOf(nodes, "AAA");
        int target = Array.IndexOf(nodes, "ZZZ");
        _navigate = file.Lines[0].Select(c => c == 'L' ? 0 : 1).ToArray();

        int index = start;
        int counts = 0;
        while (index != target) {
            int navigate = GetNextNavigation();
            index = network[index][navigate];
            counts++;
        }
        stopwatch.Stop();
        Console.WriteLine($"Part 1: {counts}");
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
    }

    private static void Part2BruteForce() {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        FileReader file = new();

        List<int> startNodes = new();
        List<int> targetNodes = new();
        // Create node array
        string[] nodes = file.Lines[2..];
        for (int i = 0; i < nodes.Length; i++) {
            nodes[i] = nodes[i][..3];
            if (nodes[i][2] == 'A') {
                startNodes.Add(i);
            } else if (nodes[i][2] == 'Z') {
                targetNodes.Add(i);
            }
        }

        int[][] network = CreateNetwork(nodes, file);

        int[] navigate = file.Lines[0].Select(c => c == 'L' ? 0 : 1).ToArray();
        List<Navigator> navigators = new();
        foreach (var startNode in startNodes) {
            navigators.Add(new Navigator(navigate, network,targetNodes.ToArray(), startNode));
        }

        long maxCount = navigators.First().FindCountsToNextTarget();
        long lastMaxCount = 0;
        while (navigators.Select(n => n.Counts).Distinct().Count() > 1)
        {
            Parallel.ForEach(navigators, navigator =>
            {
                if (navigator.Counts != maxCount)
                {
                    long newCount = navigator.FindCountsToNextTarget();
                    maxCount = newCount > maxCount ? newCount : maxCount;
                }
            });
        }

        var a = navigators.Select(n => n.Counts).Distinct().Count();
        stopwatch.Stop();
        Console.WriteLine($"Part 2: {maxCount}");
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
    }

    private static void Part2Lcm() {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        FileReader file = new();

        List<int> startNodes = new();
        List<int> targetNodes = new();
        // Create node array
        string[] nodes = file.Lines[2..];
        for (int i = 0; i < nodes.Length; i++) {
            nodes[i] = nodes[i][..3];
            if (nodes[i][2] == 'A') {
                startNodes.Add(i);
            } else if (nodes[i][2] == 'Z') {
                targetNodes.Add(i);
            }
        }

        int[][] network = CreateNetwork(nodes, file);

        int[] navigate = file.Lines[0].Select(c => c == 'L' ? 0 : 1).ToArray();
        long[] firstCycleCounts = new long[startNodes.Count];
        long lcm = 0;
        for (int i = 0; i < firstCycleCounts.Length; i++) {
            long count = new Navigator(navigate, network,targetNodes.ToArray(), startNodes[i]).FindCountsToNextTarget();
            lcm = i == 0 ? count : Lcm(lcm, count);
        }
        Console.WriteLine($"Part 2: {lcm}");
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
    }

    private static int GetNextNavigation() {
        if (_navigateCounts < _navigate.Length) {
            _navigateCounts++;
            return _navigate[_navigateCounts - 1];
        }
        _navigateCounts = 1;
        return _navigate[0];
    }

    private static string[] CreateNodes(FileReader file) {
        // Create node array
        string[] nodes = file.Lines[2..];
        for (int i = 0; i < nodes.Length; i++) {
            nodes[i] = nodes[i][..3];
        }

        return nodes;
    }

    private static int[][] CreateNetwork(string[] nodes, FileReader file) {
        // Create network array
        int[][] network = new int[nodes.Length][];
        for (int i = 0; i < nodes.Length; i++) {
            string[] nextNodes = file.Lines[i + 2][7..15].Split(",").Select(s => s.Trim()).ToArray();
            var nodeLeft = Array.IndexOf(nodes, nextNodes[0]);
            var nodeRight = Array.IndexOf(nodes, nextNodes[1]);
            network[i] = new[] { nodeLeft, nodeRight };
        }

        return network;
    }

    // Function to calculate GCD (Greatest Common Divisor)
    private static long Gcd(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Function to calculate LCM (Least Common Multiple)
    private static long Lcm(long a, long b)
    {
        return (a / Gcd(a, b)) * b;
    }
}
