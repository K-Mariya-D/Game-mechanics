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
    float Boost { get; }
    /// <summary>
    /// ����� �� ������
    /// </summary>
    bool IsRunning { get; }
    /// <summary>
    /// ���������
    /// </summary>
    void SpeedBoost();
    /// <summary>
    /// �������� ��������� �������
    /// </summary>
    void ChangeIsRunning();
}
