using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class BrowserAutomation
{
    public static void Browse(string url)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(url);
        Console.WriteLine($"Browsing: {url}");
        driver.Quit();
    }

    public static void Main(string[] args)
    {
        string url = "google.com";  // Replace with your desired URL
        Browse(url);
    }
}
