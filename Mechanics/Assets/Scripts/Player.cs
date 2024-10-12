using System;
using UnityEngine;

/// <summary>
/// �����
/// </summary>
public class Player : MonoBehaviour, IMoving
{
    /// <summary>
    /// ��������
    /// </summary>
    [SerializeField] private float _speed;
    public float Speed
    {
        get => _speed; private set
        {
            if (value < 0f) throw new ArgumentOutOfRangeException("Player >> Speed < 0");
            _speed = value;
        }
    }
    /// <summary>
    /// ��������� �� ������ � ��������� ��������?
    /// </summary>
    [SerializeField] private bool _isMoving;
    public bool IsMoving { get => _isMoving; private set => _isMoving = value; }
    /// <summary>
    /// ������
    /// </summary>
    private Transform _trans;
    public Transform Trans { get => _trans; private set => _trans = value; }
    /// <summary>
    /// ����������� ������ ����������� ����������
    /// </summary>
    void Start()
    {
        Trans = this.GetComponent<Transform>();
    }
    void Update()
    {
        Move();
    }
    /// <summary>
    /// ����������� ������
    /// </summary>
    public void Move()
    {
        IsMoving = false;
        if (Input.GetKey(KeyCode.A))
        {
            Trans.position += Vector3.left * Speed * Time.deltaTime;
            ChangeIsMoving();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Trans.position += Vector3.right * Speed * Time.deltaTime;
            ChangeIsMoving();
        }
        if (Input.GetKey(KeyCode.W))
        {
            Trans.position += Vector3.up * Speed * Time.deltaTime;
            ChangeIsMoving();
        }
        if (Input.GetKey(KeyCode.S))
        {
            Trans.position += Vector3.down * Speed * Time.deltaTime;
            ChangeIsMoving();
        }
    }
    /// <summary>
    /// �������� ��������� ������
    /// </summary>
    public void ChangeIsMoving() => IsMoving = !IsMoving;
}
