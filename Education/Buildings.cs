using System;

namespace Education
{
    public class Buildings
    {
        
        public string Name { get; }
        public string Street { get; }
        public int Programs { get; set; }
        public int AVGSkills { get; set; }
        public int Salaries { get; set; }


        public Buildings( string name, string street, int programs)
        {
            if (programs >= 1 && programs <= 10)
            {
                Programs = programs;
                
                Name = name;
                Street = street;
                AVGSkills = 20;//надо умножать на 60
                Salaries = 1000;
            }
            else
            {
                
                throw new Exception("Ошибка при вызове");
            }
            
            
        }
        public override string ToString()
        {
            return $"Имя: {Name}\nУлица: {Street}\nКол-во программ: {Programs}\nСкиллы: {AVGSkills*60}\nЗарплаты: {Salaries}";
        }
    }
}
