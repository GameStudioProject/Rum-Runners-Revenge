using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using System.Linq;

namespace Tomas.Core
{
    //Core was made following https://www.youtube.com/watch?v=Pux1GlFwKPs&list=PLy78FINcVmjA0zDBhLuLNL1Jo6xNMMq-W Bardent 2D Platformer Series
    //However refactoring of the core for inheritance, ease of access solution and other, was made by Tomas.

    public class Core : MonoBehaviour
    {
        private List<CoreComponent> _coreComponentsList = new List<CoreComponent>();

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

        public T GetCoreComponent<T>(ref T value) where T : CoreComponent
        {

            value = GetCoreComponent<T>();
            return value;
        }
    }
}
