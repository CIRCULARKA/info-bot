namespace InfoBot.Selenium;

/// <summary>
/// Базовый класс страницы
/// </summary>
public class Page
{
    private readonly Uri _pageUri;

    private readonly IWebDriver _driver;

    private readonly TimeSpan _explicitWaitTime;

    private readonly TimeSpan _pageLoadTimeout;

    /// <summary>
    /// Создаёт объект, описывающий веб-страницу
    /// </summary>
    /// <param name="pageUri">URI страницы, с которой должно произовдиться взаимодействие</param>
    /// <param name="driver">Веб-драйвер, с помощью которого будет осуществляться взаимодействие со страницей</param>
    /// <param name="explicitWaitTime">Максимальное время ожидания веб-элемента</param>
    /// <param name="pageLoadTimeout">Максимальное время ожидания загрузки страницы</param>
    public Page(
        Uri pageUri,
        IWebDriver driver,
        TimeSpan explicitWaitTime,
        TimeSpan pageLoadTimeout)
    {
        _pageUri = pageUri ?? throw new ArgumentNullException(nameof(pageUri));
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _explicitWaitTime = explicitWaitTime;
        _pageLoadTimeout = pageLoadTimeout;
    }

    /// <summary>
    /// Загружает старницу
    /// </summary>
    public void Load()
    {
        _driver.Navigate().GoToUrl(_pageUri);
    }

    /// <summary>
    /// Считывает элемент по указанному селектору
    /// </summary>
    /// <param name="selector">Селектор веб-элемента</param>
    public IWebElement GetElement(By selector)
    {
        ArgumentNullException.ThrowIfNull(selector);

        var wait = new WebDriverWait(_driver, _explicitWaitTime);

        var result = wait.Until((driver) => driver.FindElement(selector));
        
        return result;
    }

    /// <summary>
    /// Считывает все элементы на странице по указанному селектору
    /// </summary>
    /// <param name="selector">Селектор веб-элемента</param>
    public IReadOnlyCollection<IWebElement> GetElements(By selector)
    {
        ArgumentNullException.ThrowIfNull(selector);

        return _driver.FindElements(selector);
    }

    /// <summary>
    /// Выбрасывает исключение, если страница не загружена
    /// </summary>
    private void ThrowIfPageNotLoaded()
    {
        if (_driver.Url.Contains(_pageUri.AbsolutePath))
            return;

        throw new InvalidOperationException($"Страница не загружена. Вызовите {nameof(Load)}() перед взаимодействием со страницей");
    }
}