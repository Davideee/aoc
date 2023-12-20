namespace Day06.Davide;

public class Solution {
    public static void Run() {
        QuadraticSolver();
    }

    public static void BruteForce() {
        // Part 1
        // Time (T):        38     94     79     70
        // Distance d:     241   1549   1074   1091
        long counter = 1;
        counter *= Enumerable.Range(0, 38).Count(i => (38 - i) * i > 241);
        counter *= Enumerable.Range(0, 94).Count(i => (94 - i) * i > 1549);
        counter *= Enumerable.Range(0, 79).Count(i => (79 - i) * i > 1074);
        counter *= Enumerable.Range(0, 70).Count(i => (70 - i) * i > 1091);
        Console.WriteLine(counter);

        // Part2
        // 38947970
        // 241154910741091
        Console.WriteLine(Enumerable.Range(0, 38947970).Count(i => (38947970L - i) * i > 241154910741091L));
    }

    /// <summary>
    ///     Implementation with Midnight formula
    /// </summary>
    public static void QuadraticSolver() {
        // Part 1
        // Time (T):        38     94     79     70
        // Distance d:     241   1549   1074   1091
        long counter = 1;
        var i1 = MidnightFormula(-1, 38, -241,true);
        var i2 = MidnightFormula(-1, 38, -241,false);
        counter *= (long)(i2 - i1);

        i1 = MidnightFormula(-1, 94, -1549,true);
        i2 = MidnightFormula(-1, 94, -1549,false);
        counter *= (long)(i2 - i1);

        i1 = MidnightFormula(-1, 79, -1074,true);
        i2 = MidnightFormula(-1, 79, -1074,false);
        counter *= (long)(i2 - i1);

        i1 = MidnightFormula(-1, 70, -1091,true);
        i2 = MidnightFormula(-1, 70, -1091,false);
        counter *= (long)(i2 - i1);
        Console.WriteLine(counter);

        // Part2
        // 38947970
        // 241154910741091
        i1 = MidnightFormula(-1, 38947970, -241154910741091,true);
        i2 = MidnightFormula(-1, 38947970, -241154910741091,false);
        Console.WriteLine((int)(i2 - i1));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="higher"></param>
    /// <remarks>
    /// variable time (t)
    ///  Formula: (T - t) * t > d
    ///  1: t*T - t^2 > d
    ///  2: -t^2 + T*t - d  > 0 | a = -1, b = T, c = -1 * d
    ///  4: ax^2 + b*x + c > 0
    ///  i1 =(-t + sqrt(t^2 - 4 * d)) / 2
    ///  i2 =(-t - sqrt(t^2 - 4 * d)) / 2
    ///  i2 - i1 = delta
    /// </remarks>
    /// <returns></returns>
    private static double MidnightFormula(long a, long b, long c, bool higher) {
        var p = Math.Sqrt(Math.Pow(b,2) - 4 * a * c);
        p *= higher ? 1 : -1;
        return (-b + p)  / 2 * a;
    }
}