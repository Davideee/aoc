namespace Day03Davide {
    public class Field {
        private readonly int _x;
        private readonly int _y;

        public Field(int x, int y) {
            _x = x;
            _y = y;
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj) {
            if (obj is Field otherField) {
                // Überprüfen, ob X und Y gleich sind
                return _x == otherField._x && _y == otherField._y;
            }
            return false;
        }
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).

        public override int GetHashCode() {
            // Ein einfacher Hash-Code, der auf den Werten von X und Y basiert
            return (_x.GetHashCode() * 397) ^ _y.GetHashCode();
        }

        public static bool operator ==(Field field1, Field field2) {
            // Überladen des == Operators, um die Gleichheit zu prüfen
            if (ReferenceEquals(field1, field2)) {
                return true;
            }

            if (field1 is null || field2 is null) {
                return false;
            }

            return field1.Equals(field2);
        }

        public static bool operator !=(Field field1, Field field2) {
            // Überladen des != Operators, um die Ungleichheit zu prüfen
            return !(field1 == field2);
        }
    }
}
