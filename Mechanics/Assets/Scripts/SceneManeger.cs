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
        Debug.Log("������ ����������");

        Fader.Instance.FadeOut(() => WaitFade = false);
        
        // ���� ����������� ����� ������ �� ������
        while (WaitFade)
            yield return null;


        Debug.Log("����� ����������. ������ ������");

        WaitFade = true;
        camera.GetComponent<ShakeEffect>().ShakeCamera(0.7f, 0.6f, () => WaitFade = false);
        
        while (WaitFade)
            yield return null;


        WaitFade = true;
        Debug.Log("������ ����������");
        
        Fader.Instance.FadeIn(() => WaitFade = false);

        while (WaitFade)
            yield return null;

        Debug.Log("����� ����������. ������������ �����");

        SceneManager.LoadScene("ExampleSceneTwo"); 
    }
}
