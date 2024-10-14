using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManeger : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private bool WaitFade;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WaitFade = true;
        Fader.Instance.FadeOut(() => WaitFade = false);

        // Пока осветляется экран ничего не делаем
        if (WaitFade) 
            yield return null;

        camera.GetComponent<CameraEffects>().ShakeCamera(0.7f, 0.6f);

        Fader.Instance.FadeIn(() => WaitFade = true);

        if (WaitFade)
            SceneManager.LoadScene("SampleScene"); 
    }
}
