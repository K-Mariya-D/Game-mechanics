using UnityEngine;

/// <summary>
/// ���������, �������������� ���������� �������
/// </summary>
public interface IMoving
{
    /// <summary>
    /// ������
    /// </summary>
    public Transform Trans { get; }
    /// <summary>
    /// ��������
    /// </summary>
    public float WalkSpeed { get; }
    /// <summary>
    /// ��������� �� ������ � ��������� ��������?
    /// </summary>
    public bool IsMoving { get; }
}
