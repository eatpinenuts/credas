using NameSorter.Core.Services;

public class NameParserTests
{
    [Fact]
    public void Parse_ValidName_ReturnsCorrectParts()
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
    public void Parse_InvalidName_Throws()
    {
        var parser = new PersonNameParser();

        // Names require at least a surname, so this should fail
        Assert.Throws<ArgumentException>(() => parser.Parse("SingleName"));
    }
}
