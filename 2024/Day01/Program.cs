using AocShared;

var fr = new FileReader();
var list1 = new List<int>();
var list2 = new List<int>();
foreach (var line in fr.Lines) {
    var splitted = line.Split("   "); 
    list1.Add(int.Parse(splitted[0].Trim()));
    list2.Add(int.Parse(splitted[1].Trim()));
}

list1.Sort();
list2.Sort();
var sum = 0;
for (int i = 0; i < list1.Count; i++) {
    sum+=Math.Abs(list1[i] - list2[i]);
}
Console.WriteLine(sum);