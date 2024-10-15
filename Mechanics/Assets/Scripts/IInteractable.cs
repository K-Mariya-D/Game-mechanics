/// <summary>
/// Интерфейс, поддерживающий интерактивные объекты
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// Описание интерактивного объекта
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// Дистанция, с которой можно взаимодействовать с объектом
    /// </summary>
    public float Distance { get; }
    /// <summary>
    /// Взаимодействие с объектом
    /// </summary>
    public void Interactive();
}