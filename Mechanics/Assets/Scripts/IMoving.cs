using UnityEngine;

/// <summary>
/// Интерфейс, поддерживающий движущиеся объекты
/// </summary>
public interface IMoving
{
    /// <summary>
    /// Каркас
    /// </summary>
    public Transform Trans { get; }
    /// <summary>
    /// Скорость
    /// </summary>
    public float Speed { get; }
    /// <summary>
    /// Находится ли объект в состоянии движения?
    /// </summary>
    public bool IsMoving { get; }
    /// <summary>
    /// Перемещение объекта
    /// </summary>
    void Move();
    /// <summary>
    /// Изменяет состояние объекта
    /// </summary>
    void ChangeIsMoving();
}
