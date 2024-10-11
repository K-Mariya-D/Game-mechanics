using System;
using UnityEngine;

public interface ISpawner
{
    /// <summary>
    /// Создаваемая сущность
    /// </summary>
    public GameObject Entity { get; }
    /// <summary>
    /// Частота появления сущностей
    /// </summary>
    public float Frequency { get; }
    public float TimeToNextSpawn { get; }
}
