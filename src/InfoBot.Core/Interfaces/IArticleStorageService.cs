using InfoBot.Core.Common;

namespace InfoBot.Core.Interfaces;

/// <summary>
/// Интерфейс для взаимодействия с хранилищем
/// </summary>
public interface IArticleStorageService
{
    /// <summary>
    /// Метод сохраняющий данные статьи
    /// </summary>
    public OperationResult Save();
}