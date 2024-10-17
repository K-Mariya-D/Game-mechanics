using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class InteractiveBottle : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Круглый коллайдер
    /// </summary>
    private CircleCollider2D _collider;
    public CircleCollider2D Collider
    {
        get => _collider;
        private set
        {
            if (value == null) throw new ArgumentNullException("Collider is null");
            _collider = value;
        }
    }
    /// <summary>
    /// Тело, которое взаимодействует с интерактивным объектом
    /// </summary>
    [SerializeField] private GameObject _callObject;
    public GameObject CallObject
    {
        get => _callObject;
        private set
        {
            if (value == null) throw new ArgumentNullException("InteractiveBottle: CallObject is null");
            _callObject = value;
        }
    }
    /// <summary>
    /// UIText на канвасе
    /// </summary>
    [SerializeField] private TextMeshProUGUI _uIText;
    public TextMeshProUGUI UIText
    {
        get => _uIText;
        private set
        {
            if (value == null) throw new ArgumentNullException("InteractiveBottle: UIText is null");
            _uIText = value;
        }
    }
    /// <summary>
    /// Описание
    /// </summary>
    [SerializeField] private string _description;
    public string Description
    {
        get => _description;
        private set
        {
            if (value == null) throw new ArgumentNullException("InteractiveBottle: Description is null");
            if (value.Length == 0) throw new ArgumentNullException("InteractiveBottle: Description is empty");
            _description = value;
        }
    }
    /// <summary>
    /// Находится ли объект в состоянии взаимодействия
    /// </summary>
    private bool _isReadyInteractable = false;
    public bool IsReadyInteractable
    {
        get => _isReadyInteractable;
        private set => _isReadyInteractable = value;
    }
    /// <summary>
    /// Дистанция, с которой можно взаимодействовать с объектом
    /// </summary>
    [SerializeField] private float _distance;
    public float Distance
    {
        get => _distance;
        private set
        {
            if (value < 0f) throw new ArgumentOutOfRangeException("InteractiveBottle: Distance < 0");
            _distance = value;
        }
    }
    /// <summary>
    /// Метод, вызывающийся при старте сцены
    /// </summary>
    private void Start()
    {
        //Настройка UIText
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        UIText = new GameObject("TextMeshProUGUI").AddComponent<TextMeshProUGUI>(); //Создание UIText
        UIText.gameObject.SetActive(false); //Скрытие UIText
        UIText.text = Description; //Установка описания
        UIText.alignment = TextAlignmentOptions.Center; //Установка геометрического положения UIText
        UIText.transform.SetParent(canvas.transform, false); //Привязка к canvas

        //Настройка Collider
        Collider = this.AddComponent<CircleCollider2D>(); //Создание Collider
        Collider.radius = Distance; //Установка радиуса Collider
        Collider.isTrigger = true; //Установка триггера
    }
    /// <summary>
    /// Метод, вызывающийся при входе CallObject в Collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag(CallObject.tag))
        {
            PlaceUIText(); //Определение положения UIText на экране
            ShowUIText(); //Отображение UIText
        }
    }
    /// <summary>
    /// Метод, вызывающийся, когда CallObject стоит в Collider 
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag(CallObject.tag))
        {
            Interact(); //Взаимодействие с интерактивным объектом
        }
    }
    /// <summary>
    /// Метод, вызывающийся при выходе CallObject из Collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag(CallObject.tag))
        {
            HideUIText(); //Скрытие UIText
        }
    }
    /// <summary>
    /// Устанавливает UIText на экране
    /// </summary>
    public void PlaceUIText() => UIText.rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position + Vector3.up * 1.2f);
    /// <summary>
    /// Отображает UIText
    /// </summary>
    public void ShowUIText() => UIText.gameObject.SetActive(true);
    /// <summary>
    /// Скрывает UIText
    /// </summary>
    public void HideUIText() => UIText.gameObject.SetActive(false);
    /// <summary>
    /// Взаимодействие с интерактивным объектом
    /// </summary>
    public void Interact()
    {
        if (IsReadyInteractable && Input.GetKey(KeyCode.E))
        {
            //Пока что интерактивный объект уничтожается
            Destroy(UIText.gameObject);
            Destroy(this.gameObject);
        }
    }
}
