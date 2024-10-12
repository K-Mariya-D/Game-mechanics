using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс, поддерживающий бегающие объекты
/// </summary>
public interface IRunning
{
    /// <summary>
    /// Буст к скорости
    /// </summary>
    float Boost { get; }
    /// <summary>
    /// Бежит ли объект
    /// </summary>
    bool IsRunning { get; }
    /// <summary>
    /// Ускорение
    /// </summary>
    void SpeedBoost();
    /// <summary>
    /// Изменяет состояние объекта
    /// </summary>
    void ChangeIsRunning();
}
