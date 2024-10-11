using System;

public interface ITimer
{
    /// <summary>
    /// Интервал времени между появлениями/событиями
    /// </summary>
    TimeSpan _interval { get; }
    /// <summary>
    /// Время последнего появления/события
    /// </summary>
    DateTime LastSpawn { get; }
    /// <summary>
    /// Время первого появления/события
    /// </summary>
    DateTime FirstSpawn { get; }
}
