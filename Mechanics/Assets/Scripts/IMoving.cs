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
    /// Скорость пешком
    /// </summary>
    public float WalkSpeed { get; }
    /// <summary>
    /// Состояние передвижения пешком
    /// </summary>
    public bool IsMoving { get; }
}
