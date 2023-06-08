using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education
{
    public class Finances:IEnumerable<Buildings>
    {
        public bool StartedService { get; set; } = false;
        public int CounterOfBuildings { get; set; }
        public int Budget { get; set; } = 10000; 
        public int OutCome { get; set; }
        public int InCome { get; set; }
        public List<Buildings> Buildings { get; set; }
        public Buildings this[int num]
        {
            get
            {
                if (num >= 0 && num < Buildings.Count)
                {
                    return Buildings[num];
                }
                else
                {
                    throw new Exception("Ошибка в вводе");
                }
            }
        }
        public Finances()
        {
            Buildings = new List<Buildings>();
            OutCome = 0;
            InCome = 0;
            StartedService = true;
        }
        public void AddBuildings(Buildings buildings)
        {
            Buildings.Add(buildings);
            CounterOfBuildings++;
            UpdateFinances();
        }
        public void UpdateFinances()
        {
            foreach (var building in Buildings)
            {
                OutCome += building.Salaries;
                InCome += building.AVGSkills *60;
            }
        }
        public void Pay()
        {
            Budget = Budget + InCome - OutCome;
            if (Budget < 0)
            {
                Console.WriteLine("Вы обьявлены банкротом, нажмите enter чтобы покинуть страну");
                Console.ReadLine();
                Console.WriteLine(Buildings[0]);

            }
        }
        public override string ToString()
        {
            return $"Кол-во заведений: {CounterOfBuildings}\nБюджет: {Budget}\nДоход: {InCome}\nТраты: {OutCome}";
        }

        public IEnumerator<Buildings> GetEnumerator()
        {
            return Buildings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
