var itemList = new List<item>()
{
    new item() { id = 1, name = "ball", color = "green" },
    new item() { id = 2, name = "football", color = "brown" },
    new item() { id = 3, name = "baseball", color = "white" },
    new item() { id = 4, name = "softball", color = "yellow" },
    new item() { id = 5, name = "littleball", color = "blue" },
    new item() { id = 6, name = "blue ball", color = "blue" }
};


/// <summary>
/// Where Clause
/// </summary>

var whereResult = itemList.Where(x => x.color == "blue").First();

Console.WriteLine("Where Clause");
Console.WriteLine(whereResult.name);
Console.WriteLine("---------------------");

/// <summary>
/// Order BY Clause
/// </summary>

var orderByResult = itemList.OrderBy(x => x.name).ToList();
var orderByResultDecending = itemList.OrderByDescending(x => x.id).ToList();

Console.WriteLine("Order BY Clause");
foreach (var y in orderByResult)
{
    Console.WriteLine(y.name);
}
Console.WriteLine("---------------------");

Console.WriteLine("Order BY Clause Decending");
foreach (var y in orderByResultDecending)
{
    Console.WriteLine(y.id);
}
Console.WriteLine("---------------------");

/// <summary>
/// Group By Clause
/// </summary>
/// 

var groupByResult = itemList.GroupBy(x => x.color);

Console.WriteLine("Group By Clause");
foreach (var y in groupByResult)
{
    Console.WriteLine(y.Key);
    foreach (var item in y)
    {
        Console.WriteLine(item.name);
    }
}
Console.WriteLine("---------------------");

/// <summary>
/// Join Clause
/// </summary>

var itemList1 = new List<item>()
{
    new item() { id = 1, name = "ball", color = "green" },
    new item() { id = 2, name = "football", color = "brown" },
    new item() { id = 3, name = "baseball", color = "white" },
    new item() { id = 4, name = "softball", color = "yellow" },
};

var itemList2 = new List<item>()
{
    new item() { id = 1, name = "ball", color = "green" },
    new item() { id = 2, name = "football", color = "brown" },
    new item() { id = 3, name = "soccer", color = "white" },
    new item() { id = 4, name = "tennis", color = "yellow" },
};


var joinedLst = itemList1.Join(itemList2, item1 => item1.name, item2 => item2.name, (item1, item2) => item1).ToList();


Console.WriteLine("Join Clause"); //joins and keeps the values found in both
foreach (var y in joinedLst)
{
    Console.WriteLine(y.id + " " + y.name + " " + y.color);
}
Console.WriteLine("---------------------");

/// <summary>
/// Select Clause
/// </summary>
/// 

var selectLst = itemList.Where(x => x.color == "blue").Select(x => new { itemId = x.id, color = x.color }).ToList();

Console.WriteLine("Select Clause");
foreach (var y in selectLst)
{
    Console.WriteLine(y.itemId + " " + y.color);
}
Console.WriteLine("---------------------");



/// <summary>
/// All & Any Clause, returns bools
/// </summary>

var anyResultTrue = itemList.Any(x => x.color == "blue");
var anyResultFalse = itemList.Any(x => x.color == "pink");

var allResult = itemList.All(x => x.name == "baseball");

Console.WriteLine("All & Any Clause");
Console.WriteLine("This Should be true: " + anyResultTrue);
Console.WriteLine("This Should be false: " + anyResultFalse);

Console.WriteLine("Are all baseball for the name? : " + allResult);
Console.WriteLine("---------------------");


/// <summary>
/// Contains Clause
/// </summary>
/// 

var intLst = new List<int>() { 1, 2, 3, 4, 5 };

var containsResult = intLst.Contains(8);
var containsResult2 = intLst.Contains(1);

Console.WriteLine("Contains Clause");
Console.WriteLine("Contains 8? : " + containsResult);
Console.WriteLine("Contains 1? : " + containsResult2);
Console.WriteLine("---------------------");



/// <summary>
/// Math Clauses Average, Count, Max, Sum, Min
/// </summary>
/// 

Console.WriteLine("Math Clause");
var avg = intLst.Average();
var max = intLst.Max();
var min = intLst.Min();
var count = itemList.Count();
var sum = intLst.Sum();


Console.WriteLine("avg : " + avg);
Console.WriteLine("max : " + max);
Console.WriteLine("min : " + min);
Console.WriteLine("count : " + count);
Console.WriteLine("sum :" + sum);
Console.WriteLine("---------------------");


/// <summary>
///  ElementAt, First, Last, Single or Defaults Clause
/// </summary>
/// 

var elementResult = itemList.ElementAt(0);
var firstResult = itemList.Where(x => x.color == "blue").FirstOrDefault();
var lastResult = itemList.Where(x => x.color == "blue").LastOrDefault();
var singleResult = itemList.Where(x => x.color == "brown").SingleOrDefault();


Console.WriteLine("elementResult : " + elementResult.name);
Console.WriteLine("firstResult : " + firstResult.name);
Console.WriteLine("lastResult : " + lastResult.name);
Console.WriteLine("singleResult : " + singleResult.name); //this throws exception if there is more than one match while first returns the first match

Console.WriteLine("---------------------");


/// <summary>
/// Concat Clause , merges two lists of the same type
/// </summary>
/// 

var intLst1 = new List<int>() { 1, 2, 3 };
var intLst2 = new List<int>() { 4, 5 };

var intLst3 = intLst1.Concat(intLst2).ToList();

Console.WriteLine("Concat Clause");
foreach (var y in intLst3)
{
    Console.WriteLine(y);
}
Console.WriteLine("---------------------");


/// <summary>
/// Distinct Clause, get the distinct values of a list, doesnt work with objects without a helper method
/// </summary>
/// 

var dLst = new List<int>() { 1, 1, 2, 3, 3, 3, 5 };

var distinctLst = dLst.Distinct().ToList();

Console.WriteLine("Distinct Clause");
foreach (var y in distinctLst)
{
    Console.WriteLine(y);
}
Console.WriteLine("---------------------");

/// <summary>
/// Skip & Take Clause
/// </summary>
/// 


var skippedLst = itemList.Skip(2).ToList();
var takenLst = itemList.Take(3).ToList();

Console.WriteLine("Skip Clause");
foreach (var y in skippedLst)
{
    Console.WriteLine(y.name);
}
Console.WriteLine("---------------------");

Console.WriteLine("Take Clause");
foreach (var y in takenLst)
{
    Console.WriteLine(y.name);
}
Console.WriteLine("---------------------");



/// <summary>
/// Deferred Execution vs Immediate Execution
/// </summary>

var imLst = itemList.Skip(2).ToList(); // this is immediate exectuion because we immeditaly tell it to turn it into a list and that needs the objects now

//deffered execution is how u build a query

var query = itemList.Where(x => x.color == "blue");

query = query.Select(x => new item { id = x.id });
//you can see if u had conditions or other options you would be able to build a query like this and gives flexibility and u dont have to always need objects for those queries since its basically interpreted as logic
//like a  sql query, show debugger

query = query.ToList(); //executes here

Console.WriteLine("Deferred");
foreach (var y in query)
{
    Console.WriteLine(y.id);
}
Console.WriteLine("---------------------");














public class item
{
    public int id;
    public string name;
    public string color;
}
