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
          Console.WriteLine("Age must be an integer.");
        }
      }

      // Part2: Increase each person's salary.
      persons.ForEach(p => p.IncreaseSalary(bonus));
      
      // Part 1: Sort Persons by Name and Age (Sort by first name, then by age, and print each person.)
      // /*
      persons.OrderBy(p => p.FirstName)   // Sort the list of people by first name.
             .ThenBy(p => p.Age)          // If the first names are the same, sort by age.
             .ToList()                    // Convert the result to a list.
             .ForEach(p => Console.WriteLine(p.ToString()));  // Print each person in the list to the console.
                                                              // For each person in the list, print the result of p.ToString() to the console. 
      // */
      // Part2: Increase each person's salary. without sorting
      // persons.ForEach(p => Console.WriteLine(p.ToString()));

    }
  }
}
