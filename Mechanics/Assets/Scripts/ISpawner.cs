using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    /// <summary>
    /// Сущность
    /// </summary>
    GameObject Entity { get; }
    /// <summary>
    /// Очередь сущностей
    /// </summary>
    Queue<GameObject> _queueEntity { get; }
    /// <summary>
    /// Появление существа
    /// </summary>
    void Spawn();
    /// <summary>
    /// Удаление первого появившегося существа
    /// </summary>
    void Remove();
}
