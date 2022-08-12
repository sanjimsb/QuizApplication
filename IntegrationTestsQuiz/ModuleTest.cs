using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace IntegrationTestsQuiz;

[TestClass]
public class QuizTest
{
    private IWebDriver? _webDriver;

    [TestInitialize]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _webDriver = new ChromeDriver();
        _webDriver.Url = "https://localhost:63857/AddQuiz";
        _webDriver.Navigate();
    }

    [TestMethod]
    public void TestMethod1()
    {
        var name = _webDriver?.FindElement(By.Id("Modules_ModuleName"));
        name?.SendKeys("Module 2");
    }

    [TestMethod]
    public void TestMethod2()
    {
        var desc = _webDriver?.FindElement(By.Id("Modules_Description"));
        desc?.SendKeys("Module 2 Description");
    }

    [TestMethod]
    public void TestMethod3()
    {
        var btn = _webDriver?.FindElement(By.ClassName("btn-primary"));
        btn?.Click();
    }



    [TestCleanup]
    public void TearDown()
    {
        _webDriver?.Quit();
    }
}
