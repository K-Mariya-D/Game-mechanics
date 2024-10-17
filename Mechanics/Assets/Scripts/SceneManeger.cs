using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// �������: SceneManeger - singlton? 
/// ����� ��������� �����. ������������ ������� ����� �������, � ����� ���������� ������� � ����� �����.
/// ������ ������������ �� ����� Empti ����� �� �����
/// </summary>
public class SceneManeger : MonoBehaviour
{
    /// <summary>
    /// ������ �� Main camera
    /// </summary>
    [SerializeField] private GameObject _camera;
    /// <summary>
    /// ����, ������������ ��������� �� ��������� ������� ���� ������
    /// </summary>
    private bool _wait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Manager());
    }

    private IEnumerator Manager()
    {
        _wait = true;
        Debug.Log("������ ����������");

        Fader.Instance.FadeOut(() => _wait = false);
        
        // ���� ����������� ����� ������ �� ������
        while (_wait)
            yield return null;


        Debug.Log("����� ����������. ������ ������");

        _wait = true;
        _camera.GetComponent<ShakeEffect>().ShakeCamera(0.7f, 0.6f, () => _wait = false);
        
        while (_wait)
            yield return null;


        _wait = true;
        Debug.Log("������ ����������");
        
        Fader.Instance.FadeIn(() => _wait = false);

        while (_wait)
            yield return null;

        Debug.Log("����� ����������. ������������ �����");

        //����� ���������� ������ ������� �� ����� ����� 
        SceneManager.LoadScene("ExampleSceneTwo"); 
    }
}