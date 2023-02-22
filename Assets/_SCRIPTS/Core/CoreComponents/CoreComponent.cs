using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour, LogicUpdateInterface
{
    protected Core core;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if (core == null)
        {
            Debug.LogError("Core is missing on parent game object");
        }
        core.AddCoreComponent(this);
    }

    public virtual void LogicUpdate()
    {
        
    }
}
