using System;
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
    public float TimeToNextSpawn { get; }
}
