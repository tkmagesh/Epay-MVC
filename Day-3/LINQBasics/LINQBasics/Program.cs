using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQBasics
{
    class Program
    {
        static void Main(string[] args)
        {

            
            //var products = new Products();
            var products = new MyList<Product>();
            products.Add(new Product { Id = 9, Name = "Pen", Cost = 80, Units = 21 });
            products.Add(new Product { Id = 3, Name = "Hen", Cost = 89, Units = 52 });
            products.Add(new Product { Id = 2, Name = "Ten", Cost = 72, Units = 27 });
            products.Add(new Product { Id = 7, Name = "Den", Cost = 36, Units = 32 });
            products.Add(new Product { Id = 1, Name = "Len", Cost = 11, Units = 20 });

            Console.WriteLine("Initial List");
            foreach (var p in products) {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            Console.WriteLine("Sorted by Id");
            products.Sort(new CompareProductsById());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            Console.WriteLine("Sorted by Units");
            //Using Interfaces
            //products.Sort(new CompareProductsByUnits());

            //Using Delegates
            //products.Sort(new CompareProductDelegate(CompareProductsByUnits));
            //products.Sort(CompareProductsByUnits);
            
            //products.Sort(delegate(Product p1, Product p2)
            //{
            //    if (p1.Id > p2.Id) return 1;
            //    if (p1.Id == p2.Id) return 0;
            //    return -1;
            //});
            products.Sort((p1,p2) =>
            {
                if (p1.Id > p2.Id) return 1;
                if (p1.Id == p2.Id) return 0;
                return -1;
            });
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            Console.WriteLine("All costly products");
            var costlyProducts = products.Filter((p) => {
                return p.Cost > 50;
            });
            foreach (var product in costlyProducts)
            {
                Console.WriteLine(product);
            }
            Console.ReadLine();
        }

        //public static int CompareProductsByUnits(Product p1, Product p2)
        //{
        //    if (p1.Id > p2.Id) return 1;
        //    if (p1.Id == p2.Id) return 0;
        //    return -1;
        //}

       
    }

    public class CompareProductsById : ICompareItems<Product>{
        public int Compare(Product p1, Product p2) {
            if (p1.Id > p2.Id) return 1;
            if (p1.Id == p2.Id) return 0;
            return -1;
        }
    }

    public class CompareProductsByUnits : ICompareProducts
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Units > p2.Units) return 1;
            if (p1.Units == p2.Units) return 0;
            return -1;
        }
    }

    public interface ICompareProducts {
        int Compare(Product p1, Product p2);
    }

    public interface ICompareItems<T>
    {
        int Compare(T p1, T p2);
    }

    

     //public delegate int CompareProductDelegate(Product p1, Product p2);
    //public delegate int CompareItemDelegate<T>(T p1, T p2);

     //public delegate bool ProductFilterCriteriaDelegate(Product p);
     // public delegate bool ItemFilterCriteriaDelegate<T>(T item);

    public class MyList<T>: IEnumerable, IEnumerator {
        private ArrayList list = new ArrayList();

        public void Add(T item) {
            list.Add(item);
        }

        public int Count {
            get { return list.Count; }
        }

        //public IEnumerable Filter(ItemFilterCriteriaDelegate<T> filterCriteria)
        //public IEnumerable Filter(Func<T,bool> filterCriteria)
        public IEnumerable Filter(Predicate<T> filterCriteria)
        {
            foreach (var item in list) {
                var tItem = (T)item;
                if (filterCriteria(tItem))
                    yield return item;
            }
        }

        public void Sort(ICompareItems<T> itemComparer)
        { 
            for(var i=0;i<list.Count-1;i++)
                for (var j = i + 1; j < list.Count; j++) {
                    var left = (T)list[i];
                    var right = (T)list[j];
                    if (itemComparer.Compare(left,right) > 0) {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
        }

       

        //public void Sort(CompareItemDelegate<T> compareProducts)
        public void Sort(Func<T,T,int> compareProducts)
        {
            for (var i = 0; i < list.Count - 1; i++)
                for (var j = i + 1; j < list.Count; j++)
                {
                    var left = (T)list[i];
                    var right = (T)list[j];
                    if (compareProducts(left, right) > 0)
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
        }

        public T this[int index]
        {
            get {
                return (T)list[index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
        private int index = -1;
        public object Current
        {
            get { return (T) list[index] ; }
        }

        public bool MoveNext()
        {
            index++;
            if (index >= list.Count) {
                Reset();
                return false;
            }
            return true;

        }

        public void Reset()
        {
            index = -1;
        }
    }

    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal Cost { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Id, Name, Cost, Units);
        }
    }
}
