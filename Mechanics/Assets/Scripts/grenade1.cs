using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������� ������������ ������� � ������� �������� (Collodir2D Ridgitbody2D). ������ ������������ �� ������ �������
/// </summary>
public class grenade1 : MonoBehaviour
{
    /// <summary>
    /// ����������� �� ������� � ���-���� 
    /// </summary>
    public bool Collision { get; private set; }

    private void Start()
    {
        Collision = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("������� ��������!");
        Collision = true;
        //������� ����� � ��������. (��� �������� ������ Grenade �� �������� �������� ���� � ������������)
        Destroy(gameObject, 0.1f);
    }
}
