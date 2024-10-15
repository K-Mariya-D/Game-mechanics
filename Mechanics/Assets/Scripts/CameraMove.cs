using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Transform _trans;
    public float speed;
    public Vector3 offset;

    private void Start()
    {
        _trans = GetComponent<Transform>();
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 Distance = _player.position + offset;
        Vector3 NewPos = Vector3.Lerp(_trans.position, Distance, speed * Time.deltaTime);
        _trans.position = NewPos;
    }
}
