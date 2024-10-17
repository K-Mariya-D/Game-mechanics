using System;
using UnityEngine;

/// <summary>
/// ����� Fader �������� �� ���������� � ���������� ������. ������ ������������ �� ������ � ��������� ��� ����������
/// </summary>
public class Fader : MonoBehaviour
{

    private static Fader _instance;
    [SerializeField] private Animator _animator;

    //��� ������������ ���������� ������� � SceneManeger
    private Action _fadeInCallback;
    private Action _fadeOutCallback;
    public static Fader Instance
    {
        get { 
            if (_instance == null)
            {
                var prefab = Resources.Load<Fader>("Fader");
                _instance = Instantiate(prefab);
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <param name="fadeInCallback"></param>
    public void FadeIn(Action fadeInCallback)
    {
        _fadeInCallback = fadeInCallback;
        _animator.SetBool(name: "isFaded", false);
    }
    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <param name="fadeOutCallback"></param>
    public void FadeOut(Action fadeOutCallback)
    {
        _fadeOutCallback = fadeOutCallback;
        _animator.SetBool(name: "isFaded", true);
    }
    /// <summary>
    /// �������� ��������� ������� ����� ���������� ������
    /// </summary>
    private void FadeInCallbackHandler()
    {
        _fadeInCallback?.Invoke();
        _fadeInCallback = null;
    }
    /// <summary>
    /// �������� ��������� ������� ����� ���������� ������
    /// </summary>
    private void FadeOutCallbackHandler()
    {
        _fadeOutCallback?.Invoke();
        _fadeOutCallback = null;
    }
}
