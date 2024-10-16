using TMPro;
using Unity;
using UnityEngine;

/// <summary>
/// Интерфейс, поддерживающий интерактивные объекты
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// UI элемент Text, привязанный к интерактивному объекты
    /// </summary>
    public TextMeshProUGUI UIText { get; }
    /// <summary>
    /// Описание интерактивного объекта
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// Дистанция, с которой можно взаимодействовать с объектом
    /// </summary>
    public float Distance { get; }
    /// <summary>
    /// Находится ли объект в состоянии взаимодействия
    /// </summary>
    public bool IsInteractable { get; }
    /// <summary>
    /// Корректно устанавливает текст на экране
    /// </summary>
    public void PlaceUIText();
    /// <summary>
    /// Отображает UIText в соответствие с состоянием объекта
    /// </summary>
    public void ShowUIText();
    /// <summary>
    /// Взаимодействие с объектом
    /// </summary>
    public void Interact();
}