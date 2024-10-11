using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerWithQueue : MonoBehaviour, ISpawner
{
    /// <summary>
    /// Создаваемая сущность
    /// </summary>
    [SerializeField] private GameObject _entity;
    public GameObject Entity {
        get => _entity;
        protected set => _entity = value;
    }
    /// <summary>
    /// Частота появления сущностей
    /// </summary>
    [SerializeField] private float _frequency = 0f;
    public float Frequency {
        get => _frequency;
        protected set
        {
            if (value < 0f) throw new ArgumentOutOfRangeException("SpawnerWithQueue >> Frequency < 0");
            _frequency = value;
        }
    }
    /// <summary>
    /// Оставшееся время до следующего появления сущности
    /// </summary>
    private float _timeToNextSpawn = 0f;
    public float TimeToNextSpawn {
        get => _timeToNextSpawn;
        protected set => _timeToNextSpawn = value;
    }
    /// <summary>
    /// Очередь созданных сущностей
    /// </summary>
    private Queue<GameObject> _queueEntity;
    public Queue<GameObject> QueueEntity { get => _queueEntity; protected set => _queueEntity = value; }
    /// <summary>
    /// Максимальное число сущностей, находящихся на одной сцене одновременно
    /// </summary>
    [SerializeField] private int _spawnCount = 0;
    public int SpawnCount {
        get => _spawnCount;
        protected set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("SpawnerWithQueue >> SpawnCount < 0");
            _spawnCount = value;
        }
    }
    public virtual void Start()
    {
        if (Entity == null) throw new ArgumentNullException("SpawnerWithQueue >> Entity is null");
        QueueEntity = new Queue<GameObject>();
    }
    public abstract void Update();
    /// <summary>
    /// Спавнит сущность и добавляет её в очередь
    /// </summary>
    public abstract void Spawn(Vector3 position, Quaternion rotation);
    /// <summary>
    /// Выкидывает сущность из очереди
    /// </summary>
    public abstract void Kill();
}
