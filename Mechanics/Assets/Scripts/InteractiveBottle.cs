using System;
using TMPro;
using UnityEngine;
public class InteractiveBottle : MonoBehaviour, IInteractable
{
    /// <summary>
    /// UIText на канвасе CallObject
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
    private bool _isInteractable = false;
    public bool IsInteractable
    {
        get => _isInteractable;
        private set
        {
            _isInteractable = value;
        }
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
    /// Тело, взаимодействующее с интерактивным объектом
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
    private void Start()
    {
        //Настройка UIText
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        UIText = new GameObject("TextMeshProUGUI").AddComponent<TextMeshProUGUI>();
        UIText.text = Description;
        UIText.alignment = TextAlignmentOptions.Center;
        UIText.transform.SetParent(canvas.transform, false);
        //Настройка Collider

    }
    public void Update()
    {
        PlaceUIText();
        ShowUIText();
        Interact();
    }
    /// <summary>
    /// Устанавливает UIText на экране
    /// </summary>
    public void PlaceUIText() => UIText.rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position + Vector3.up * 1.2f);
    /// <summary>
    /// Отображает UIText в соответствие с состоянием IsInteractable
    /// </summary>
    public void ShowUIText()
    {
        IsInteractable = false;
        if (Vector3.Distance(this.transform.position, CallObject.transform.position) <= Distance) IsInteractable = true;
        UIText.gameObject.SetActive(IsInteractable);
    }
    /// <summary>
    /// Взаимодействие с интерактивным объектом
    /// </summary>
    public void Interact()
    {
        if (IsInteractable && Input.GetKey(KeyCode.E))
        {
            //Пока что происходит уничтожение объекта
            Destroy(UIText.gameObject);
            Destroy(this.gameObject);
        }
    }
}
