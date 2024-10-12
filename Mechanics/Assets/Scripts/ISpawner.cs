using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    /// <summary>
    /// ����������� ��������
    /// </summary>
    public GameObject Entity { get; }
    /// <summary>
    /// ������� ��������� ���������
    /// </summary>
    public float Frequency { get; }
    /// <summary>
    /// ����� �� ���������� ���������
    /// </summary>
    public float TimeToNextSpawn { get; }
    /// <summary>
    /// ������� ��������� ���������
    /// </summary>
    public Queue<GameObject> QueueEntity { get; }
    /// <summary>
    /// ������������ ����� ��������� ������� ����� ���������
    /// </summary>
    public int MaxSpawnCount { get; }
    /// <summary>
    /// ������ ��������
    /// </summary>
    void SpawnEntity(Vector3 position, Quaternion rotation);
    /// <summary>
    /// ������� ��������� ��������
    /// </summary>
    void RemoveEntity();
}
