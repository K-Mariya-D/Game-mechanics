using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/// <summary>
/// ����� ��� ������ �������. ������ ������������ �� ������
/// </summary>
public class Grenade : MonoBehaviour, IGrenade
{   
    //�������
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

    /// <summary>
    /// ������ �������
    /// </summary>
    public void ThrowGranade()
    {
        grenade = Instantiate(Prefab, this.transform.position, Quaternion.identity);

        Vector3 distance = Input.mousePosition;
        distance = Camera.ScreenToWorldPoint(distance);
        //������������ ������� ��������. ��������� ������ �������, ���� �������� �������� ����������� ����� 
        distance = (distance - grenade.transform.position).normalized;

        grenade.GetComponent<Rigidbody2D>().AddForce(distance * Speed, ForceMode2D.Impulse);
        
        StartCoroutine(CrashEffect());
    }
    /// <summary>
    /// ��������� ������ ����� ������������ ������� � ���-����
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

        Debug.Log("������ ������!");

        float dist = Vector3.Distance(this.transform.position, grenade.transform.position);

        Debug.Log(dist);

        //������ ��� ������, ��� ����� � ������ ����� ������� 
        if (dist <= 5) Camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.6f, null);
        else if (dist <= 10) Camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.3f, null);
        else Camera.GetComponent<ShakeEffect>().ShakeCamera(0.5f, 0.08f, null);
  
    }
 
}
