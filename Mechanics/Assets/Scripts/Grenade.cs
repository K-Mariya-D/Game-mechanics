using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Класс для броска гранаты. Скрипт навешивается на игрока
/// </summary>
public class Grenade : MonoBehaviour, IGrenade
{
    [SerializeField] private Camera _camera;
    public Camera Camera
    { get => _camera; }

    private GameObject _prefab;  
    public GameObject Prefab
    { 
        get { if (_prefab == null)
                _prefab = Resources.Load<GameObject>("Grenade"); 
            return _prefab; } 
    }
    /// <summary>
    /// Бросок гранаты
    /// </summary>
    public void ThrowGranade()
    {
        GameObject grenade = Instantiate(Prefab, this.transform.position, Quaternion.identity);

        Vector2 distance = Input.mousePosition;
        distance = Camera.ScreenToWorldPoint(distance);

        grenade.GetComponent<Rigidbody2D>().AddForce(distance * 6f, ForceMode2D.Impulse);
    }
 
}
