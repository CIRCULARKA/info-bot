namespace InfoBot.Core.Reading.Resources;

/// <summary>
/// Интерфейс главной страницы ресурса с информацией
/// </summary>
public interface IResourceMainPage
{
    /// <summary>
    /// Считывает последние статьи с главной страницы ресурса
    /// </summary>
    public List<Article> ReadLatestArticles();
}