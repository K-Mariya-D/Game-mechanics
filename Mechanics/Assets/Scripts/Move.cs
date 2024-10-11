using UnityEngine;

//Скрипт перемещения персонажа
public class Move : MonoBehaviour
{
    public float Speed = 5f;
    private Transform _body;
    // Start is called before the first frame update
    void Start()
    {
        _body = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        WASD();
    }
    /// <summary>
    /// Передвижение игрока посредством клавиатуры 
    /// </summary>
    void WASD()
    {
        if (Input.GetKey(KeyCode.A)) _body.position += Vector3.left * Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) _body.position += Vector3.right * Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) _body.position += Vector3.up * Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) _body.position += Vector3.down * Speed * Time.deltaTime ;
    }
}
