using System;
using UnityEngine;

public class Player : MonoBehaviour, IMoving, ITransform
{
    /// <summary>
    /// Скорость
    /// </summary>
    [SerializeField] private float _speed;
    public float Speed { get => _speed; private set
        {
            if (value < 0f) throw new ArgumentOutOfRangeException("Player >> Speed < 0");
            _speed = value;
        }
    }
    /// <summary>
    /// Находится ли объект в состоянии движения?
    /// </summary>
    [SerializeField] private bool _isMoving;
    public bool IsMoving { get => _isMoving; private set => _isMoving = value; }
    /// <summary>
    /// Каркас
    /// </summary>
    private Transform _trans;
    public Transform Trans { get => _trans; private set => _trans = value; }
    /// <summary>
    /// Перемещение игрока посредством клавиатуры
    /// </summary>
    void Start()
    {
        Trans = this.GetComponent<Transform>();
    }
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        IsMoving = false;
        if (Input.GetKey(KeyCode.A))
        {
            Trans.position += Vector3.left * Speed * Time.deltaTime;
            IsMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Trans.position += Vector3.right * Speed * Time.deltaTime;
            IsMoving = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Trans.position += Vector3.up * Speed * Time.deltaTime;
            IsMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Trans.position += Vector3.down * Speed * Time.deltaTime;
            IsMoving = true;
        }
    }
}
