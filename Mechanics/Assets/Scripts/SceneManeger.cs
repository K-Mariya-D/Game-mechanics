using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManeger : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private bool WaitFade;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Manager());
    }

    private IEnumerator Manager()
    {
        WaitFade = true;
        Debug.Log("Начало Осветления");

        Fader.Instance.FadeOut(() => WaitFade = false);
        
        // Пока осветляется экран ничего не делаем
        while (WaitFade)
            yield return null;


        Debug.Log("Конец осветления. Начало тряски");

        WaitFade = true;
        camera.GetComponent<ShakeEffect>().ShakeCamera(0.7f, 0.6f, () => WaitFade = false);
        
        while (WaitFade)
            yield return null;


        WaitFade = true;
        Debug.Log("Начало Затемнения");
        
        Fader.Instance.FadeIn(() => WaitFade = false);

        while (WaitFade)
            yield return null;

        Debug.Log("Конец Затемнения. Переключение сцены");

        SceneManager.LoadScene("ExampleSceneTwo"); 
    }
}
