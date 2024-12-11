using InfoBot.Core.Entities;

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

    /// <summary>
    /// Была ли статья отправленна
    /// </summary>
    public bool IsSent { get; set; }

    static Article CreateFrom(ArticleEntity entity) =>       
        new Article()  
        {
            Source = entity.Source,
            Attributes = entity.Attributes.Select(a => ArticleAttribute.CreateFrom(a)).ToList()            
        };
}