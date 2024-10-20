using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Фиксирует столкновение гранаты с другими обектами (Collodir2D Ridgitbody2D). Скрипт навешивается на префаб гранаты
/// </summary>
public class grenade1 : MonoBehaviour
{
    /// <summary>
    /// Конечная позиция гранаты
    /// </summary>
    public Vector3 EndPos { get; set; }

    /// <summary>
    /// Столкнулась ли граната с чем-либо 
    /// </summary>
    public bool Collision { get; private set; }

    private void Start()
    {
        Collision = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Триггер сработал!");
        Collision = true;
        //Удаляет обект с задежкой. (Без задержки скрипт Grenade не успевает получить инфу о столкновении)
        Destroy(gameObject, 0.1f);
    }
    
    private void Update()
    {
       // Debug.Log(transform.position);
        //Debug.Log(EndPos);
        if (transform.position.x == EndPos.x && transform.position.y == EndPos.y)
        {
            Collision = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
