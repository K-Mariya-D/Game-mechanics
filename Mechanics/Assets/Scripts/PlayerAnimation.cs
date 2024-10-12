using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IAnimated
{
    /// <summary>
    /// ������������� ������
    /// </summary>
    private IMoving _objectAnimated;
    public IMoving ObjectAnimated
    {
        get => _objectAnimated;
        private set => _objectAnimated = value;
    }
    /// <summary>
    /// ��������
    /// </summary>
    private Animator _animator;
    public Animator Animator
    {
        get => _animator;
        private set => _animator = value;
    }
    void Start()
    {
        ObjectAnimated = GameObject.FindWithTag("Player").GetComponent<IMoving>();
        Animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        Animate();
    }
    /// <summary>
    /// ������ ���������� ��������
    /// </summary>
    void Animate()
    {
        Animator.SetBool("IsMoving", ObjectAnimated.IsMoving);
    }
}