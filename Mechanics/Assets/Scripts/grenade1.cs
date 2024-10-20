using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Фиксирует столкновение гранаты с другими обектами (Collodir2D Ridgitbody2D) и вызывает взрыв. Скрипт навешивается на префаб гранаты
/// </summary>
public class grenade1 : MonoBehaviour
{
    /// <summary>
    /// Когда граната должна взорваться
    /// </summary>
    public float timeToStop;
    private float _timer = 0;
    private Camera _camera;
    private GameObject _player;

    private void Start()
    {
        _camera = Camera.main;
        _player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.1f);
        Crash();
    }

    private void Update()
    {
        if (_timer >= timeToStop)
        {
            Destroy(gameObject, 0.1f);
            Crash();
        }
        _timer += Time.deltaTime;
    }
    private void Crash()
    {
        float dist = Vector3.Distance(_player.transform.position, transform.position);

        //Debug.Log(dist);

        //Тряска тем больше, чем ближе к игроку упала граната 
        if (dist <= 5) _camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.6f, null);
        else if (dist <= 10) _camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.3f, null);
        else _camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.08f, null);
    }
}
