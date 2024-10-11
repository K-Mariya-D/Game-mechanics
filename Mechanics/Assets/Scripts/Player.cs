using UnityEngine;

/// <summary>
/// Скрипт перемещения персонажа
/// </summary>
public class Player : MonoBehaviour
{
    private Transform _body;
    private Animator _animator;
    public float Speed = 5f;
    public bool IsRunning = false;
    void Start()
    {
        _body = this.gameObject.GetComponent<Transform>();
        _animator = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        WASD();
        UpdateRunning();
    }
    /// <summary>
    /// Передвижение игрока посредством клавиатуры 
    /// </summary>
    void WASD()
    {
        if (Input.GetKey(KeyCode.A)) _body.position += Vector3.left * Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) _body.position += Vector3.right * Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) _body.position += Vector3.up * Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) _body.position += Vector3.down * Speed * Time.deltaTime;
    }
    /// <summary>
    /// Проверяет, находится ли игрок в состоянии передвижения
    /// </summary>
    void UpdateRunning()
    {
        if (!Input.anyKey) IsRunning = false;
        else IsRunning = true;
        _animator.SetBool("IsRunning", IsRunning);
    }
}
