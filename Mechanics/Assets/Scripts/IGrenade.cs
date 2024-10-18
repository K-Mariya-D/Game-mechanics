using System;
using System.Collections.Generic;
using UnityEngine;

public interface IGrenade
{
    /// <summary>
    /// ������ � ������ ��� ������������ ��������� ������� ����
    /// </summary>
    public Camera Camera { get; }
    /// <summary>
    /// ������ �������
    /// </summary>
    public GameObject Prefab { get; }
    /// <summary>
    /// ����� �������� �������
    /// </summary>
    public void ThrowGranade();
}
