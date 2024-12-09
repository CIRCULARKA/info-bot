namespace InfoBot.Core.Entities;

/// <summary>
/// Сущность статьи в базе данных
/// </summary>
public class ArticleEntity : Entity
{
    /// <summary>
    /// Ссылка на источник статьи
    /// </summary>
    public Uri Source { get; set; } = null!;

    /// <summary>
    /// Атрибуты статьи
    /// </summary>
    public List<ArticleAttribute> Attributes { get; set; } = null!;
}