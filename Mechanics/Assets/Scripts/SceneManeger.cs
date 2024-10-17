using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Заметка: SceneManeger - singlton? 
/// Класс менеджера сцены. Осуществляет переход между сценами, а также визуальные эффекты в самой сцене.
/// Скрипт навешивается на любой Empti обект на сцене
/// </summary>
public class SceneManeger : MonoBehaviour
{
    /// <summary>
    /// Ссылка на Main camera
    /// </summary>
    [SerializeField] private GameObject _camera;
    /// <summary>
    /// Флаг, показываюший закончила ли очередная функция свою работу
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
        Debug.Log("Начало Осветления");

        Fader.Instance.FadeOut(() => _wait = false);
        
        // Пока осветляется экран ничего не делаем
        while (_wait)
            yield return null;


        Debug.Log("Конец осветления. Начало тряски");

        _wait = true;
        _camera.GetComponent<ShakeEffect>().ShakeCamera(0.7f, 0.6f, () => _wait = false);
        
        while (_wait)
            yield return null;


        _wait = true;
        Debug.Log("Начало Затемнения");
        
        Fader.Instance.FadeIn(() => _wait = false);

        while (_wait)
            yield return null;

        Debug.Log("Конец Затемнения. Переключение сцены");

        //После затемнения камеры переход на новую сцену 
        SceneManager.LoadScene("ExampleSceneTwo"); 
    }
}