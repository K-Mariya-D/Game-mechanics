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
    public float WalkSpeed { get; }
    /// <summary>
    /// Находится ли объект в состоянии движения?
    /// </summary>
    public bool IsMoving { get; }
}
