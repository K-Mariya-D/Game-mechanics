using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����� ����������� ������ ������ ������. ������ ������������ �� ������ Main camera
/// </summary>
public class ShakeEffect : MonoBehaviour
{
    //������������ � ������� SceneMameger ��� �������� ���������� ������ ������
    private Action _shakeCallback;

    /// <summary>
    /// ������ ������ ������ � ������� ���������� ������� � � ��������� ���������� 
    /// </summary>
    /// <param name="time"></param>
    /// <param name="amplitude"></param>
    public void ShakeCamera(float time, float amplitude, Action shakeCallback)
    {
        if (time <= 0) throw new ArgumentException("time should be > 0 !");
        if (amplitude <= 0) throw new ArgumentException("amplitude should be > 0!");
        if (shakeCallback == null) throw new ArgumentNullException("shakeCallback");

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
