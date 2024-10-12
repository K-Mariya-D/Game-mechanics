using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour, ISpawner
{
    /// <summary>
    /// ����������� ��������
    /// </summary>
    [SerializeField] private GameObject _entity;
    public GameObject Entity
    {
        get => _entity;
        protected set => _entity = value;
    }
    /// <summary>
    /// ������� ��������� ���������
    /// </summary>
    [SerializeField] private float _frequency = 0f;
    public float Frequency
    {
        get => _frequency;
        protected set
        {
            if (value < 0f) throw new ArgumentOutOfRangeException("SpawnerWithQueue >> Frequency < 0");
            _frequency = value;
        }
    }
    /// <summary>
    /// ���������� ����� �� ���������� ��������� ��������
    /// </summary>
    private float _timeToNextSpawn = 0f;
    public float TimeToNextSpawn
    {
        get => _timeToNextSpawn;
        protected set => _timeToNextSpawn = value;
    }
    /// <summary>
    /// ������� ��������� ���������
    /// </summary>
    private Queue<GameObject> _queueEntity;
    public Queue<GameObject> QueueEntity
    {
        get => _queueEntity;
        protected set => _queueEntity = value;
    }
    /// <summary>
    /// ������������ ����� ���������, ����������� �� ����� ����� ������������
    /// </summary>
    [SerializeField] private int _maxSpawnCount = 0;
    public int MaxSpawnCount
    {
        get => _maxSpawnCount;
        private set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("SpawnerWithQueue: MaxSpawnCount < 0");
            _maxSpawnCount = value;
        }
    }
    public virtual void Start()
    {
        if (Entity == null) throw new ArgumentNullException("SpawnerWithQueue >> Entity is null");
        QueueEntity = new Queue<GameObject>();
    }
    public abstract void Update();
    /// <summary>
    /// ������� �������� � ��������� � � �������
    /// </summary>
    public abstract void SpawnEntity(Vector3 position, Quaternion rotation);
    /// <summary>
    /// ���������� �������� �� �������
    /// </summary>
    public abstract void RemoveEntity();
}
