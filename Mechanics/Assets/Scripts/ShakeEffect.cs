using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  ласс реализующий эффект тр€ски экрана. —крипт навешиваетс€ на объект Main camera
/// </summary>
public class ShakeEffect : MonoBehaviour
{
    //»спользуетс€ в скрипте SceneMameger дл€ ожидани€ завершени€ работы метода
    private Action _shakeCallback;

    /// <summary>
    /// Ёффект тр€ски камеры в течении указанного времени и с указанной амплитудой 
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
