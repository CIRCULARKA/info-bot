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
    public List<ArticleAttributeEntity> Attributes { get; set; } = null!;

    /// <summary>
    /// Было ли сообщение отправленно
    /// </summary>
    public bool IsSent { get; set; }
}