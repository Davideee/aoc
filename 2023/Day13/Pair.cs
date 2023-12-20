class Pair {
    public int MinValue;
    public int MaxValue;

    public Pair(int f, int s) {
        MaxValue = f > s ? f : s;
        MinValue = f > s ? s : f;
        MinValue += 1;
        MaxValue += 1;
    }
    public int Difference => Math.Abs(MinValue - MaxValue);

    /// <inheritdoc />
    public override string ToString() {
        return $"{MinValue} {MaxValue}, Diff: {Difference}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Pair other)
        {
            return this.MinValue == other.MinValue && this.MaxValue == other.MaxValue;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MinValue, MaxValue);
    }

    public static bool operator ==(Pair left, Pair right)
    {
        if (object.ReferenceEquals(left, null))
        {
            return object.ReferenceEquals(right, null);
        }
        return left.Equals(right);
    }

    public static bool operator !=(Pair left, Pair right)
    {
        return !(left == right);
    }
}