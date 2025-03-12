namespace Testing.Tests;
using MainProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public sealed class TestMenu
{
    private MenuHandler _menuHandler;

    [TestInitialize]
    public void Setup()
    {
        //Arrange
        _menuHandler = new MenuHandler();
    }

    [TestMethod] //Tests ValidateMenuOption with multiple input values.
    [DataRow(1, true)] //Valid option
    [DataRow(4, true)] //Valid option
    [DataRow(-1, true)] //Valid exit option
    [DataRow(0, false)] //Invalid option
    [DataRow(5, false)] //Invalid option
    [DataRow(-2, false)] //Invalid option
    public void ValidateMenuOption_ShouldReturnExpectedResult(int option, bool expected)
    {
        //Act 
        bool result = _menuHandler.ValidateMenuOption(option);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod] //Tests ValidateResponse with different user input strings.
    [DataRow("yes", true)] //Valid input
    [DataRow("no", true)] //Valid input
    [DataRow("YeS", true)] //Case-insensitive valid input
    [DataRow("  no  ", true)] //Input with leading/trailing spaces
    [DataRow("maybe", false)] //Invalid input
    [DataRow("", false)] //Empty string
    [DataRow(null, false)] //Null input
    public void ValidateResponse_ShouldReturnExpectedResult(string response, bool expected)
    {
        //Act
        bool result = _menuHandler.ValidateResponse(response);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
