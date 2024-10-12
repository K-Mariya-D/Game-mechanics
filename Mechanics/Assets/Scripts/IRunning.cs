using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������, �������������� �������� �������
/// </summary>
public interface IRunning
{
    /// <summary>
    /// ����� �� ������
    /// </summary>
    bool IsRunning { get; }
    /// <summary>
    /// ���������
    /// </summary>
    void SpeedBoost();
}
