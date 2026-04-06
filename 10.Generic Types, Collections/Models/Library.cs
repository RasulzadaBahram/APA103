using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Generic_Types__Collections.Models
{
    internal class Library<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public string Name { get; set; }

        public Library(string name)
        {
            Name = name;
        }

        public void Add(T item)
        {
            Items.Add(item);
            Console.WriteLine("Elave olundu");
        }
        public void Remove(T item)
        {
            Items.Remove(item);
            Console.WriteLine("Silindi");
        }
        public List<T> GetAll()
        {
            return Items;
        }
        public int Count()
        {
            return Items.Count;
        }
        public T FindByIndex(int index)
        {
            if (index >= 0 && index <= Items.Count)
            {
                return Items[index];
            }
            return default;
        }
    }
}
