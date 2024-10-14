using System;
using UnityEngine;

/// <summary>
/// Игрок
/// </summary>
public class Player : MonoBehaviour, IMoving, IRunning
{
    /// <summary>
    /// Скорость
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
    /// Находится ли объект в состоянии движения?
    /// </summary>
    private bool _isMoving;
    public bool IsMoving { get => _isMoving; private set => _isMoving = value; }
    /// <summary>
    /// Каркас
    /// </summary>
    private Transform _trans;
    public Transform Trans { get => _trans; private set => _trans = value; }
    /// <summary>
    /// Бежит ли объект
    /// </summary>
    private bool _isRunning;
    public bool IsRunning
    {
        get => _isRunning;
        private set => _isRunning = value;
    }
    /// <summary>
    /// Буст к скорости
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
    /// Перемещение игрока посредством клавиатуры
    /// </summary>
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
    /// Перемещение игрока
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
    /// Проверяет, ускорен объект или нет.
    /// </summary>
    void CheckBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift)) IsRunning = true;
        else IsRunning = false;
    }
    /// <summary>
    /// Возвращает конечную скорость игрока
    /// </summary>
    float Speed()
    {
        if (IsRunning) return RunSpeed;
        return WalkSpeed;
    }
}
