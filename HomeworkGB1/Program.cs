namespace HomeworkGB1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            var GrandPa1 = new FamilyMember("Иванов Иван Иванович", 67, Genders.Male);
            var GrandPa2 = new FamilyMember("Петров Петр Петрович", 65, Genders.Male); ;
            var GrandMa1 = new FamilyMember("Иванова Ольга Федоровна", 65, Genders.Female);
            var GrandMa2 = new FamilyMember("Петрова Мария Владимировна", 64, Genders.Female);
            var Mom = new FamilyMember("Иванова Оксана Петровна", 43, Genders.Female) { Mother = GrandMa2, Father = GrandPa2 };
            var Dad = new FamilyMember("Иванов Сергей Иванович", 45, Genders.Male) { Mother = GrandMa1, Father = GrandPa1 };
            var Son = new FamilyMember("Иванов Алексей Сергеевич", 21, Genders.Male) { Mother = Mom, Father = Dad };
            var Daughter = new FamilyMember("Иванова Анастасия Сергеевна", 16, Genders.Female) { Mother = Mom, Father = Dad };

            GrandPa1.Children!.Add(Dad);
            GrandMa1.Children = GrandPa1.Children;

            GrandPa2.Children!.Add(Mom);
            GrandMa2.Children = GrandPa2.Children;

            Dad.Children!.Add(Son);
            Dad.Children.Add(Daughter);
            Mom.Children = Dad.Children;

            var GrandMothersNames = Son.GetGrandMothersNames();
            FamilyMember.PrintNames("Имена бабушек сына: ", GrandMothersNames);

            var GrandFathersNames = Daughter.GetGrandFathersNames();
            FamilyMember.PrintNames("Имена дедушек дочери: ", GrandFathersNames);

            Console.WriteLine("Муж мамы: " + Mom.GetHusbandOrWifeName()?.FullName + "\n");

            Console.WriteLine("Жена отца: " + Dad.GetHusbandOrWifeName()?.FullName + "\n");

            FamilyMember.PrintNames("Имена детей матери: ", Mom.GetChildren());

            PrintSeparationLine();

            FamilyMember.PrintNamesBeautifully("Генеалогическое древо для сына: ", Son.GetAllTree());

            PrintSeparationLine();

            FamilyMember.PrintNamesBeautifully("Генеалогическое древо для дочери: ", Daughter.GetAllTree());

            PrintSeparationLine();

            FamilyMember.PrintNamesBeautifully("Генеалогическое древо для матери: ", Mom.GetAllTree());

            PrintSeparationLine();

            FamilyMember.PrintNamesBeautifully("Генеалогическое древо для отца: ", Dad.GetAllTree());

            PrintSeparationLine();

            Console.ReadKey(true);
        }

        static void PrintSeparationLine()
        {
            Console.WriteLine("\n" + new string('-', Console.WindowWidth - 2) + "\n");
        }
    }
}
