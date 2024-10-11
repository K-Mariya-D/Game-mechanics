using UnityEngine;

/// <summary>
/// ���������, �������������� ���������� �������
/// </summary>
public interface IMoving
{
    /// <summary>
    /// ��������
    /// </summary>
    public float Speed { get; }
    /// <summary>
    /// ��������� �� ������ � ��������� ��������?
    /// </summary>
    public bool IsMoving { get; }
}
