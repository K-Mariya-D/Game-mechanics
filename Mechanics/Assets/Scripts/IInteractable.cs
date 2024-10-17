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
    /// �������� �������������� �������
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// �����, ������������ ��� ����� CallObject � Collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision);
    /// <summary>
    /// �����, ������������, ����� CallObject ����� � Collider 
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerStay2D(Collider2D collision);
    /// <summary>
    /// �����, ������������ ��� ������ CallObject �� Collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision);
    /// <summary>
    /// ��������� ������������� ����� �� ������
    /// </summary>
    public void PlaceUIText();
    /// <summary>
    /// ���������� UIText
    /// </summary>
    public void ShowUIText();
    /// <summary>
    /// �������� UIText
    /// </summary>
    public void HideUIText();
    /// <summary>
    /// �������������� � ������������� ��������
    /// </summary>
    public void Interact();
}