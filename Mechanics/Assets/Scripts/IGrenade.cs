using System;
using System.Collections.Generic;
using UnityEngine;

public interface IGrenade
{
    /// <summary>
    /// Доступ к камере для отслеживания положения курсора мыши
    /// </summary>
    public Camera Camera { get; }
    /// <summary>
    /// Префаб гранаты
    /// </summary>
    public GameObject Prefab { get; }
    /// <summary>
    /// Метод бросание гранаты
    /// </summary>
    public void ThrowGranade();
}
