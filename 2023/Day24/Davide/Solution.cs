using System.Data;
using AocShared;
namespace Day24.Davide;

public class Solution {

    public static void Run() {
        Part1();
        Part2();
    }

    public static void Part1(){
        long lowerLimit = 200000000000000;
        long higherLimit = 400000000000000;
        FileReader file = new(FileReader.DavidePath);
        List<(long[], long[])> hailstones = new();
        foreach (var line in file.Lines)
        {
            string[] lineSplit = line.Split("@");
            hailstones.Add((lineSplit[0].Split(",").Select(long.Parse).ToArray(), lineSplit[1].Split(",").Select(long.Parse).ToArray()));
        }
        long count = 0;
        
        for (int i = 0; i < hailstones.Count; i++)
        {
            for (int j = i + 1; j < hailstones.Count; j++)
            {
                count = FindIntersectionWithinLimits(hailstones[i],hailstones[j], (lowerLimit, higherLimit)) ? count + 1 : count;
            }
        }
      Console.WriteLine(count);  
    }

    static double CalculateY(double m, double b, double x)
    {
        return m * x + b;
    }

    static double FindIntersectionX(double m1, double b1, double m2, double b2)
    {
        return (b2 - b1) / (m1 - m2);
    }

    public static bool FindIntersectionWithinLimits((long[] pos, long[] vel) hailstone1, (long[] pos, long[] vel) hailstone2, (long lower, long higher) limits)
    {
        // coordinates and velocity hailstone1
        double x01 = hailstone1.pos[0];
        double y01 = hailstone1.pos[1];
        double vx1 = hailstone1.vel[0];
        double vy1 = hailstone1.vel[1];

        // coordinates and velocity hailstone2
        double x02 = hailstone2.pos[0];
        double y02 = hailstone2.pos[1];
        double vx2 = hailstone2.vel[0];
        double vy2 = hailstone2.vel[1];

        // Equation of lines: y = mx + b
        double m1 = vy1 / vx1;
        double b1 = y01 - m1 * x01;

        double m2 = vy2 / vx2;
        double b2 = y02 - m2 * x02;

        // calc intersection
        double xIntersection = FindIntersectionX(m1, b1, m2, b2);
        // check if intersectionX in the past of hailstone1 or hailstone2
        if (hailstone1.vel[0] > 0 && hailstone1.pos[0] >= xIntersection
            || hailstone1.vel[0] < 0 && hailstone1.pos[0] <= xIntersection){
                return false;
            }
        if (hailstone2.vel[0] > 0 && hailstone2.pos[0] >= xIntersection
            || hailstone2.vel[0] < 0 && hailstone2.pos[0] <= xIntersection){
                return false;
            }
        double yIntersection = CalculateY(m1, b1, xIntersection);
        // check if intersectionX in the past of hailstone1 or hailstone2
        if (hailstone1.vel[1] > 0 && hailstone1.pos[1] >= yIntersection
            || hailstone1.vel[1] < 0 && hailstone1.pos[1] <= yIntersection){
                return false;
            }
        if (hailstone2.vel[1] > 0 && hailstone2.pos[1] >= yIntersection
            || hailstone2.vel[1] < 0 && hailstone2.pos[1] <= yIntersection){
                return false;
            }
        return (limits.lower <= xIntersection && xIntersection <= limits.higher) 
            && (limits.lower <= yIntersection && yIntersection <= limits.higher);
    }

    public static void Part2(){

        // time [t]: scalar array
        // p0 [position]: vector
        // v0 [velocity]: vector
        // pi [position of hailstone i]: vector
        // vi [velocity of hailstone i]: vector
        // p0 + t[i] * v0 = pi + t[i] * vi
        // (p0 - pi) = t[i] * vi - t[i] * v0
        // (p0 - pi) = -t[i](v0 - vi) | x (v0 - vi)
        // (p0 - pi) x (v0 - vi) = -t[i](v0 - vi) x (v0 - vi) | cross product with the same vector yields 0, therefore 
        // (p0 - pi) x (v0 - vi) = 0 
        // also from a geometrical point of view this makes sense:
        // (p0 - pi) gives a new vector pointing to the intersection 
        // (v0 - vi) gives a new velocity vector and needs to be parallel to (p0 - pi)
        // t[i] can be ignored because its a scalar and affects all velocity components in the same way
        // therefore the cross product of (p0 - pi) x (v0 -vi) has to be 0 -> if not the vectors span a parallelogram in the plane
        // (p0 - pi) -> [p0x - pix, p0y - piy, p0z - piz]
        // (v0 - vi) -> [v0x - vix, v0y - viy, v0z - viz]
        // by design the data is generated that all points intersect, therefore we only need 3 data points to generate 6 equations and to find 6 parameters
        // TODO to be implemented
    }
}