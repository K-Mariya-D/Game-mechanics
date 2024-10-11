using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public float _time;
    private Transform camera;
    private Vector3 startPose;

    // Start is called before the first frame update
    private void Start()
    {
        ShakeCamera();
    }

    void ShakeCamera()
    {
        StartCoroutine(_ShakeCamera());
    }
    //Ёффект тр€ски камеры
    IEnumerator _ShakeCamera()
    {
        camera = GetComponent<Transform>();
        startPose = camera.position;

        while (_time > 0)
        {
            yield return new WaitForSeconds(0.025f);

            float x = Random.Range(-0.3f, 0.3f);
            float y = Random.Range(-0.3f, 0.3f);

            camera.position = new Vector3(x, y, startPose.z);
            _time -= Time.deltaTime;
        }
        camera.position = startPose;
    }
}
