using _10.Generic_Types__Collections.Models;

namespace _10.Generic_Types__Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new(1, "Martin Eden", "Jack London", 1909, 400);
            Book book2 = new(2, "1984", "George Orwell", 1949, 328);
            Book book3 = new(3, "Animal Farm", "George Orwell", 1945, 112);
            Book book4 = new(4, "Ağ Gemi", "Cingiz Aytmatov", 1970, 200);
            Book book5 = new(5, "Qırıq Budaq", "Elçin", 1998, 350);

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();
            Console.WriteLine("------------------------------------------------------");


            Library<Book> library = new("Milli Kitabxana");
            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);

            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine(library.Count());

            Console.WriteLine("------------------------------------------------------");

            foreach (Book book in library.GetAll())
            {
                book.DisplayInfo();
            }

            Console.WriteLine("------------------------------------------------------");

            library.FindByIndex(0).DisplayInfo();
            library.FindByIndex(2).DisplayInfo();

            Console.WriteLine("------------------------------------------------------");





            List<Member> members = new List<Member>()
            {
                new Member(1,"Ali Məmmədov","ali@mail.com"),
                new Member(2,"Leyla Həsənova","leyla@mail.com"),
                new Member(3,"Vüqar Əliyev","vuqar@mail.com"),
            };

            Member member1 = members[0];
            member1.BorrowedBook(book1);
            member1.BorrowedBook(book2);

            member1.DisplayBorrowedBooks();

            Console.WriteLine("------------------------------------------------------");

            member1.ReturnBook(0);

            Console.WriteLine("------------------------------------------------------");

            member1.DisplayBorrowedBooks();

            Console.WriteLine("------------------------------------------------------");

            member1.BorrowedBook(book3);

            member1.DisplayBorrowedBooks();

            member1.BorrowedBook(book4);
            member1.BorrowedBook(book5);

            //Member member2 = members[1];
            //Member member3 = members[2];

            BookManager bookManager = new();
            bookManager.AddBook(book1);
            bookManager.AddBook(book2);
            bookManager.AddBook(book3);
            bookManager.AddBook(book4);
            bookManager.AddBook(book5);

            //bookManager.



        }
    }
}
