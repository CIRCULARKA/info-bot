using InfoBot.Core.Entities;

namespace InfoBot.Core.Models;

/// <summary>
/// Атрибут статьи. У каждой статьи может быть набор атрибутов со своими значениями,
/// например, это может быть заголовок статьи, её контент, различные теги и другое
/// </summary>
public class ArticleAttribute
{
    private ArticleAttributeEntity _entity = null;
    
    /// <summary>
    /// Название атрибута
    /// </summary>
    public string Name { get; private init; } = null!;

    /// <summary>
    /// Значение атрибута
    /// </summary>
    public string Value { get; private init; } = null!;

    /// <summary>
    /// Конвертирует сущность в доменный объект
    /// </summary>
    /// <param name="entity">Сущность из бд</param>
    public static ArticleAttribute CreateFrom(ArticleAttributeEntity entity) =>
        new ArticleAttribute()
        {
            Name = entity.Name,
            Value = entity.Value
        };

    public ArticleAttributeEntity ToEntity()   
    {
        if (_entity == null)
            _entity = new ArticleAttributeEntity();
        
        _entity.Name = Name;
        _entity.Value = Value;

        return _entity;
    }
}