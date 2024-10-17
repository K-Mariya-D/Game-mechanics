using TMPro;
using UnityEngine;

/// <summary>
/// Интерфейс, поддерживающий интерактивные объекты
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// Круглый коллайдер
    /// </summary>
    public CircleCollider2D Collider { get; }
    /// <summary>
    /// Тело, которое взаимодействует с интерактивным объектом
    /// </summary>
    public GameObject CallObject { get; }
    /// <summary>
    /// Дистанция, с которой можно взаимодействовать с объектом
    /// </summary>
    public float Distance { get; }
    /// <summary>
    /// UIText на канвасе
    /// </summary>
    public TextMeshProUGUI UIText { get; }
    /// <summary>
    /// Описание интерактивного объекта
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// Метод, вызывающийся при входе CallObject в Collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision);
    /// <summary>
    /// Метод, вызывающийся, когда CallObject стоит в Collider 
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerStay2D(Collider2D collision);
    /// <summary>
    /// Метод, вызывающийся при выходе CallObject из Collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision);
    /// <summary>
    /// Корректно устанавливает текст на экране
    /// </summary>
    public void PlaceUIText();
    /// <summary>
    /// Отображает UIText
    /// </summary>
    public void ShowUIText();
    /// <summary>
    /// Скрывает UIText
    /// </summary>
    public void HideUIText();
    /// <summary>
    /// Взаимодействие с интерактивным объектом
    /// </summary>
    public void Interact();
}