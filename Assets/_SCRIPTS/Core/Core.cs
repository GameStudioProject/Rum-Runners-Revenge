using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using System.Linq;

public class Core : MonoBehaviour
{
    private List<CoreComponent> _coreComponentsList = new List<CoreComponent>();
    

    private void Awake()
    {
        
    }

    public void EveryFrameUpdate()
    {
        foreach (CoreComponent _componentList in _coreComponentsList)
        {
            _componentList.LogicUpdate();
        }
    }

    public void AddCoreComponent(CoreComponent coreComponent)
    {
        if (!_coreComponentsList.Contains(coreComponent))
        {
            _coreComponentsList.Add(coreComponent);
        }
    }

    public CoreT GetCoreComponent<CoreT>() where CoreT : CoreComponent
    {
        var component = _coreComponentsList.OfType<CoreT>().FirstOrDefault();

        if (component)
        {
            return component;
        }

        component = GetComponentInChildren<CoreT>();

        if (component)
        {
            return component;
        }
        
        Debug.LogWarning($"{typeof(CoreT)} not found on {transform.parent.name}");
        return component;
    }
}
