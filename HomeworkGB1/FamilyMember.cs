namespace HomeworkGB1
{
    internal class FamilyMember
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public Genders Gender { get; set; }
        public FamilyMember? Mother { get; set; }
        public FamilyMember? Father { get; set; }
        public List<FamilyMember>? Children { get; set; } = new();
        public FamilyMember()
        {
            FullName = "Неизвестный";
        }
        public FamilyMember(string fullName, int age, Genders gender)
        {
            FullName = fullName;
            Age = age;
            Gender = gender;
        }
        public FamilyMember?[] GetGrandMothersNames()
        {
            return new FamilyMember?[] { Mother?.Mother, Father?.Mother };
        }
        public FamilyMember?[] GetGrandFathersNames()
        {
            return new FamilyMember?[] { Mother?.Father, Father?.Father };
        }
        public FamilyMember? GetHusbandOrWifeName()
        {
            return Gender == Genders.Male ? Children!.FirstOrDefault()?.Mother : Children!.FirstOrDefault()?.Father;
        }
        public FamilyMember?[] GetChildren()
        {
            return Children!.ToArray();
        }
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
            var beauty = new List<string>() { "" };
            bool switcher = false;
            for (int i = 0, div = 1; i < tree.Length; i++)
            {

                beauty[0] = beauty[0].Insert(0, "  [ " + (tree[i]?.FullName ?? "Родственник неизвестен")+ " ]  ");
                if (switcher) { beauty[0] = beauty[0].Insert(0, "- - -"); }
                switcher = !switcher;
                if (i >= div - 1)
                {
                    beauty.Insert(0, ""); //here must be lines
                    beauty.Insert(0, "");
                    div = div * 2 + 1;
                }
            }
            for (int i = 0; i < beauty.Count; i++)
            {
                Console.WriteLine(beauty[i].PadLeft((Console.WindowWidth + beauty[i].Length) / 2));
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
