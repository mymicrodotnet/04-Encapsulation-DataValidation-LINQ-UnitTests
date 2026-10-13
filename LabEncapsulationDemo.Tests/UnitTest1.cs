using Xunit;

namespace LabEncapsulationDemo.Tests;

public class UnitTest1
{
    // Verifies that a salary below the minimum of 460 is rejected.
    [Fact]
    public void Constructor_ValidPerson_CreatesPerson()
    {
        var person = new Person("Anna", "Smith", 35, 500m);

        Assert.Equal("Anna", person.FirstName);
        Assert.Equal("Smith", person.LastName);
        Assert.Equal(35, person.Age);
        Assert.Equal(500m, person.Salary);
    }

    [Fact] // marks a method as a test that xUnit should execute
    public void Constructor_NegativeAge_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => new Person("Anna", "Smith", -1, 500m));

        Assert.Equal(
            "Age cannot be zero or a negative integer!",
            exception.Message);
    }

    [Fact] // marks a method as a test that xUnit should execute
    public void Constructor_ShortFirstName_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>( // checks that the expected exception is thrown.
            () => new Person("Al", "Smith", 35, 500m));

        Assert.Equal( // checks that the actual value or error message matches the expected result.
            "First name cannot contain fewer than 3 symbols!",
            exception.Message);
    }

    [Fact] // marks a method as a test that xUnit should execute
    public void Constructor_ShortLastName_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => new Person("Anna", "Li", 35, 500m));

        Assert.Equal(
            "Last name cannot contain fewer than 3 symbols!",
            exception.Message);
    }

    [Fact] // marks a method as a test that xUnit should execute
    public void Constructor_SalaryBelow460_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => new Person("Anna", "Smith", 35, 459m));

        Assert.Equal(
            "Salary cannot be less than 460 dollar!",
            exception.Message);
    }
}
