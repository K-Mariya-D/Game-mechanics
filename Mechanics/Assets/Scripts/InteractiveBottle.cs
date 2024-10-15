using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class InteractiveBottle : MonoBehaviour, IInteractable
{
    /// <summary>
    /// �������� �������������� �������
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
    /// �������� �������������� �������
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
    /// ��������� �� ������ � ��������� ��������������
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
    /// ���������, � ������� ����� ����������������� � ��������
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
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        UIText = new GameObject("TextMeshProUGUI").AddComponent<TextMeshProUGUI>();
        UIText.text = Description;
        UIText.transform.SetParent(canvas.transform, false);
    }

    public void Update()
    {
        PlaceUIText();
        ShowUIText();
        Interact();
    }
    /// <summary>
    /// ��������� ������������� ����� �� ������
    /// </summary>
    public void PlaceUIText()
    {
        UIText.rectTransform.position = GameObject.FindObjectOfType<Camera>().WorldToScreenPoint(this.transform.position + Vector3.up);
    }
    /// <summary>
    /// ���������� UIText � ������������ � ���������� �������
    /// </summary>
    public void ShowUIText()
    {
        IsInteractable = false;
        if (Vector3.Distance(this.transform.position, CallObject.transform.position) <= Distance) IsInteractable = true;
        UIText.gameObject.SetActive(IsInteractable);
    }
    /// <summary>
    /// �������������� � ��������
    /// </summary>
    public void Interact()
    {
        if (IsInteractable && Input.GetKey(KeyCode.E)) this.gameObject.SetActive(false);
    }
}
