using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс, поддерживающий бегающие объекты
/// </summary>
public interface IRunning
{
    /// <summary>
    /// Каркас
    /// </summary>
    public Transform Trans { get; }
    /// <summary>
    /// Скорость бега
    /// </summary>
    float RunSpeed { get; }
    /// <summary>
    /// Состояние передвижения бегом
    /// </summary>
    bool IsRunning { get; }
}
