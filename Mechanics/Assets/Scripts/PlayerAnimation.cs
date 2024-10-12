using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IAnimated
{
    /// <summary>
    /// Анимированный объект
    /// </summary>
    private IMoving _objectAnimated;
    public IMoving ObjectAnimated
    {
        get => _objectAnimated;
        private set
        {
            if (value == null) throw new ArgumentOutOfRangeException("ObjectAnimated is null");
            _objectAnimated = value;
        }
    }
    /// <summary>
    /// Аниматор
    /// </summary>
    private Animator _animator;
    public Animator Animator
    {
        get => _animator;
        private set
        {
            if (value == null) throw new ArgumentOutOfRangeException("Animator is null");
            _animator = value;
        }
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
    /// Следит за состоянием анимаций
    /// </summary>
    void Animate()
    {
        Animator.SetBool("IsMoving", ObjectAnimated.IsMoving);
    }
}
