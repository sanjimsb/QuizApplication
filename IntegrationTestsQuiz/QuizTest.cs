using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace IntegrationTestsQuiz;

[TestClass]
public class ModuleTest
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
        var quiz = _webDriver?.FindElement(By.Id("Quizes_Question"));
        quiz?.SendKeys("TestQuestion");
    }

    [TestMethod]
    public void TestMethod2()
    {
        var option = _webDriver?.FindElement(By.Id("Quizes_Option1"));
        option?.SendKeys("option1");
    }

    [TestMethod]
    public void TestMethod3()
    {
        var option = _webDriver?.FindElement(By.Id("Quizes_Option2"));
        option?.SendKeys("option2");
    }

    [TestMethod]
    public void TestMethod4()
    {
        var option = _webDriver?.FindElement(By.Id("Quizes_Option3"));
        option?.SendKeys("option3");
    }

    [TestMethod]
    public void TestMethod5()
    {
        var option = _webDriver?.FindElement(By.Id("Quizes_Option4"));
        option?.SendKeys("option4");
    }

    [TestMethod]
    public void TestMethod6()
    {
        var option = _webDriver?.FindElement(By.Id("Quizes_CorrectAnswer"));
        option?.SendKeys("option4");
    }

    [TestMethod]
    public void TestMethod7()
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
