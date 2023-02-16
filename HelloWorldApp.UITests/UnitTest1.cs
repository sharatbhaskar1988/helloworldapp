using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.Edge; 
using System;
using System.Threading;

namespace HelloWorldApp.UITests;

[TestFixture("Chrome")]
//[TestFixture("Firefox")] 
public class IndexPageTest 
{
    private string browser;
    private IWebDriver driver;
    public IndexPageTest(string browser) 
    {
        this.browser = browser; 
    }
[OneTimeSetUp] 
public void Init() 
{
    var cwd = Environment.CurrentDirectory;
    // Create the driver for the current browser. 
    switch (browser)
    {
        case "Chrome":
            driver = new ChromeDriver(cwd); 
            break;
        default:
            throw new ArgumentException($"'{browser}': Unknown browser");
    }
}

[OneTimeTearDown] 
public void Cleanup() 
{
    driver.Quit(); 
}

private void ClickElement(IWebElement element) 
{
    // We expect the driver to implement IJavaScriptExecutor.
    // IJavaScriptExecutor enables us to execute JavaScript code during the tests. IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
    // Through JavaScript, run the click() method on the underlying HTML object. js.ExecuteScript("arguments[0].click();", element);
}

[Test]
public void AddTest() 
{
    if (driver == null) 
    {
        Assert.Ignore();
        return; 
    }
driver.Manage().Window.Maximize();
driver.Url = Environment.GetEnvironmentVariable("SET_URL"); 
IWebElement n1 = driver.FindElement(By.Name("N1")); 
IWebElement n2 = driver.FindElement(By.Name("N2")); 
n1.Clear();
n2.Clear();
n1.SendKeys("10");
n2.SendKeys("3");
ClickElement(driver.FindElement(By.Name("submit"))); 
IWebElement result = driver.FindElement(By.Name("Result"));
var actual = int.Parse(result.GetAttribute("value"));
int expected = 13;
Assert.That(actual, Is.EqualTo(expected));
Thread.Sleep(3000);
 }

}
