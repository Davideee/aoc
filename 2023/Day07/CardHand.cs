namespace Day07;

public class CardHand : IComparable<CardHand> {

    private Dictionary<char, int> _charToIntMapping = new() {
        {'A', 14},
        {'K', 13},
        {'Q', 12},
        {'J', 11},
        {'T', 10},
        {'9', 9},
        {'8', 8},
        {'7', 7},
        {'6', 6},
        {'5', 5},
        {'4', 4},
        {'3', 3},
        {'2', 2},
        {'1', 1},
    };

    private readonly string _rawHand;
    public readonly int Bid;
    public TypeEnum Type = 0;
    private readonly List<int> _hand = new();
    private Dictionary<char,int> _sortedDistinctValues = new();
    private Dictionary<char,int> _sortedDistinctValuesWithoutJokers = new();


    public CardHand(string hand, int bid, bool part2) {
        _rawHand = hand;
        Bid = bid;
        if (part2){
            _charToIntMapping['J'] = 0;
        }

        MapHand();
        if (_sortedDistinctValues.ContainsKey('J') && part2) {
            _sortedDistinctValuesWithoutJokers = new Dictionary<char, int>(_sortedDistinctValues);
            _sortedDistinctValuesWithoutJokers.Remove('J');
            MapWithJoker(_sortedDistinctValues['J']);
        } else {
            MapWithoutJoker();
        }
    }

    private void MapHand() {
        List<char> hand = _rawHand.ToList();
        // Anzahl pro Eintrag zählen
        var distinctValues = hand.GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());
        _sortedDistinctValues = distinctValues
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var c in hand) {
            _hand.Add(_charToIntMapping[c]);
        }
    }

    private void MapWithJoker(int jokers) {
        switch (_sortedDistinctValuesWithoutJokers.Count()) {
            // JJJJJ
            case 0:
                Type = TypeEnum.FiveKind;
                break;
            // JJJJ A
            // JJJ AA
            // JJ AAA
            case 1:
                Type = TypeEnum.FiveKind;
                break;
            // J AAAQ -> FourKind
            // JJ AAQ -> FourKind
            // J AAQQ -> FullHouse
            case 2:
                if (_sortedDistinctValuesWithoutJokers.First().Value == 2 && jokers == 1) {
                    Type = TypeEnum.FullHouse;
                    break;
                }
                Type = TypeEnum.FourKind;
                break;
            // J AAQ2
            // JJ 234 -> ThreeKind
            // JJ TAAQ -> FourKind
            case 3:
                Type = TypeEnum.ThreeKind;
                break;
            // J AQKT
            case 4:
                Type = TypeEnum.Pair;
                break;
        }
    }

    private void MapWithoutJoker() {
        switch (_sortedDistinctValues.Count()) {
            case 1:
                Type = TypeEnum.FiveKind;
                break;
            case 2:
                if (_sortedDistinctValues.First().Value == 4) {
                    Type = TypeEnum.FourKind;
                    break;
                }
                Type = TypeEnum.FullHouse;
                break;
            case 3:
                if (_sortedDistinctValues.First().Value == 3) {
                    Type = TypeEnum.ThreeKind;
                    break;
                }
                Type = TypeEnum.DoublePair;
                break;
            case 4:
                Type = TypeEnum.Pair;
                break;
            case 5:
                Type = TypeEnum.HighCard;
                break;
        }
    }

    public int CompareTo(CardHand otherHand)
    {
        int compare1 = Type.CompareTo(otherHand.Type);
        if (compare1 != 0)
        {
            return compare1;
        }

        for (int i = 0; i < _hand.Count; i++) {
            int wert2 = _hand[i].CompareTo(otherHand._hand[i]);
            if (wert2 != 0) {
                return wert2;
            }
        }
        return 0;
    }

    // Implementieren Sie die Vergleichsoperatoren
    public static bool operator >(CardHand obj1, CardHand obj2)
    {
        return obj1.CompareTo(obj2) > 0;
    }

    public static bool operator <(CardHand obj1, CardHand obj2)
    {
        return obj1.CompareTo(obj2) < 0;
    }

    // Überschreiben Sie die Methode GetHashCode, wenn Sie Equals überschreiben
    public override int GetHashCode()
    {
        return int.Parse(string.Join("", _hand));
    }

    /// <inheritdoc />
    public override string ToString() {
        return $"{nameof(_rawHand)}:{_rawHand}, {nameof(Type)}:{Type}";
    }
}