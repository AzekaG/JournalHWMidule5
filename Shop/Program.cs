using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Ранее в одном из практических заданий вы создавали класс «Магазин». Добавьте к уже созданному классу
информацию о площади магазина. Выполните перегрузку + (для увеличения площади магазина на указанную
величину), — (для уменьшения площади магазина на
указанную величину), == (проверка на равенство площадей магазинов), < и > (проверка на меньше или больше
площади магазина), != и Equals. Используйте механизм
свойств для полей класса*/

namespace Shop
{
    internal class Program
    {


        class Shop
        {
            public Shop() { }
            public Shop(string name , string description , int square , int amountWorkers) 
            {
                this.Name = name;
                this.Description = description;
                this.Square = square;
                this.AmountWorkers = amountWorkers;
            }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Square { get; set; }
            public int AmountWorkers { get; set; }
            public override string ToString()
            {
                return ("Name : " + Name + "/nDescription : " + Description + "\nSquare : " + Square + "\nAmount of workers : " + AmountWorkers);
            }
            public override bool Equals(object obj)
            {
                return this.ToString()==obj.ToString();
            }
            public static Shop operator+(Shop a , int square)
            {
                return new Shop { Square = a.Square + square };
            }
            public static Shop operator -(Shop a, int square)
            {
                if (a.Square >= square)  return new Shop { Square = a.Square - square };
                else return new Shop { Square = 0 };
            }
            public static bool operator ==(Shop a, Shop b)
            {
                return a.Square == b.Square;
            }
            public static bool operator !=(Shop a, Shop b)
            {
                return a.Square != b.Square;
            }
            public static bool operator <(Shop a, Shop b)
            {
                return a.Square < b.Square;
            }
            public static bool operator >(Shop a, Shop b)
            {
                return a.Square > b.Square;
            }






        }
        static void Main(string[] args)
        {

            Shop shop = new Shop("Pivasov", "Beer Shop", 150, 10);
            Shop shop1 = shop;
            Console.WriteLine(shop1.Equals(shop));
            shop1 = shop1 + 50;
            Console.WriteLine(shop1.Equals(shop));
            Console.WriteLine(shop1==shop);
            Console.WriteLine(shop1<shop);
            Console.WriteLine(shop1!=shop);
        }
    }
}
