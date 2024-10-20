using System;
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
        
        //Координаты, в которых граната должна взорваться
        float x = Mathf.Lerp(startPoint.x, endPoint.x, (float)1.5/2);
        float angle = Mathf.Lerp(0, Mathf.PI, (float)1.5/2);
        float y = amplitude * Mathf.Sin(angle);
        
        grenade.GetComponent<grenade1>().EndPos = new Vector3(x, y, 0);
        
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time; // Нормализуем время (Для того, чтобы отмерить как должны были за этот промежуток измениться координаты)
            angle = Mathf.Lerp(0, Mathf.PI, t); // Линейная интерполяция угла от 0 до π (полукруг)

            // Вычисляем координаты
            x = Mathf.Lerp(startPoint.x, endPoint.x, t); 
            y = amplitude * Mathf.Sin(angle) + Mathf.Min(startPoint.y, endPoint.y); ; // По y передвигаемся по синусоиде (Минимальная координа по y для корректировки движения)

            grenade.transform.position = new Vector3(x, y, 0);

            elapsedTime += Time.deltaTime;
            yield return null; // Ждем следующего кадра
        }
        StartCoroutine(CrashEffect());
    }
    /// <summary>
    /// Запускает тряску после столкновении гранаты с чем-либо
    /// </summary>
    /// <returns></returns>
    private IEnumerator CrashEffect()
    {
        bool chash = grenade.GetComponent<grenade1>().Collision;

        while (!chash)
        {
            chash = grenade.GetComponent<grenade1>().Collision;
            yield return null;
        }

        Debug.Log("Запуск тряски!");

        float dist = Vector3.Distance(transform.position, grenade.transform.position);

        Debug.Log(dist);

        //Тряска тем больше, чем ближе к игроку упала граната 
        if (dist <= 5) Camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.6f, null);
        else if (dist <= 10) Camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.3f, null);
        else Camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.08f, null);
  
    }
}
