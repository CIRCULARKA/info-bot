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
    public Uri Source { get; init; } = null!;

    /// <summary>
    /// Атрибуты статьи
    /// </summary>
    public List<ArticleAttribute> Attributes { get; init; } = null!;

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

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append($"{{ {nameof(Source)}='{Source}', {nameof(Attributes)}: ");
        builder.Append(string.Join(", ", Attributes));
        builder.Append(" }");

        return builder.ToString();
    }
}