using System;
using System.Collections.Generic;
using System.Linq;
using Tomas.Weapons.Components;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.TerrainTools;
using UnityEngine;

namespace Tomas.Weapons
{
    [CustomEditor(typeof(PlayerWeaponDataSO))]
    public class PlayerWeaponDataSOEditor : Editor
    {
        private static List<Type> _dataComponentTypes = new List<Type>();

        private PlayerWeaponDataSO _weaponDataSO;

        private void OnEnable()
        {
            _weaponDataSO = target as PlayerWeaponDataSO;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var dataComponentType in _dataComponentTypes)
            {
                if (GUILayout.Button(dataComponentType.Name))
                {
                    var component = Activator.CreateInstance(dataComponentType) as PlayerWeaponComponentData; //use type information stored in type class

                    if (component == null)
                    {
                        return;
                    }
                    
                    _weaponDataSO.AddData(component);
                }
            }
        }

        [DidReloadScripts]
        private static void OnEditorRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies(); // gets list of all assemblies that are loaded into current application domain, assembly is a pile of code that is run during runtime
            var types = assemblies.SelectMany(assembly => assembly.GetTypes()); //looks at assembly and calls get types on it and gets the information and puts it in a new list
            var filteredTypes = types.Where(
                type => type.IsSubclassOf(
                    typeof(PlayerWeaponComponentData)) && !type.ContainsGenericParameters && type.IsClass //any type that is a subclass is part of component data will be filtered to this list and also that it is not containing generics and to make sure that it is a class
            );
            _dataComponentTypes = filteredTypes.ToList();
        }
    }
}