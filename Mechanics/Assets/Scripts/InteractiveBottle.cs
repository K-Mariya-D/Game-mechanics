using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class InteractiveBottle : MonoBehaviour, IInteractable
{
    /// <summary>
    /// ������� ���������
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
    /// ����, ������� ��������������� � ������������� ��������
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
    /// UIText �� �������
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
    /// ��������
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
    private bool _isReadyInteractable = false;
    public bool IsReadyInteractable
    {
        get => _isReadyInteractable;
        private set => _isReadyInteractable = value;
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
    /// <summary>
    /// �����, ������������ ��� ������ �����
    /// </summary>
    private void Start()
    {
        //��������� UIText
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        UIText = new GameObject("TextMeshProUGUI").AddComponent<TextMeshProUGUI>(); //�������� UIText
        UIText.gameObject.SetActive(false); //������� UIText
        UIText.text = Description; //��������� ��������
        UIText.alignment = TextAlignmentOptions.Center; //��������� ��������������� ��������� UIText
        UIText.transform.SetParent(canvas.transform, false); //�������� � canvas

        //��������� Collider
        Collider = this.AddComponent<CircleCollider2D>(); //�������� Collider
        Collider.radius = Distance; //��������� ������� Collider
        Collider.isTrigger = true; //��������� ��������
    }
    /// <summary>
    /// �����, ������������ ��� ����� CallObject � Collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag(CallObject.tag))
        {
            PlaceUIText(); //����������� ��������� UIText �� ������
            ShowUIText(); //����������� UIText
        }
    }
    /// <summary>
    /// �����, ������������, ����� CallObject ����� � Collider 
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag(CallObject.tag))
        {
            Interact(); //�������������� � ������������� ��������
        }
    }
    /// <summary>
    /// �����, ������������ ��� ������ CallObject �� Collider
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag(CallObject.tag))
        {
            HideUIText(); //������� UIText
        }
    }
    /// <summary>
    /// ������������� UIText �� ������
    /// </summary>
    public void PlaceUIText() => UIText.rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position + Vector3.up * 1.2f);
    /// <summary>
    /// ���������� UIText
    /// </summary>
    public void ShowUIText() => UIText.gameObject.SetActive(true);
    /// <summary>
    /// �������� UIText
    /// </summary>
    public void HideUIText() => UIText.gameObject.SetActive(false);
    /// <summary>
    /// �������������� � ������������� ��������
    /// </summary>
    public void Interact()
    {
        if (IsReadyInteractable && Input.GetKey(KeyCode.E))
        {
            //���� ��� ������������� ������ ������������
            Destroy(UIText.gameObject);
            Destroy(this.gameObject);
        }
    }
}
