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
    public float Speed { get; }
    /// <summary>
    /// ��������� �� ������ � ��������� ��������?
    /// </summary>
    public bool IsMoving { get; }
    /// <summary>
    /// ����������� �������
    /// </summary>
    void Move();
    /// <summary>
    /// �������� ��������� �������
    /// </summary>
    void ChangeIsMoving();
}
