using InfoBot.Core.Entities;

namespace InfoBot.Core.Models;

/// <summary>
/// Статья на каком-либо ресурсе
/// </summary>
public class Article
{
    private ArticleEntity? _entity;

    /// <summary>
    /// Ссылка на источник статьи
    /// </summary>
    public Uri Source { get; init; } = null!;

    /// <summary>
    /// Атрибуты статьи
    /// </summary>
    public List<ArticleAttribute> Attributes { get; init; } = null!;

    /// <summary>
    /// Была ли статья отправленна
    /// </summary>
    public bool IsSent { get; set; }

    public static Article CreateFrom(ArticleEntity entity)
    {
        var newArticle = new Article()  
        {
            Source = entity.Source,
            Attributes = entity.Attributes.Select(a => ArticleAttribute.CreateFrom(a)).ToList()            
        };
}