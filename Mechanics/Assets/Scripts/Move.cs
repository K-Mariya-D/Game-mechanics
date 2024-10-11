using UnityEngine;

//Скрипт перемещения персонажа
public class Move : MonoBehaviour
{
    private Transform _body;
    private Animator _animator;
    public float Speed = 5f;
    private bool _isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        _body = this.gameObject.GetComponent<Transform>();
        _animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
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
        if (!Input.anyKey) _isRunning = false;
        else _isRunning = true;
        _animator.SetBool("IsRunning", _isRunning);
    }
}
