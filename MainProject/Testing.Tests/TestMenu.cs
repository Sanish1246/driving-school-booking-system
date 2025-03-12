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
        _menuHandler = new MenuHandler();
    }

    [TestMethod]
    public void ValidateMenuOption_ShouldReturnTrueForValidOptions()
    {
        Assert.IsTrue(_menuHandler.ValidateMenuOption(1));
        Assert.IsTrue(_menuHandler.ValidateMenuOption(2));
        Assert.IsTrue(_menuHandler.ValidateMenuOption(4));
        Assert.IsTrue(_menuHandler.ValidateMenuOption(-1));
    }

    [TestMethod]
    public void ValidateMenuOption_ShouldReturnFalseForInvalidOptions()
    {
        Assert.IsFalse(_menuHandler.ValidateMenuOption(0));
        Assert.IsFalse(_menuHandler.ValidateMenuOption(5));
        Assert.IsFalse(_menuHandler.ValidateMenuOption(100));
    }

    [TestMethod]
    public void ValidateResponse_ShouldReturnTrueForValidResponses()
    {
        Assert.IsTrue(_menuHandler.ValidateResponse("yes"));
        Assert.IsTrue(_menuHandler.ValidateResponse("no"));
        Assert.IsTrue(_menuHandler.ValidateResponse(" Yes "));
        Assert.IsTrue(_menuHandler.ValidateResponse("No "));
    }

    [TestMethod]
    public void ValidateResponse_ShouldReturnFalseForInvalidResponses()
    {
        Assert.IsFalse(_menuHandler.ValidateResponse(""));
        Assert.IsFalse(_menuHandler.ValidateResponse("maybe"));
        Assert.IsFalse(_menuHandler.ValidateResponse("  "));
    }

    [TestMethod]
    public void HandleMenuOption_ShouldReturnExpectedMessages()
    {
        Assert.AreEqual("Student added.", _menuHandler.HandleMenuOption(1));
        Assert.AreEqual("Student deleted.", _menuHandler.HandleMenuOption(2));
        Assert.AreEqual("Displaying students.", _menuHandler.HandleMenuOption(4));
        Assert.AreEqual("Exiting application.", _menuHandler.HandleMenuOption(-1));
        Assert.AreEqual("Invalid option.", _menuHandler.HandleMenuOption(99));
    }
}