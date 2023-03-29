using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Ранее в одном из практических заданий вы создавали
класс «Журнал». Добавьте к уже созданному классу информацию
о количестве сотрудников. Выполните перегрузку
+ (для увеличения количества сотрудников на указанную
величину), — (для уменьшения количества сотрудников
на указанную величину), == (проверка на равенство количества
сотрудников), < и > (проверка на меньше или
больше количества сотрудников), != и Equals. Используйте
механизм свойств для полей класса.*/



namespace Journal
{
    internal class Program
    {

        class Journal
        {   
            public string Name { get; set; }
            public DateTime date { get; set; }
            public string Description { get; set; }
            public int AmountWorkers { get; set; }
            public Journal() { }
            public Journal(string name, DateTime date, string description, int amountWorkers)
            {
                Name = name;
                this.date = date;
                Description = description;
                AmountWorkers = amountWorkers;
            }
            public static Journal operator +(Journal a, int amount) 
            {
            return new Journal {AmountWorkers = a.AmountWorkers + amount};
            }
            public static Journal operator -(Journal a, int amount)
            {

                if (a.AmountWorkers >= amount)
                {
                    return new Journal { AmountWorkers = a.AmountWorkers - amount };
                }

                else return new Journal{AmountWorkers = 0};
            }
            public static bool operator ==(Journal a, int amount)
            {
                return a.AmountWorkers==amount;
            }
            public static bool operator !=(Journal a, int amount)
            {
                return a.AmountWorkers != amount;
            }
            public static bool operator < (Journal a, int amount)
            {
                return a.AmountWorkers < amount;
            }
            public static bool operator >(Journal a, int amount)
            {
                return a.AmountWorkers > amount;
            }
           
            public override bool Equals(object obj)
            {
                return this.ToString() == obj.ToString();
            }
            public override string ToString()
            {
                return ("Name" + Name + "  \nDate : " + date.ToLongDateString() + "  \nDescroption : " + Description + " \nAmount of workers : " + AmountWorkers);
            }
        }

        static void Main(string[] args)
        {
           



            Journal journal = new Journal("JournalMain", new DateTime(2020, 05,15 ), "Test Journal ", 50);
            Journal journal2 = journal;
            Console.WriteLine(journal2.Equals(journal));
            journal2 = journal + 50;
            Console.WriteLine(journal2.AmountWorkers);
            Console.WriteLine(journal2.Equals(journal));


          
       
        }
    }
}
