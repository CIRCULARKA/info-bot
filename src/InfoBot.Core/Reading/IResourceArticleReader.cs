namespace InfoBot.Core.Reading;

/// <summary>
/// Интерфейс для объекта, считывающего статьи с определённого ресурса
/// </summary>
public interface IResourceArticleReader
{
    /// <summary>
    /// Считывает последние статьи с ресурса
    /// </summary>
    public List<Article> ReadLatest();
}