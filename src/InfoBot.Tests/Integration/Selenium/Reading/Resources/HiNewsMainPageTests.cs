namespace InfoBot.Tests.Integration.Reading.Resources;

public class HiNewsMainPageTests : IntegrationTests
{
    public HiNewsMainPageTests(ITestOutputHelper logger) : base(logger) { }

    [Fact]
    public void ReadLatestArticles_WhenExectued_ReturnsArticlesFromMainPage()
    {
        // Arrange
        using var driver = CreateChromeDriver();

        var mainPage = new HiNewsMainPage(
            new Uri("https://hi-news.ru/"),
            driver,
            TimeSpan.FromSeconds(10),
            TimeSpan.FromMinutes(1)
        );

        // Act
        var result = mainPage.ReadLatestArticles();

        // Assert
        _logger.WriteLine("Считанные статьи:");
        result.ForEach(r => _logger.WriteLine(r.ToString()));
    }

    private IWebDriver CreateChromeDriver()
    {
        var result = new ChromeDriver();

        return result;
    }
}