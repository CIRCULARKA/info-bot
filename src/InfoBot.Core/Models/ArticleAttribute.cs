namespace InfoBot.Core.Models;

/// <summary>
/// Атрибут статьи. У каждой статьи может быть набор атрибутов со своими значениями,
/// например, это может быть заголовок статьи, её контент, различные теги и другое
/// </summary>
public class ArticleAttribute
{
    /// <summary>
    /// Название атрибута
    /// </summary>
    public string Name { get; private init; } = null!;

    /// <summary>
    /// Значение атрибута
    /// </summary>
    public string Value { get; private init; } = null!;
}
