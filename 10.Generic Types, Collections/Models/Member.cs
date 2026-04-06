using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Generic_Types__Collections.Models
{
    internal class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }=new List<Book>();

        public Member(int id, string name, string email)
        {
            Id= id;
            Name= name;
            Email= email;
        }


        public void BorrowedBook(Book book) 
        {
            if (BorrowedBooks.Count < 3)
            {
                BorrowedBooks.Add(book);
            }
            else 
            {
                Console.WriteLine("Maksimum 3 kitab goture bilersiniz!");
            }
        }
        public void ReturnBook(int bookId) 
        {
            foreach (var book in BorrowedBooks) 
            {

                if (book.Id == bookId)
                {
                    BorrowedBooks.Remove(book);
                    Console.WriteLine($"Kitab Qaytarildi--{book.Title}");
                    break;
                }
                else 
                {
                    Console.WriteLine("Kitab tapilmadi");
                    break;
                }
            }
        }
        public void DisplayBorrowedBooks() 
        {
            if (BorrowedBooks.Count==0)
            {
                Console.WriteLine("Borc kitab yoxdur");
            }
            else 
            {
                foreach (var book in BorrowedBooks) 
                {
                    book.DisplayInfo();
                }
            }
        }


    }
}
