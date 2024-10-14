using System.Collections.Generic;
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
    /// <summary>
    /// Время до следующего появления
    /// </summary>
    public float TimeToNextSpawn { get; }
    /// <summary>
    /// Очередь созданных сущностей
    /// </summary>
    public Queue<GameObject> QueueEntity { get; }
    /// <summary>
    /// Максимальное число созданных существ одним спавнером
    /// </summary>
    public int MaxSpawnCount { get; }
    /// <summary>
    /// Создаёт сущность
    /// </summary>
    void SpawnEntity(Vector3 position, Quaternion rotation);
    /// <summary>
    /// Удаляет созданную сущность
    /// </summary>
    void RemoveEntity();
}
