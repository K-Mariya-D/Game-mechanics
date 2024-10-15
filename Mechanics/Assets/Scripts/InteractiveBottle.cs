using System;
using UnityEngine;

public class InteractiveBottle : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Описание интерактивного объекта
    /// </summary>
    [SerializeField] private string _description;
    public string Description
    {
        get => _description;
        private set
        {
            if (value == null) throw new ArgumentNullException("InteractiveBottle: Description is null");
            if (value.Length == 0) throw new ArgumentOutOfRangeException("InteractiveBottle: Lenght of Description is 0");
        }
    }
    /// <summary>
    /// Дистанция, с которой можно взаимодействовать с объектом
    /// </summary>
    [SerializeField] private float _distance;
    public float Distance
    {
        get => _distance;
        private set
        {
            if (value < 0f) throw new ArgumentOutOfRangeException("InteractiveBottle: Distance < 0");
            _distance = value;
        }
    }
    /// <summary>
    /// Взаимодействие с объектом
    /// </summary>
    public void Interactive()
    {
        if (Input.GetKey(KeyCode.E)) this.gameObject.SetActive(false);
    }
}
