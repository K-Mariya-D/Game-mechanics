using System;
using UnityEngine;

/// <summary>
/// ������������ ���������� ������ �� �������. ������ ������������ �� Main camera
/// </summary>
public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// ������ �� transform ������
    /// </summary>
    [SerializeField] private Transform _player;
    /// <summary>
    /// Transform ������
    /// </summary>
    private Transform _trans;
    public float speed;
    /// <summary>
    /// ������� �� ������� ������ �������� ������������ ������
    /// </summary>
    public Vector3 offset;

    private void Start()
    {
        if (speed < 0) throw new ArgumentException("speed should be >= 0!");

        _trans = GetComponent<Transform>();
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 distance = _player.position + offset;
        Vector3 newPos = Vector3.Lerp(_trans.position, distance, speed * Time.deltaTime);
        _trans.position = newPos;
    }
}
