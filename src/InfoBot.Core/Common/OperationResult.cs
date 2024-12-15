namespace InfoBot.Core.Common;

/// <summary>
/// Результат выполнения операции
/// </summary>
public abstract class OperationResult
{
    /// <summary>
    /// Индикатор успешности операции
    /// </summary>
    public bool IsSuccessful { get; protected set; }

    /// <summary>
    /// Сообщение об ошибке, если операция неуспешная
    /// </summary>
    public string? ErrorMessage { get; protected set; }
}