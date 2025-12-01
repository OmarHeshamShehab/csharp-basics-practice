using System;
using System.Collections.Generic;
using System.Linq;

// ============================================================================
// SECTION 1: STRING TRIMMING EXAMPLES
// ============================================================================

// Demonstrates use of Trim(), TrimStart(), TrimEnd()
string firstFriend = "Alice       ";
string secondFriend = "          Bob";

// String interpolation → requires C# 6+
Console.WriteLine($"My friends are {firstFriend.TrimEnd()} and {secondFriend.TrimStart()}.");

string thirdFriend = "                  omar     ";
string fourthFriend = "             shehab           ";

// Trim() removes whitespace from both ends
Console.WriteLine($"My other friends are {thirdFriend.Trim()} {fourthFriend.Trim()}.");


// ============================================================================
// SECTION 2: STRING MANIPULATION & INFORMATION
// ============================================================================

// Demonstrates concatenation, Replace, Contains, ToUpper, StartsWith, Length
string fifthFriend = "Ahmed";
string sixthFriend = "Salem";
string fullName = fifthFriend + " " + sixthFriend;

Console.WriteLine($"My full name is {fullName}.");
Console.WriteLine($"My full name is {fullName.Replace("Ahmed", "Hassan")}.");
Console.WriteLine($"My full name contains 'Ahmed'? {fullName.Contains("Ahmed")}.");
Console.WriteLine($"My full name (uppercase): {fullName.ToUpper()}.");
Console.WriteLine($"My full name length = {fullName.Length}.");
Console.WriteLine($"Does my name start with 'Ah'? {fullName.StartsWith("Ah")}.");


// ============================================================================
// SECTION 3: OVERFLOW HANDLING & NUMERIC OPERATIONS
// ============================================================================

// Safe overflow handling using long
int a = 2100000000;
int b = 2100000000;

// Casting to long prevents overflow here
long c = (long)a + b;
Console.WriteLine(c);

// Decimal arithmetic (requires m suffix)
decimal input1 = 2m;
decimal input2 = 6m;
decimal result = input1 + input2;
Console.WriteLine(result);


// ============================================================================
// SECTION 4: BOOLEAN LOGIC & CONDITIONALS
// ============================================================================

int a1 = 5;
int b2 = 2;
bool answer = a1 + b2 > 10;

if (answer)
{
    Console.WriteLine("The answer is greater than 10.");
}
else
{
    Console.WriteLine("The answer is not greater than 10.");
}

// Multiple conditions using logical operators &&, ||
int a3 = 5;
int b3 = 3;
int c3 = 4;

if ((a3 + b3 + c3 > 10) && (a3 == b3))
{
    Console.WriteLine("The total is greater than 10.");
    Console.WriteLine("First number equals the second.");
}
else
{
    Console.WriteLine("The total is not greater than 10.");
    Console.WriteLine("Or the first number is not equal to the second.");
}


// ============================================================================
// SECTION 5: LOOPING EXAMPLES
// ============================================================================

// WHILE loop
int counter = 0;
while (counter < 5)
{
    counter++;
    Console.WriteLine($"Counter value: {counter}");
}

Console.WriteLine("-----");

// DO-WHILE loop (runs at least once)
int dCounter = 0;
do
{
    dCounter++;
    Console.WriteLine($"Counter value: {dCounter}");
}
while (dCounter < 5);

// FOR loop with even-number check
for (int i = 0; i < 5; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine($"The number {i} is even.");
    }
}

// Nested loops example
for (int row = 1; row <= 10; row++)
{
    for (char column = 'a'; column <= 'j'; column++)
    {
        Console.WriteLine($"The cell is ({row}, {column})");
    }
}


// ============================================================================
// SECTION 6: WORKING WITH LISTS & COLLECTION EXPRESSIONS
// ============================================================================

// Basic List<T> initialization
var namesOldWay = new List<string> { "Alice", "Bob", "Omar", "Shehab", "Ahmed", "Salem" };

// Range operator (C# 8+)
foreach (var name in namesOldWay[2..4])
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

// Modern C# 12 collection expressions
List<string> names = ["Adam", "Ana", "Felipe"];

foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

// Index from end operator (^)
Console.WriteLine(namesOldWay[0]);
Console.WriteLine(namesOldWay[^1]);

// Array initialization
string[] arr = { "one", "two", "three" };

// Spread operator (C# 12)
arr = [.. arr, "four", "five"];

foreach (var item in arr)
{
    Console.WriteLine(item);
}

// Sorting a list
List<string> omList = ["kim", "lee", "park", "choi"];
omList.Sort();
foreach (var item in omList)
{
    Console.WriteLine(item);
}

// Integer list + IndexOf + sorting
List<int> numList = [45, 23, 67, 12, 89, 34, 10];
Console.WriteLine($"Index of 67: {numList.IndexOf(67)}");

numList.Sort();
Console.WriteLine($"Index of 67 after sort: {numList.IndexOf(67)}");

foreach (var number in numList)
{
    Console.WriteLine(number);
}

// LINQ Query Syntax
List<int> scores = [97, 92, 81, 60, 100, 84, 93];

IEnumerable<int> scoreQuery =
    from score in scores
    where score > 80
    orderby score descending
    select score;

Console.WriteLine(scoreQuery.Count());

foreach (var s in scoreQuery)
{
    Console.Write(s + " ");
}

Console.WriteLine();

// Convert query result to list
List<int> myScores = scoreQuery.ToList();
foreach (var s in myScores)
{
    Console.WriteLine(s);
}

// LINQ Method Syntax
var scoreQuery2 = scores.Where(s => s > 80).OrderByDescending(s => s);

foreach (var score in scoreQuery2)
{
    Console.WriteLine(score);
}


// ============================================================================
// SECTION 7: OBJECT-ORIENTED PROGRAMMING (OOP)
// ============================================================================

Console.WriteLine("hello oop");

// Create Person objects
var p1 = new Person("Scott", "Hanselman", new DateOnly(1970, 1, 1));
var p2 = new Person("David", "Fowler", new DateOnly(1986, 1, 1));

// Add pets to people
p1.Pets.Add(new Dog("Fred"));
p1.Pets.Add(new Dog("Barney"));

p2.Pets.Add(new Cat("Beyonce"));

List<Person> people = [p1, p2];

// Display people and their pets
foreach (var person in people)
{
    Console.WriteLine($"{person}");

    foreach (var pet in person.Pets)
    {
        Console.WriteLine($"    {pet}");
    }
}


// ============================================================================
// Person Class
// ============================================================================

/// <summary>
/// Represents a human with a first name, last name, birthday, and a list of pets.
/// </summary>
public class Person(string firstname, string lastname, DateOnly birthday)
{
    public string First { get; } = firstname;
    public string Last { get; } = lastname;
    public DateOnly Birthday { get; } = birthday;

    /// <summary>
    /// A person may own multiple pets.
    /// </summary>
    public List<Pet> Pets { get; } = new();

    /// <summary>
    /// Returns a readable string that represents this Person.
    /// Called automatically when printed (Console.WriteLine).
    /// </summary>
    public override string ToString() =>
        $"Human ({First} {Last})";
}


// ============================================================================
// Pet Base Class
// ============================================================================

/// <summary>
/// Abstract base class for all pets.
/// Requires subclasses (Dog, Cat) to define MakeNoise().
/// </summary>
public abstract class Pet(string firstname)
{
    public string First { get; } = firstname;

    /// <summary>
    /// Each pet type must define the sound it makes.
    /// </summary>
    public abstract string MakeNoise();

    /// <summary>
    /// Returns detailed info:
    /// - Pet name
    /// - Type (Dog, Cat)
    /// - Sound it makes
    /// </summary>
    public override string ToString()
    {
        // GetType().Name retrieves actual runtime class name (Dog/Cat)
        return $"{First} and I am a {GetType().Name} and I {MakeNoise()}";
    }
}


// ============================================================================
// Cat Class
// ============================================================================

/// <summary>
/// Cat class that inherits from Pet.
/// </summary>
public class Cat(string firstname) : Pet(firstname)
{
    /// <summary>
    /// Sound a cat makes.
    /// </summary>
    public override string MakeNoise() => "meow";
}


// ============================================================================
// Dog Class
// ============================================================================

/// <summary>
/// Dog class that inherits from Pet.
/// </summary>
public class Dog(string firstname) : Pet(firstname)
{
    /// <summary>
    /// Sound a dog makes.
    /// </summary>
    public override string MakeNoise() => "bark";
}
