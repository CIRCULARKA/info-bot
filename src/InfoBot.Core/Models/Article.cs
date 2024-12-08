namespace InfoBot.Core.Models;

/// <summary>
/// Статья на каком-либо ресурсе
/// </summary>
public class Article
{
    /// <summary>
    /// Ссылка на источник статьи
    /// </summary>
    public Uri Source { get; private init; } = null!;

    /// <summary>
    /// Атрибуты статьи
    /// </summary>
    public List<ArticleAttribute> Attributes { get; private init; } = null!;
}
