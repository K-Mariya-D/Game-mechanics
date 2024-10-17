using TMPro;
using UnityEngine;

/// <summary>
/// ���������, �������������� ������������� �������
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// ������� ���������
    /// </summary>
    public CircleCollider2D Collider { get; }
    /// <summary>
    /// ����, ������� ��������������� � ������������� ��������
    /// </summary>
    public GameObject CallObject { get; }
    /// <summary>
    /// ���������, � ������� ����� ����������������� � ��������
    /// </summary>
    public float Distance { get; }
    /// <summary>
    /// UIText �� �������
    /// </summary>
    public TextMeshProUGUI UIText { get; }
    /// <summary>
    /// ����� � UIText
    /// </summary>
    public Font Font { get; }
    /// <summary>
    /// �������� �������������� �������
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// ��������� �� ������ � ��������� ��������������
    /// </summary>
    public bool IsReadyInteractable { get; }
    /// <summary>
    /// ��������� ������������� ����� �� ������
    /// </summary>
    public void PlaceUIText();
    /// <summary>
    /// ���������� ��������� UIText � ������������ � IsReadyInteractable
    /// </summary>
    void SetUIText();
    /// <summary>
    /// �������������� � ������������� ��������
    /// </summary>
    public void Interact();
}