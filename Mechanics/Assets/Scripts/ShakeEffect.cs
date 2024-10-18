using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShakeEffect : MonoBehaviour
{
    private Action _shakeCallback;

    /// <summary>
    /// Эффект тряски камеры в течении указанного времени и с указанной амплитудой 
    /// </summary>
    /// <param name="time"></param>
    /// <param name="amplitude"></param>
    public void ShakeCamera(float time, float amplitude, Action shakeCallback)
    {
        StartCoroutine(_ShakeCamera(time, amplitude, shakeCallback));
    }
    private IEnumerator _ShakeCamera(float time, float amplitude, Action shakeCallback)
    {
        _shakeCallback = shakeCallback;

        Transform camera = GetComponent<Transform>();
        Vector3 startPose = camera.position;

        while (time > 0)
        {
            yield return new WaitForSeconds(0.025f);

            float x = UnityEngine.Random.Range(-amplitude, amplitude);
            float y = UnityEngine.Random.Range(-amplitude, amplitude);

            camera.position = new Vector3(x, y, startPose.z);
            time -= Time.deltaTime;
        }
        camera.position = startPose;
        shakeCallback.Invoke();
    }

}
