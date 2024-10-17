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
    /// Шрифт к UIText
    /// </summary>
    public Font Font { get; }
    /// <summary>
    /// Описание интерактивного объекта
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// Находится ли объект в состоянии взаимодействия
    /// </summary>
    public bool IsReadyInteractable { get; }
    /// <summary>
    /// Корректно устанавливает текст на экране
    /// </summary>
    public void PlaceUIText();
    /// <summary>
    /// Определяет состояние UIText в соответствие с IsReadyInteractable
    /// </summary>
    void SetUIText();
    /// <summary>
    /// Взаимодействие с интерактивным объектом
    /// </summary>
    public void Interact();
}