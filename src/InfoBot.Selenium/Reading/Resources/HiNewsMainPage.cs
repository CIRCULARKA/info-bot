namespace InfoBot.Selenium.Reading.Resources;

public class HiNewsMainPage : Page, IResourceMainPage
{
    public HiNewsMainPage(IWebDriver driver, TimeSpan explicitWaitTime) :
        base(driver, explicitWaitTime)
    {
    }

    public List<Article> ReadLatestArticles()
    {
        throw new NotImplementedException();
    }
}