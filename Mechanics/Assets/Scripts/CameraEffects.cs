using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraEffects : MonoBehaviour
{
    //Картинка для затемнения/осветления экрана
    [SerializeField] private Image fader;

    /// <summary>
    /// Эффект тряски камеры в течении указанного времени и с указанной амплитудой 
    /// </summary>
    /// <param name="time"></param>
    /// <param name="amplitude"></param>
    public void ShakeCamera(float time, float amplitude)
    {
        StartCoroutine(_ShakeCamera(time, amplitude));
    }
    private IEnumerator _ShakeCamera(float time, float amplitude)
    {
        Transform camera = GetComponent<Transform>();
        Vector3 startPose = camera.position;

        while (time > 0)
        {
            yield return new WaitForSeconds(0.025f);

            float x = Random.Range(-amplitude, amplitude);
            float y = Random.Range(-amplitude, amplitude);

            camera.position = new Vector3(x, y, startPose.z);
            time -= Time.deltaTime;
        }
        camera.position = startPose;
    }

    /// <summary>
    /// Затемнение и осветление экрана c указанной скоростью
    /// </summary>
    /// <param name="speed"></param>
    public void FadeScreen(float speed)
    {
        if (fader.color.a == 1f)
            StartCoroutine(_FadeOutScreen(speed));
        else
            StartCoroutine(_FadeInScreen(speed));
    }
    private IEnumerator _FadeOutScreen(float speed)
    {  
        Color color = fader.color;

        while (color.a > 0f)
        {
            color.a -= 1f * Time.deltaTime;
            fader.color = color;
            yield return null;
        }
    }
    private IEnumerator _FadeInScreen(float speed)
    {
        Color color = fader.color;

        while (color.a < 1f)
        {
            color.a += 1f * Time.deltaTime;
            fader.color = color;
            yield return null;
        }
    }
}
