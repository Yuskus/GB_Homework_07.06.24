namespace HomeworkGB1
{
    internal class FamilyMember
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public Genders Gender { get; set; }
        public FamilyMember? Mother { get; set; }
        public FamilyMember? Father { get; set; }
        public FamilyMember? Partner { get; set; }
        public List<FamilyMember>? Children { get; set; } = new();
        public FamilyMember()
        {
            FullName = "Неизвестный";
        }
        public FamilyMember(string fullName, int age, Genders gender, FamilyMember? mother = null, FamilyMember? father = null)
        {
            FullName = fullName;
            Age = age;
            Gender = gender;
            Mother = mother;
            Father = father;
            mother?.Children!.Add(this);
            father?.Children!.Add(this);
            if (mother != null && father != null)
            {
                Mother!.Partner = father;
                Father!.Partner = mother;
            }
        }
        public FamilyMember?[] GetGrandMothersNames() => [Mother?.Mother, Father?.Mother];
        public FamilyMember?[] GetGrandFathersNames() => [Mother?.Father, Father?.Father];
        public FamilyMember? GetPartnerName() => Partner;
        public FamilyMember?[] GetChildren() => Children!.ToArray();
        public FamilyMember?[] GetAllTree()
        {
            List<FamilyMember>? familyTree = new() { this };
            for (int i = 0; i < familyTree.Count; i++)
            {
                if (familyTree[i]?.Mother != null) familyTree.Add(familyTree[i].Mother!);
                if (familyTree[i]?.Father != null) familyTree.Add(familyTree[i].Father!);
            }
            return familyTree.ToArray();
        }
        public static void PrintNamesBeautifully(string enterText, FamilyMember?[] tree)
        {
            Console.WriteLine(enterText);
            var beautyPrint = new List<string>() { "" };
            bool married = false;
            for (int i = 0, div = 1; i < tree.Length; i++)
            {

                beautyPrint[0] = beautyPrint[0].Insert(0, "  [ " + (tree[i]?.FullName ?? "Родственник неизвестен")+ " ]  ");
                if (married) { beautyPrint[0] = beautyPrint[0].Insert(0, "- - -"); }
                married = !married;
                if (i >= div - 1 && i != tree.Length - 1)
                {
                    beautyPrint.Insert(0, "\\" + new string(' ', beautyPrint[0].Length / 2) + "/"); //here must be lines
                    beautyPrint.Insert(0, "");
                    div = div * 2 + 1;
                }
            }
            for (int i = 0; i < beautyPrint.Count; i++)
            {
                Console.WriteLine(beautyPrint[i].PadLeft((Console.WindowWidth + beautyPrint[i].Length) / 2));
            }
        }

        public static void PrintNames(string enterText, FamilyMember?[] members)
        {
            Console.WriteLine(enterText);
            foreach (var member in members) Console.WriteLine(member?.FullName ?? "Родственник неизвестен");
            Console.WriteLine();
        }
    }
    public enum Genders { Male, Female }
}
