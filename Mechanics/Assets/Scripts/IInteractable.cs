/// <summary>
/// ���������, �������������� ������������� �������
/// </summary>
public interface IInteractable
{
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
    /// �������������� � ��������
    /// </summary>
    public void Interact();
}