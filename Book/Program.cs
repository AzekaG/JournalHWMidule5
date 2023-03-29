using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Book
{


    /*Создайте приложение «Список книг для прочтения».
Приложение должно позволять добавлять книги в список, удалять книги из списка, проверять есть ли книга в
списке, и т. д. Используйте механизм свойств, перегрузки
операторов, индексаторов. */
    internal class Program

    {
        struct Book
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
          public  Book(string name, string author, int year)
            {
                this.Name = name;
                this.Author = author;
                
                this.Year = year;
            }
            public override string ToString()
            {
                return "Name :" + Name + "\nAuthor : " + Author + "\nYear : " + Year + " "; 
            }
        }
        class BookList
        {
            Book[] bookList = { };


           public void addBook( Book book)
            {   
                Book[] temp = new Book[bookList.Length+1];
                bookList.CopyTo(temp, 0);
                temp[temp.Length-1] = book;
                bookList = temp;
            }
            public void addBookList(Book[] book)
            {
                this.bookList = book;
            }
            
            public void Output()
            {
                foreach (var book in bookList)
                {
                    Console.WriteLine(book.ToString());
                    Console.WriteLine();
                }

            }
            public void DeleteBook()
            {
                Console.WriteLine("Choose book for Delete : ");
                int temp = 1;
                foreach(var book in bookList)
                {
                    Console.WriteLine(temp++ + " : " + book.Name);
                    
                }
                Book[] res = new Book[bookList.Length-1];
                temp = int.Parse(Console.ReadLine());
                for(int i = 0; i < temp-1; i++)
                {
                    res[i] = bookList[i];
                }
                for(int i = temp-1; i < res.Length; i++)
                {
                    res[i] = bookList[i+1];
                }
                bookList = res;
            }
            public void CheckBook(string name)
            {
                foreach(var book in bookList)
                {
                    if(book.Name == name) Console.WriteLine(book.ToString());
                    return;
                }
                Console.WriteLine("Not find");
            }
            public static BookList operator+(BookList a, Book book)
            {
                a.addBook(book);
                return a;
            }
          





        }
       
        static void Main(string[] args)
        {
            Book[] book = { new Book( "C++ for kettles", "Robert Kayowski", 2009 ), new Book("1984" , "Orwell" , 2000) , new Book("Kolobok" , "Nation" ,1873)};

            BookList bookList = new BookList();
            bookList.addBookList(book);
            bookList.Output();
            bookList.DeleteBook();
            bookList.Output();
            bookList.addBook(new Book("Roadside Picnic", "Strugatskie", 2021));
            bookList.Output();

        }
    }
}
