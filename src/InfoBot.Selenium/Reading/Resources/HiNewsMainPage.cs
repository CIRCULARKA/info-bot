namespace InfoBot.Selenium.Reading.Resources;

public class HiNewsMainPage : Page, IResourceMainPage
{
    /// <summary>
    /// Путь до корневого веб-элемента каждой статьи на странице
    /// </summary>
    private readonly By _articleSelector = By.XPath("//article");

    /// <summary>
    /// Путь до заголовка статьи относительно веб-элемента статьи
    /// </summary>
    private readonly By _articleHeaderSelector = By.XPath("h2/a");

    public HiNewsMainPage(
        Uri pageUri,
        IWebDriver driver,
        TimeSpan explicitWaitTime,
        TimeSpan pageLoadTimeout) :
        base(pageUri, driver, explicitWaitTime, pageLoadTimeout)
    {
    }

    public List<Article> ReadLatestArticles()
    {
        Load();

        var articleElements = GetElements(_articleSelector);

        var result = new List<Article>();
        foreach (var articleElement in articleElements)
        {
            var headerAttribute = GetHeaderAttribute(articleElement);
            result.Add(new Article
            {
                Attributes = new() { headerAttribute }
            });
        }

        return result;
    }

    private ArticleAttribute GetHeaderAttribute(IWebElement article)
    {
        var header = article.FindElement(_articleHeaderSelector).Text.Trim();
        return new ArticleAttribute
        {
            Name = "Header",
            Value = header
        };
    }
}