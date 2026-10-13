using System.Globalization; // comma instead of dot for decimals
namespace LabEncapsulationDemo
{
  public class Person
  {
    // Private Fields
    // The fields are private, which means they cannot be accessed directly from outside the class.
    // To access and modify these fields, we use public properties.
    private string firstName = string.Empty;
    private string lastName = string.Empty;
    private int age;
    private decimal salary;

    // Constructor
    public Person(string firstName, string lastName, int age, decimal salary)
    {
      FirstName = firstName;
      LastName = lastName;
      Age = age;
      Salary = salary;
    }

    // Properties: get,set accessors | Encapsulation
    public string FirstName
    {
      get
      {
        return firstName;
      }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("First name cannot be empty or contain only whitespace.");
        }

        // Names must be at least 3 symbols
        if (value.Length < 3)
        {
          throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
        }
        firstName = value;
      }
    }

    public string LastName
    {
      get
      {
        return lastName;
      }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Last name cannot be empty or contain only whitespace.");
        }

        // LastName must be at least 3 symbols
        if (value.Length < 3)
        {
          throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
        }
        lastName = value;
      }
    }

    public int Age
    {
      get
      {
        return age;
      }
      private set
      {
        if (value <= 0)
        {
          throw new ArgumentException(
             "Age cannot be zero or a negative integer!");
        }
        age = value;
      }
    }

    public decimal Salary
    {
      get // get accessor
      {
        return salary;
      }
      private set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException(
             nameof(value),
             "Salary cannot be negative.");
        }
        if (value >= 0 && value < 460)
        {
          throw new ArgumentException(
             "Salary cannot be less than 460 dollar!");
        }
        salary = value;
      }
    }

    // Methods
    public override string ToString()
    {
      // return $"{FirstName} {LastName} is {Age} years old.";
      // return $"{FirstName} {LastName} receives {salary:F2} dollars.";
      return $"{FirstName} {LastName} receives {salary.ToString("F2", CultureInfo.InvariantCulture)} dollars."; // To show dot instead of comma for decimals.
    }

    public void IncreaseSalary(decimal percentage)
    {
      if (age < 30) // person should receive half the percentage increase
      {
        salary += (percentage * salary / 100) / 2;
      }
      else // person should receive full percentage increase
      {
        salary += percentage * salary / 100;
      }
    }
  }
}
