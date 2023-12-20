
namespace Day15.Davide;

public class Box {
        public int BoxId;
        public List<Lens> Lenses = new();
        public Box(int box){
            BoxId = box;
        }

        public void CreateOrUpdateLens(Lens newLens){
            Lens oldLens = Lenses.FirstOrDefault(s => newLens.Label == s.Label);
            if (oldLens == null){
                Lenses.Add(newLens);
            } else {
                oldLens.FocusLength = newLens.FocusLength;
            }
        }

        public void RemoveLens(string label){
            Lens lens = Lenses.Find(l => l.Label == label);
            if (lens != null)
            {
                Lenses.Remove(lens);
            }
        }

        public long GetCount => Lenses.Select((l, index) => (index + 1) * l.FocusLength * (BoxId + 1)).Sum();
    }