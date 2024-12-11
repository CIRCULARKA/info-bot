namespace InfoBot.Selenium.Reading;

/// <summary>
/// Описывает, как атрибут выглядит на странице
/// </summary>
public class AttributeSelector
{
    /// <summary>
    /// Название атрибута
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Селектор, с помощью которого можно извлечь атрибут из страницы
    /// </summary>
    /// <remarks>
    /// Селектор строится относительно веб-элемента всей статьи
    /// </remakrs>
    public By Selector { get; init; } = null!;
}