using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace IntegrationTestsQuiz;

[TestClass]
public class RegisterTest
{
    private IWebDriver? _webDriver;

    [TestInitialize]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _webDriver = new ChromeDriver();
        _webDriver.Url = "https://localhost:63857/Identity/Account/Register";
        _webDriver.Navigate();
    }

    [TestMethod]
    public void TestMethod1()
    {
        var email = _webDriver?.FindElement(By.Id("Input_Email"));
        email?.SendKeys("Module 2");
    }

    [TestMethod]
    public void TestMethod2()
    {
        var password = _webDriver?.FindElement(By.Id("Input_Password"));
        password?.SendKeys("Module 2 Description");
    }
    

    [TestMethod]
    public void TestMethod3()
    {
        var confirmPassword = _webDriver?.FindElement(By.Id("Input_ConfirmPassword"));
        confirmPassword?.SendKeys("Module 2 Description");
    }

    [TestMethod]
    public void TestMethod4()
    {
        var btn = _webDriver?.FindElement(By.Id("registerSubmit"));
        btn?.Click();
    }



    [TestCleanup]
    public void TearDown()
    {
        _webDriver?.Quit();
    }
}
