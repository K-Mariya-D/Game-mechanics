using TMPro;
using Unity;
using UnityEngine;

/// <summary>
/// ���������, �������������� ������������� �������
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// UI ������� Text, ����������� � �������������� �������
    /// </summary>
    public TextMeshProUGUI UIText { get; }
    /// <summary>
    /// �������� �������������� �������
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// ���������, � ������� ����� ����������������� � ��������
    /// </summary>
    public float Distance { get; }
    /// <summary>
    /// ��������� �� ������ � ��������� ��������������
    /// </summary>
    public bool IsInteractable { get; }
    /// <summary>
    /// ��������� ������������� ����� �� ������
    /// </summary>
    public void PlaceUIText();
    /// <summary>
    /// ���������� UIText � ������������ � ���������� �������
    /// </summary>
    public void ShowUIText();
    /// <summary>
    /// �������������� � ��������
    /// </summary>
    public void Interact();
}