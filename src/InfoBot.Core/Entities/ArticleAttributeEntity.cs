namespace InfoBot.Core.Entities;

/// <summary>
/// Атрибуты статьи. У каждой статьи могут быть свои аттрибуты, зависящие 
/// от выбранного источника.
/// </summary>
public class ArticleAttributeEntity : Entity
{
    /// <summary>
    /// Название аттрибута
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Значение аттрибута
    /// </summary>
    public string Value { get; set; } = null!;
}