using UnityEngine;

/// <summary>
/// Интерфейс, поддерживающий анимированные объекты
/// </summary>
public interface IAnimated
{
    /// <summary>
    /// Аниматор
    /// </summary>
    public Animator Animator { get; }
}
