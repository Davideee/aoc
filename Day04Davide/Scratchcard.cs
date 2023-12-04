namespace Day04Davide; 

public class Scratchcard {
    private readonly string _line;
    private string _numberGroups;
    public int Id;
    private const string Card = "Card";
    private List<int> _group1 = new();
    private List<int> _group2 = new();
    private int _dublicatesCount = 0;

    public Scratchcard(string line) {
        _line = line;
        GetId();
        ParseGroups();
        CountDublicates();
    }

    private void GetId() {
        int colonIndex = _line.IndexOf(":", StringComparison.InvariantCulture);
        string cardString = _line.Substring(Card.Length, colonIndex - Card.Length).Trim();
        Id = int.Parse(cardString);
        _numberGroups = _line.Substring(colonIndex + 1);
    }

    private void ParseGroups() {
        var groups = _numberGroups.Trim().Split("|");
        _group1 = groups[0].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList();
        _group2 = groups[1].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList();
    }

    private void CountDublicates() {
        if (_group1.Count != 0 && _group1.Count != 0) {
            _dublicatesCount = _group1.Intersect(_group2).Count();
        } else {
            throw new ArgumentException("Fehler: Keine Gruppen erstellt.");
        }
    }

    public double GetCountTask1() {
        return _dublicatesCount == 0 ? 0 : Math.Pow(2, _dublicatesCount - 1);
    }

    public List<int> GetCopiedIds() {
        List<int> idList = new();
        if (_dublicatesCount > 0) {
            for (int i = Id + 1; i < Id + _dublicatesCount + 1; i++) {
                idList.Add(i);
            }
        }
        return idList;

    }
}