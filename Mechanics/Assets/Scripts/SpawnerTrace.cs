using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnerTrace : SpawnerWithQueue
{
    /// <summary>
    /// ���, ��� ��������� �����
    /// </summary>
    [SerializeField] private IMoving _leavesTraces;
    public IMoving LeavesTraces {
        get => _leavesTraces;
        private set => _leavesTraces = value; }
    public override void Start()
    {
        base.Start();
        _leavesTraces = GameObject.FindWithTag("Player").GetComponent<IMoving>();
    }
    public override void Update()
    {
        SpawnEntity(_leavesTraces.Trans.position, Quaternion.identity);
        RemoveEntity();
    }
    /// <summary>
    /// ������� �������� � ��������� � � �������
    /// </summary>
    public override void SpawnEntity(Vector3 position, Quaternion rotation)
    {
        TimeToNextSpawn -= Time.deltaTime;
        if (_leavesTraces.IsMoving && TimeToNextSpawn <= 0f)
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
        if (QueueEntity.Count > MaxSpawnCount)
            DestroyImmediate(QueueEntity.Dequeue());
    }
}
