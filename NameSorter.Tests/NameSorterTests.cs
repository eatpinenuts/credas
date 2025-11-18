using NameSorter.Core.Models;
using NameSorter.Core.Services;

public class NameSorterTests
{
    [Fact]
    public void Sort_WhenNamesProvided_SortsByLastNameThenGivenNames()
    {
        var sorter = new PersonNameSorter();

        // Two names chosen so alphabetical order is unambiguous
        var list = new List<PersonName>
        {
            new(new [] { "Vaughn" }, "Lewis"),
            new(new [] { "Marin" }, "Alvarez")
        };

        var sorted = sorter.Sort(list).ToList();

        Assert.Equal("Alvarez", sorted[0].LastName);
        Assert.Equal("Lewis", sorted[1].LastName);
    }

    [Fact]
    public void Sort_WhenUsingSampleData_ReturnsExpectedOrdering()
    {
        var sorter = new PersonNameSorter();
        var names = new List<PersonName>
        {
            new(new[] { "Janet" }, "Parsons"),
            new(new[] { "Adonis", "Julius" }, "Archer"),
            new(new[] { "Marin" }, "Alvarez")
        };

        var sorted = sorter.Sort(names).Select(n => n.ToString()).ToList();

        Assert.Equal("Marin Alvarez", sorted[0]);
        Assert.Equal("Adonis Julius Archer", sorted[1]);
        Assert.Equal("Janet Parsons", sorted[2]);
    }
}
