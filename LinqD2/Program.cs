using L2O___D09;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace LinqD2
{
    class CustomComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }

       
    }
    class CustomComparer2 : IEqualityComparer<string>
    {
       

        public bool Equals(string? x, string? y)
        {
            var c = x.Select(w => w).OrderBy(w => w).ToList();
            var c2 = y.Select(w => w).OrderBy(w => w).ToList();

            for (int i = 0; i < c.Count; i++)
            {
                if (c[i] != c2[i])
                    return false;
            }


            return true;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.GetHashCode();
        }
    }
    internal class Program
    {
        private const string Path = "C:/Users/medod/Downloads/DOT NET/LINQ day 2/Assignment files/dictionary_english.txt";

        static void Main(string[] args)
        {
            var products = ListGenerators.ProductList;
            var customers = ListGenerators.CustomerList;
            var NumOfChar2 = File
               .ReadAllLines(Path);

            #region Restriction Operators


            //1

            //var ProductOutOfStock = products.Where(x => x.UnitsInStock == 0).ToList();
            //foreach (var item in ProductOutOfStock)
            //{
            //    Console.WriteLine(item);
            //}


            //2

            //var ProductInStock = products.Where(p => p.UnitPrice > 3 && p.UnitsInStock > 0).ToList();

            //foreach (var item in ProductInStock)
            //{
            //    Console.WriteLine(item);
            //}

            //3

            //var ProductDigits = products
            //    .Where(p => p.ProductName.Length < p.UnitsInStock)
            //    .ToList();

            //foreach (var item in ProductDigits)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Element Operators 

            // 1 
            //var FirstProductOut = products.FirstOrDefault(p => p.UnitsInStock == 0);

            //Console.WriteLine(FirstProductOut);

            // 2

            //var FirstProductGreterThan1000 = products.FirstOrDefault(p => p.UnitPrice > 1000);

            //Console.WriteLine(FirstProductGreterThan1000);

            // 3

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var SecondNumber = Arr.Where(a => a > 5).ElementAtOrDefault(1);
            //var SecondNumber = Arr.Where(a => a > 5).Skip(1).FirstOrDefault();

            //Console.WriteLine(SecondNumber);

            #endregion
            #region Set Operators

            // 1 

            var UniQuecategories = products.Select(p => p.Category).Distinct().ToList();

            foreach (var category in UniQuecategories)
            {
                Console.WriteLine(category);
            }

            // 2 

            //var UniqueProNameAndCustomerName = products.Select(p => p.ProductName[0])
            //    .Union(customers
            //    .Select(c => c.CompanyName[0])).OrderBy(x => x);

            //foreach (var item in UniqueProNameAndCustomerName)
            //{
            //    Console.WriteLine(item);
            //}

            // 3 

            //var FirstLitterfromBoth = products.Select(p=> p.ProductName[0])
            //    .Intersect(customers.Select(c => c.CompanyName[0]));

            //foreach(var item in FirstLitterfromBoth)
            //{
            //    Console.WriteLine(item);
            //}

            // 4

            //var FirstLitterInProductNotInCustomer = products.Select(p => p.ProductName[0])
            //    .Except(customers.Select(c => c.CompanyName[0])).ToList();

            //foreach(var item in FirstLitterInProductNotInCustomer)
            //{
            //    Console.WriteLine(item);
            //}

            // 5
            // we could use substring for this but i want to use take last
            //var LastThreeCharsOfBoth = products
            //    .Select(p => string.Join("", p.ProductName.Select(c => c).TakeLast(3)))
            //    .Concat(customers
            //    .Select(c => string.Join("", c.CompanyName.Select(ch => ch).TakeLast(3)))).ToList();

            //foreach (var item in LastThreeCharsOfBoth)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region aggregation operators
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // 1 

            //var OddNumbers = Arr.Count(a => (a & 1)== 1);
            //Console.WriteLine(OddNumbers);

            // 2 

            //var CustomerWithNumberOfOrders = customers.Select(c => new
            //{
            //    c.CompanyName,
            //    c.Orders
            //}).ToList();
            //foreach (var item in CustomerWithNumberOfOrders)
            //{
            //    Console.WriteLine($"{item.CompanyName} has {item.Orders.Length} orders");
            //}

            // 3

            //var CatigoriesAndProducts = products.GroupBy(p => p.Category)
            //    .Select(g => new
            //    {
            //        category = g.Key,
            //        productCount = g.Count(),
            //    });

            //foreach(var item in CatigoriesAndProducts)
            //{
            //    Console.WriteLine($"{item.category} has {item.productCount} products");
            //}

            // 4 
            //int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var total = Arr2.Sum(x=> x);
            //Console.WriteLine(total);

            // 5

            //var NumOfChar = File.ReadAllText("C:/Users/medod/Downloads/DOT NET/LINQ day 2/Assignment files/dictionary_english.txt").Count();

            //Console.WriteLine(NumOfChar);


            // 6 
            //var totalUnitsInStock = products
            //    .GroupBy(p=>p.Category)
            //    .Select(g=> new
            //    {
            //        category = g.Key,
            //        totalUnitsInStock = g.Sum(p=> p.UnitsInStock)
            //    });

            //foreach(var item in totalUnitsInStock)
            //{
            //    Console.WriteLine($"{item.category} has {item.totalUnitsInStock} units in stock");
            //}

            // 7 


            //var result = NumOfChar2.Min(x => x.Length);

            //Console.WriteLine(result);

            // 8 

            //var cheapPrice = products.GroupBy(p => p.Category)
            //    .Select(p => new
            //    {
            //        category = p.Key,
            //        CheapPrice = p.Min(p => p.UnitPrice),
            //        ProductName = p.FirstOrDefault(x => x.UnitPrice == p.Min(p => p.UnitPrice)).ProductName
            //    });

            //foreach (var item in cheapPrice)
            //{
            //    Console.WriteLine($" Cat : {item.category} price : {item.CheapPrice} name: {item.ProductName} ");
            //}

            // 9 

            //var result = from p in products
            //             group p by p.Category into g
            //             let cheapPrice = g.Min(p => p.UnitPrice)
            //             from p in g
            //             where p.UnitPrice == cheapPrice
            //             select new
            //             {
            //                 Category = g.Key,
            //                 CheapPrice = cheapPrice,
            //                 ProuctName = p.ProductName
            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine($" Cat : {item.Category} price : {item.CheapPrice} ");
            //}

            // 10

            //var NumOfChar3 = File
            //    .ReadAllLines("C:/Users/medod/Downloads/DOT NET/LINQ day 2/Assignment files/dictionary_english.txt");

            //var result = NumOfChar3.Max(arr => arr.Length);
            //Console.WriteLine(result);

            // 11 

            //var ExpensivePrice = products.GroupBy(p => p.Category)
            //    .Select(g =>
            //    {
            //        var max = g.Max(p => p.UnitPrice);
            //        return new
            //        {
            //            category = g.Key,
            //            ExpensivePrice = max,
            //            name = g.FirstOrDefault(x => x.UnitPrice == max).ProductName
            //        };
            //    });

            //foreach (var item in ExpensivePrice)
            //{
            //    Console.WriteLine(item.category + " " + item.ExpensivePrice + " " + item.name);
            //}

            // 12 

            //var result = products.MaxBy(p => p.UnitPrice); 
            //Console.WriteLine(result);

            // 13 

            //var result = NumOfChar2.Average(arr => arr.Length);
            //Console.WriteLine((int) result);

            // 14

            //var result = products.GroupBy(p => p.Category)
            //    .Select(p => new
            //    {
            //        cat = p.Key,
            //        avg = p.Average(p => p.UnitPrice),
            //    }); 
            //foreach( var item in result)
            //{
            //    Console.WriteLine(item.cat + " " +  item.avg.ToString("F2"));
            //}


            #endregion

            #region orders operators

            // 1 

            //var OrdersByProductName = products.OrderBy(x => x.ProductName);
            //foreach( var o in OrdersByProductName )
            //{
            //    Console.WriteLine(o);
            //}

            // 2 
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var result = Arr.OrderBy(s => s, new CustomComparer());

            //foreach( var item in result )
            //{
            //    Console.WriteLine(item);
            //}


            // 3 

            //var sortProductByUnitsInStock = products.OrderByDescending(p => p.UnitsInStock);

            //foreach(var item in sortProductByUnitsInStock)
            //{
            //    Console.WriteLine(item);
            //}

            // 4 
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var sortAlpah = Arr.OrderBy(x => x.Length).ThenBy(x=>x);

            // 5 
            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var sortWords = words.OrderBy(x=> x.Length).ThenBy(x=>x, new CustomComparer());
            //foreach ( var word in sortWords)
            //{
            //    Console.WriteLine(word);
            //} 

            // 6 

            //var sortProduct = products
            //    .OrderByDescending(x=>x.Category)
            //    .ThenBy(x=> x.UnitPrice).ToList();

            // 7 

            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var result = Arr.OrderBy(x=> x.Length).ThenByDescending(x=> x, new CustomComparer());

            // 8 

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }

            //var result = Arr.Where(x => x[1] == 'i').Reverse();


            #endregion

            #region Partitioning Operators

            // 1 

            //var firstThreeOrders = customers.Where(c => c.City == "Washington").Take(3);

            // 2

            //var result = customers.Skip(2).ToList(); 

            //3 
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = numbers.TakeWhile((x, i) => x < i).ToArray();
            //foreach( var x in result)
            //{
            //    Console.WriteLine(x);
            //}

            // 4

            //var result = numbers.SkipWhile(x => x % 3 != 0);
            //foreach ( var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //5

            //var result = numbers.SkipWhile((x,i)=> x> i).ToList();

            //foreach(var x in result)
            //{
            //    Console.WriteLine(x);
            //}

            #endregion

            #region Projection Operators
            // 1
            //var NOFProducts = products.Select(x=> x.ProductName).ToList();

            // 2

            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //var upperLower = words.Select(x=> new { uper =  x.ToLower() , lower = x.ToLower()});

            // 3

            //var result = products.Select(p => new { price = p.UnitPrice, p.ProductName  }).ToList();

            //4 

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var determinePosition = Arr.Select((a, i) => a == i).ToList();

            //foreach ( var a in determinePosition)
            //{
            //    Console.WriteLine(a);
            //}

            // 5 

            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var result =  numbersA.SelectMany(a=> numbersB.Where(b=> a< b),(a,b)=> new
            //{
            //    a = a,
            //    b = b
            //}).ToList();
            //foreach( var item in result )
            //{
            //    Console.WriteLine($" {item.a} is less than {item.b}");
            //}

            // 6 

            //var result = customers
            //    .SelectMany(c => c.Orders.Where(x => x.Total < 500), (c, o) =>
            //    new
            //    {
            //        cutomer = c.CompanyName,
            //        order = o
            //    });

            //foreach ( var item in result)
            //{
            //    Console.WriteLine(item.cutomer + " " + item.order);
            //} 

            // 7 

            //var result = customers.SelectMany(c => c.Orders.Where(o => o.OrderDate >= new DateTime(1998,1,1)));

            //foreach(var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Quantifiers 

            // 1 

            //var result = NumOfChar2.Any(x => x.Contains("el"));
            //Console.WriteLine(result);


            // 2 

            //var result = products.GroupBy(p => p.Category)
            //    .Where(p => p.Any(x => x.UnitsInStock > 0));

            //foreach( var item in result)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach( var item2 in item)
            //    {
            //        Console.WriteLine(item2);
            //    }
            //}
            #endregion

            #region Grouping Operators

            //  1 
            //var numbers = Enumerable.Range(0, 14);
            //var groupList = Enumerable.Range(0, 4);
            //var result = numbers.GroupBy(x=> x % 5);

            //foreach( var item in result)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach( var item2 in item )
            //    {
            //        Console.WriteLine("   "+item2);
            //    }
            //}

            // 
            //string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };


            //var result = Arr.GroupBy(x => x, new CustomComparer2());

            //foreach(var item in result)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach(var item2 in item)
            //    {
            //        Console.WriteLine(item2);
            //    }
            //}


            #endregion
        }
    }
}
