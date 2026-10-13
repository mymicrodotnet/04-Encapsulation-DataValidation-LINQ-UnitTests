using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization; // comma instead of dot for decimals

namespace LabEncapsulationDemo
{
  public class Program
  {
    static void Main(string[] args)
    {
      // Variables declaration
      // var lines = 5;
      var lines = int.Parse(Console.ReadLine()!); // Part2

      var persons = new List<Person>();

      // Part2: The bonus / percentage is the same for all users
      var bonus = decimal.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

      for (int i = 0; i < lines; i++)
      {
        var cmdArgs = Console.ReadLine()!.Split();   // Read a line from the console and split it into parts based on spaces.

        if (int.TryParse(cmdArgs[2], out int age))
        {
          try
          {
            var person = new Person(
            cmdArgs[0],
            cmdArgs[1],
            age,
            decimal.Parse(cmdArgs[3], CultureInfo.InvariantCulture)); // Part2: read salary

            persons.Add(person);  // Add the created person to the list of people.
          }
          catch (ArgumentException ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
        else
        {
          Console.WriteLine("Åldern måste vara ett heltal.");
        }
      }
      // Part2: Increase salary percentage
      persons.ForEach(p => p.IncreaseSalary(bonus));


      //Part2: If sorting, uncomment the block below and comment line 58
      /* 
            persons.OrderBy(p => p.FirstName)   // Sortera listan av personer efter förnamn
                   .ThenBy(p => p.Age)          // Om förnamnen är lika, sortera efter ålder
                   .ToList()                    // Konvertera resultatet till en lista
                   .ForEach(p => Console.WriteLine(p.ToString()));  // Skriv ut varje person i listan till konsolen
                                                                    // För varje person i listan, skriv ut resultatet av p.ToString() till konsolen. 
                                                                    */

      persons.ForEach(p => Console.WriteLine(p.ToString()));
    }
  }
}
