using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Добавляет эффекты при столкновении гранаты с другими объектами. Скрипт навешивается на префаб гранаты
/// </summary>
public class grenade1 : MonoBehaviour
{
    private  GameObject _camera;
    private void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Триггер сработал!");
        _camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.3f, null);
    }
}
