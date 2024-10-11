using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnerTraces : MonoBehaviour, ISpawner, ITimer
{
    [SerializeField]
    private GameObject _entitye;
    /// <summary>
    /// ��������
    /// </summary>
    public GameObject Entity { get => _entitye; }
    /// <summary>
    /// ����� ��������� ���������� �����
    /// </summary>
    public DateTime LastSpawn { get; private set;  } = DateTime.MinValue;
    /// <summary>
    /// �������� ������� ����� �����������/���������
    /// </summary>
    public TimeSpan _interval { get; private set; }
    /// <summary>
    /// ����� ��������� ������� �����
    /// </summary>
    public DateTime FirstSpawn { get; private set; }
    /// <summary>
    /// ������� ������
    /// </summary>
    public Queue<GameObject> _queueEntity { get; private set; }
    /// <summary>
    /// ���, ��� ��������� �����
    /// </summary>
    [SerializeField]
    private Player _player;
    /// <summary>
    /// ��������� �����
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
    /// ��������� �����
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
    /// �������� ������� ������������ �����
    /// </summary>
    public void Remove()
    {
        if (_queueEntity.Count > 5) DestroyImmediate(_queueEntity.Dequeue());
    }

}
