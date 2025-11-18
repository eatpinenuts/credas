using NameSorter.Core.Services;

public class NameParserTests
{
    [Fact]
    public void Parse_WhenNameIsValid_ReturnsCorrectGivenAndLastName()
    {
        // Arrange
        var parser = new PersonNameParser();

        // Act
        var person = parser.Parse("Adonis Julius Archer");

        // Assert
        Assert.Equal("Archer", person.LastName);
        Assert.Equal(new[] { "Adonis", "Julius" }, person.GivenNames);
    }

    [Fact]
    public void Parse_WhenNameIsInvalid_ThrowsArgumentException()
    {
        var parser = new PersonNameParser();

        // Names require at least a surname, so this should fail
        Assert.Throws<ArgumentException>(() => parser.Parse("SingleName"));
    }

    [Fact]
    public void Parse_WhenThreeGivenNamesProvided_ParsesAllGivenNamesCorrectly()
    {
        var parser = new PersonNameParser();

        var result = parser.Parse("Hunter Uriah Mathew Clarke");

        Assert.Equal("Clarke", result.LastName);
        Assert.Equal(new[] { "Hunter", "Uriah", "Mathew" }, result.GivenNames);
    }
}
