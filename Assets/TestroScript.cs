using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Исполнение:
/// 1 - Вызывается конструктор и генерирует GUID, resettableValue = false по дефолтной инициализации
/// 2 - Вызывается OnEnable с тем же самым GUID (значит почти 100% тот же самый объект). resettableValue все еще false
/// 3 - resettableValue ставится на true после всех махинаций
/// 
/// Но после рекомпиляции происходит следующее
/// 1 - Триггерим рекомпиляцию (закомментим resettableValue = true;)
/// 2 - Вызывается конструктор, resettableValue все так же false.
/// 3 - Вызывается OnEnable. resettableValue магическим образом становится true.
/// 
/// GUID между конструктором и OnEnalbe одни и те же.
/// </summary>

[ExecuteAlways]
public class TestroScript : MonoBehaviour
{
    private Guid guid;
    private bool resettableValue { get; set; } = false;

    public TestroScript()
    {
        guid = Guid.NewGuid();
        Debug.Log($"Called from constructor, {resettableValue}, {guid}");
    }

    public void OnEnable()
    {
        Debug.Log($"Called from OnEnable, {resettableValue}, {guid}");
        resettableValue = true;
    }
}
