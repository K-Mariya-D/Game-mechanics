using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������, �������������� �������� �������
/// </summary>
public interface IRunning
{
    /// <summary>
    /// ���� � ��������
    /// </summary>
    float RunSpeed { get; }
    /// <summary>
    /// ����� �� ������
    /// </summary>
    bool IsRunning { get; }
}
