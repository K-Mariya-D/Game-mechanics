using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Фиксирует столкновение гранаты с другими обектами (Collodir2D Ridgitbody2D). Скрипт навешивается на префаб гранаты
/// </summary>
public class grenade1 : MonoBehaviour
{
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
}
