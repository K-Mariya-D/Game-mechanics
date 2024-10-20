﻿using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Класс для броска гранаты. Скрипт навешивается на игрока
/// </summary>
public class Grenade : MonoBehaviour, IGrenade
{
    //Для позиции игрока
    private Transform _trans;
    //Граната
    private GameObject grenade;

    private Camera _camera;
    public Camera Camera
    { get { if (_camera == null)
                _camera = Camera.main;
            return _camera; } 
    }
    
    private GameObject _prefab;  
    public GameObject Prefab
    { 
        get { if (_prefab == null)
                _prefab = Resources.Load<GameObject>("Grenade"); 
            return _prefab; } 
    }
    private float _speed = 20f;
    public float Speed { get => _speed; }

    public void ThrowGranade()
    {
        _trans = GetComponent<Transform>();
        Debug.Log(_trans.position);
        StartCoroutine(_ThrowGranade());
    }

    /// <summary>
    /// Бросок гранаты
    /// </summary>
    public IEnumerator _ThrowGranade()
    {
        grenade = Instantiate(Prefab, _trans.position, Quaternion.identity);

        Vector2 cursor = Input.mousePosition;
        cursor = Camera.ScreenToWorldPoint(cursor);


        Vector2 startPoint = _trans.position; //Стартовая позиция
        Debug.Log(startPoint);
        Vector2 endPoint = new Vector3(cursor.x, _trans.position.y); //Конечная позиция (Не сам курсор, а точка под ним на уровне игрока)
        Debug.Log(endPoint);
        float amplitude = Math.Abs(_trans.position.y - cursor.y); //Амплитуда броска (Высота на которой находиться курсор по отношению к ироку)
        float time = 2f;

        grenade.GetComponent<grenade1>().timeToStop = time * (3f/4f);
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time; // Нормализуем время (Для того, чтобы отмерить как должны были за этот промежуток измениться координаты)
            float angle = Mathf.Lerp(0, Mathf.PI, t); // Линейная интерполяция угла от 0 до π (полукруг)

            // Вычисляем координаты
            float x = Mathf.Lerp(startPoint.x, endPoint.x, t); 
            float y = amplitude * Mathf.Sin(angle) + Mathf.Min(startPoint.y, endPoint.y); ; // По y передвигаемся по синусоиде (Минимальная координа по y для корректировки движения)

            if (grenade != null)
                grenade.transform.position = new Vector3(x, y, 0);
            else StopCoroutine(_ThrowGranade());
            
            elapsedTime += Time.deltaTime;

            yield return null; // Ждем следующего кадра
        }
    }
}
