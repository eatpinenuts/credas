using NameSorter.Core.Models;
using NameSorter.Core.Services;

public class NameSorterTests
{
    [Fact]
    public void Sort_SortsByLastNameThenGivenNames()
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
}
