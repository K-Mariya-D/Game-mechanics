using System;
using UnityEngine;

/// <summary>
/// �����
/// </summary>
public class Player : MonoBehaviour, IMoving, IRunning
{
    /// <summary>
    /// ������
    /// </summary>
    private Transform _trans;
    public Transform Trans
    {
        get => _trans;
        private set => _trans = value;
    }
    /// <summary>
    /// �������� ������
    /// </summary>
    [SerializeField] private float _walkSpeed = 4f;
    public float WalkSpeed
    {
        get => _walkSpeed; private set
        {
            if (value < 0f) throw new ArgumentOutOfRangeException("Player: Speed < 0");
            _walkSpeed = value;
        }
    }
    /// <summary>
    /// �������� ����
    /// </summary>
    [SerializeField] private float _runSpeed = 6f;
    public float RunSpeed
    {
        get => _runSpeed;
        private set
        {
            if (value < 0f) throw new ArgumentOutOfRangeException("Player: Boost < 0");
            _runSpeed = value;
        }
    }
    /// <summary>
    /// ��������� ������������ ������
    /// </summary>
    private bool _isMoving = false;
    public bool IsMoving { get => _isMoving; private set => _isMoving = value; }
    /// <summary>
    /// ��������� ������������ �����
    /// </summary>
    private bool _isRunning = false;
    public bool IsRunning
    {
        get => _isRunning;
        private set => _isRunning = value;
    }
    void Start()
    {
        Trans = this.GetComponent<Transform>();
    }
    void Update()
    {
        CheckBoost();
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
            Trans.position += Vector3.left * Speed() * Time.deltaTime;
            IsMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Trans.position += Vector3.right * Speed() * Time.deltaTime;
            IsMoving = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Trans.position += Vector3.up * Speed() * Time.deltaTime;
            IsMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Trans.position += Vector3.down * Speed() * Time.deltaTime;
            IsMoving = true;
        }
    }
    /// <summary>
    /// ���������, ����� �� LeftShift ��� ����
    /// </summary>
    void CheckBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift)) IsRunning = true;
        else IsRunning = false;
    }
    /// <summary>
    /// ���������� �������������� �������� � ����������� �� ��������� ��������
    /// </summary>
    float Speed()
    {
        if (IsRunning) return RunSpeed;
        return WalkSpeed;
    }
}
