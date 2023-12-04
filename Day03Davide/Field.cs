namespace Day03Davide {
    public class Field {

        public readonly int X;
        public readonly int Y;

        public Field(int x, int y) {
            X = x;
            Y = y;
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj) {
            if (obj is Field otherField) {
                // Überprüfen, ob X und Y gleich sind
                return X == otherField.X && Y == otherField.Y;
            }
            return false;
        }
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).

        public override int GetHashCode() {
            // Ein einfacher Hash-Code, der auf den Werten von X und Y basiert
            return (X.GetHashCode() * 397) ^ Y.GetHashCode();
        }

        public static bool operator ==(Field field1, Field field2) {
            // Überladen des == Operators, um die Gleichheit zu prüfen
            if (ReferenceEquals(field1, field2)) return true;
            if (field1 is null || field2 is null) return false;
            return field1.Equals(field2);
        }

        public static bool operator !=(Field field1, Field field2) {
            // Überladen des != Operators, um die Ungleichheit zu prüfen
            return !(field1 == field2);
        }
    }
}
