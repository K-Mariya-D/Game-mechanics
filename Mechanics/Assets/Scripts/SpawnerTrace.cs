using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnerTrace : SpawnerWithQueue
{
    /// <summary>
    /// ��������, �� ������� ��� ����
    /// </summary>
    [SerializeField] private Player _player;
    public Player Player { get => _player; private set => _player = value; }
    public override void Start()
    {
        base.Start();
        if (Player == null) throw new ArgumentNullException("SpawnerTrace >> Player is null");
    }
    public override void Update()
    {
        SpawnEntity(Player.Trans.position, Quaternion.identity);
        RemoveEntity();
    }
    /// <summary>
    /// ������� �������� � ��������� � � �������
    /// </summary>
    public override void SpawnEntity(Vector3 position, Quaternion rotation)
    {
        TimeToNextSpawn -= Time.deltaTime;
        if (_player.IsMoving && TimeToNextSpawn <= 0f)
        {
            QueueEntity.Enqueue(Instantiate(Entity, position, rotation));
            TimeToNextSpawn = Frequency;
        }
    }
    /// <summary>
    /// ���������� �������� �� �������
    /// </summary>
    public override void RemoveEntity()
    {
        if (QueueEntity.Count > SpawnCount)
            DestroyImmediate(QueueEntity.Dequeue());
    }
}
