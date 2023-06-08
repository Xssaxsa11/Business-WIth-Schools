namespace Education
{
    public class Program
    {
        public delegate void NewWeek();
        static void Main(string[] args)
        {
            NewWeek newWeek = () =>
            {
                Console.WriteLine("Начинаем учебу");
            };
            
            Finances finances = new Finances();
            newWeek += finances.Pay;
            bool helper = true;
            while(helper)
            {
                Console.WriteLine("Нажмите 1 чтобы добавить здание\nНажмите 2 чтобы посмотреть статистику финансов" +
                    "\nНажмите 3 чтобы посмотреть статистику определенного здания\n Нажмите 4 чтобы посмотреть все здания\n" +
                    "Намжите остальные чтобы провести неделю");
                string answer = Console.ReadLine();
                if(answer == "1")
                {
                    Console.WriteLine("Введите Имя вашего заведения");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите адрес вашего заведения");
                    string street = Console.ReadLine();
                    Console.WriteLine("Введите кол-во занятий (не больше 10)");
                    int counter  = int.Parse(Console.ReadLine());
                    var building  = new Buildings(name, street, counter);
                    finances.AddBuildings(building);
                }
                else if (answer == "2")
                {
                    if (!finances.StartedService)
                    {
                        Console.WriteLine("Извините, вы еще не начали свою фин. компанию");
                    }
                    else
                    {
                        Console.WriteLine(finances);
                    }
                }
                else if (answer == "3")
                {
                    Console.WriteLine("Введите номер в списке здания");
                    int num = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine(finances[num]);
                }
                else if (answer == "4")
                {
                    foreach (var item in finances)
                    {
                        Console.WriteLine($"Имя: {item.Name}, Улица: {item.Street}");
                    }
                }
                else
                {
                    Console.WriteLine("ВВедите сколько раз вы хотите провести неделю");
                    int count = int.Parse(Console.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        Learn(finances);
                    }
                }
            }
        }
        public static void Learn(Finances finances)
        {
            Random r = new Random();
            foreach (var item in finances)
            {
                int ran = r.Next(1,11);
                if (ran < 5)
                {
                    item.Salaries += r.Next(1, 20);
                    item.AVGSkills -= r.Next(0, 2);
                }
                else
                {
                    item.AVGSkills+=r.Next(0, 5);
                    item.Salaries -= r.Next(1, 20);
                }
            }
            finances.UpdateFinances();
            finances.Pay();
        }
    }
    
}