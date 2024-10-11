using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnerTraces : MonoBehaviour, ISpawner, ITimer
{
    [SerializeField]
    private GameObject _entitye;
    /// <summary>
    /// Сущность
    /// </summary>
    public GameObject Entity { get => _entitye; }
    /// <summary>
    /// Время появления последнего следа
    /// </summary>
    public DateTime LastSpawn { get; private set;  } = DateTime.MinValue;
    /// <summary>
    /// Интервал времени между появлениями/событиями
    /// </summary>
    public TimeSpan _interval { get; private set; }
    /// <summary>
    /// Время появления первого следа
    /// </summary>
    public DateTime FirstSpawn { get; private set; }
    /// <summary>
    /// Очередь следов
    /// </summary>
    public Queue<GameObject> _queueEntity { get; private set; }
    /// <summary>
    /// Тот, кто оставляет следы
    /// </summary>
    [SerializeField]
    private Player _player;
    /// <summary>
    /// Появление следа
    /// </summary>
    public void Start()
    {
        _interval = new TimeSpan(0, 0, 5);
        _queueEntity = new Queue<GameObject>();
    }
    public void Update()
    {
        Spawn();
        Remove();
    }
    /// <summary>
    /// Появление следа
    /// </summary>
    public void Spawn()
    {
        if (DateTime.Now - LastSpawn > _interval && _player.IsRunning)
        {
            _queueEntity.Enqueue(Instantiate(Entity));
            LastSpawn = DateTime.Now;
        }
    }
    /// <summary>
    /// Удаление первого появившегося следа
    /// </summary>
    public void Remove()
    {
        if (_queueEntity.Count > 5) DestroyImmediate(_queueEntity.Dequeue());
    }

}
