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
    /// Время до следующего появления существа
    /// </summary>
    public float TimeToNextSpawn { get; }
    /// <summary>
    /// Очередь созданных сущностей
    /// </summary>
    public Queue<GameObject> QueueEntity { get; }
    /// <summary>
    /// Максимальное число созданных на одной сцене существ данным спавнером
    /// </summary>
    public int MaxSpawnCount { get; }
    /// <summary>
    /// Создаёт сущность на сцене
    /// </summary>
    void SpawnEntity(Vector3 position, Quaternion rotation);
    /// <summary>
    /// Удаляет созданную на сцене сущность
    /// </summary>
    void RemoveEntity();
}
