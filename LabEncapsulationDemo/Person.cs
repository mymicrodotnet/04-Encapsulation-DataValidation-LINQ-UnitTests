using System.Globalization; // comma instead of dot for decimals
namespace LabEncapsulationDemo
{
  public class Person
  {
    // Private Fields
    // The fields are private, which means they cannot be accessed directly from outside the class.
    // To access and modify these fields, we use public properties.
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private int _age;
    private decimal _salary; // Part2

    // Constructor
    public Person(string firstName, string lastName, int age, decimal salary)
    {
      FirstName = firstName;
      LastName = lastName;
      Age = age;
      Salary = salary; // Part2: Expand Person, salary (decimal), IncreaseSalary(decimal percentage) 
    }

    // Properties: get,set accessors | Encapsulation
    public string FirstName
    {
      get
      {
        return _firstName;
      }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("First name cannot be empty or contain only whitespace.");
        }

        // Part3: Names must be at least 3 symbols
        if (value.Length < 3)
        {
          throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
        }
        _firstName = value;
      }
    }

    public string LastName
    {
      get
      {
        return _lastName;
      }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Last name cannot be empty or contain only whitespace.");
        }

        // Part3: LastName must be at least 3 symbols
        if (value.Length < 3)
        {
          throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
        }
        _lastName = value;
      }
    }

    public int Age
    {
      get
      {
        return _age;
      }
      private set
      { // Part3: Age must not be -zero- or negative
        if (value <= 0)
        {
          throw new ArgumentException(
             "Age cannot be zero or a negative integer!");
        }
        _age = value;
      }
    }

    public decimal Salary
    {
      get // get accessor
      {
        return _salary;
      }
      private set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException(
             nameof(value),
             "Salary cannot be negative.");
        } // Part3: Salary can't be less than 460.0 
        if (value >= 0 && value < 460)
        {
          throw new ArgumentException(
             "Salary cannot be less than 460 dollar!");
        }
        _salary = value;
      }
    }

    // Methods
    public override string ToString()
    {
      // Part1:
      // return $"{FirstName} {LastName} is {Age} years old.";

      // Part2:
      // return $"{FirstName} {LastName} receives {salary:F2} dollars."; // To format salary to 2 decimals.
      return $"{FirstName} {LastName} receives {_salary.ToString("F2", CultureInfo.InvariantCulture)} dollars."; // To show dot instead of comma for decimals.
    }

    // Part2: Expand Person, salary (decimal), IncreaseSalary(decimal percentage) 
    public void IncreaseSalary(decimal percentage)
    {
      if (_age < 30) // person should receive half the percentage increase
      {
        _salary += (percentage * _salary / 100) / 2;
      }
      else // person should receive full percentage increase
      {
        _salary += percentage * _salary / 100;
      }
    }
  }
}
