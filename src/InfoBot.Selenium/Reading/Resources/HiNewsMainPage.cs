namespace InfoBot.Selenium.Reading.Resources;

public class HiNewsMainPage : Page, IResourceMainPage
{
    /// <summary>
    /// Путь до корневого веб-элемента каждой статьи на странице
    /// </summary>
    private readonly By _articleSelector = By.XPath("//article");

    /// <summary>
    /// Путь до элемента, содержащего ссылку на статью относительно корневого элемента статьи
    /// </summary>
    private readonly By _articleSourceSelector = By.XPath("div[@class='text']/a");

    /// <summary>
    /// Список поддерживаемых атрибутов, которые будет иметь кажадя статья
    /// </summary>
    private static IReadOnlyCollection<AttributeSelector> _supportedAttributes = new List<AttributeSelector>
    {
        new AttributeSelector { Name = "Header", Selector = By.XPath("h2/a") },
        new AttributeSelector { Name = "Author", Selector = By.XPath("//div[contains(@class, 'author')]") },
        new AttributeSelector { Name = "Preface", Selector = By.XPath("//div[contains(@class, 'text')]/p") }
    };

    public HiNewsMainPage(
        Uri pageUri,
        IWebDriver driver,
        TimeSpan explicitWaitTime,
        TimeSpan pageLoadTimeout) :
        base(pageUri, driver, explicitWaitTime, pageLoadTimeout) { }

    public List<Article> ReadLatestArticles()
    {
        Load();

        var articleElements = GetElements(_articleSelector);

        var result = new List<Article>();
        foreach (var articleElement in articleElements)
        {
            result.Add(new Article
            {
                Source = GetArticleSource(articleElement),
                Attributes = GetArticleAttributes(articleElement)
            });
        }

        return result;
    }

    /// <summary>
    /// Считывает ссылку на статью на ресурсе
    /// </summary>
    private Uri GetArticleSource(IWebElement articleElement) =>
        new Uri(articleElement.FindElement(_articleSourceSelector).GetDomAttribute("href"));

    /// <summary>
    /// Возвращает все атрибуты, которые поддерживаются данной страницей
    /// </summary>
    /// <param name="articleElement">Базовый элемент статьи на данной странице</param>
    private List<ArticleAttribute> GetArticleAttributes(IWebElement articleElement)
    {
        var result = new List<ArticleAttribute>();
        foreach (var selector in _supportedAttributes)
            result.Add(GetAttributeBy(articleElement, selector));

        return result;
    }

    /// <summary>
    /// Создаёт атрибут статьи по выбранному селектору
    /// </summary>
    /// <param name="articleElement">Базовый веб-элемент статьи, относительно которого нужно искать её атрибуты</param>
    /// <param name="selector">Селектор атрибута для считывания его значения относительно базового элемента статьи</param>
    private ArticleAttribute GetAttributeBy(IWebElement articleElement, AttributeSelector selector)
    {
        return new ArticleAttribute
        {
            Name = selector.Name,
            Value = articleElement.FindElement(selector.Selector).Text.Trim()
        };
    }
}