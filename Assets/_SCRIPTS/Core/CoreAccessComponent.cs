using UnityEngine;

public class CoreAccessComponent<T> where T : CoreComponent
{
    private Core _core;
    private T _component;

    public T Component => _component ? _component : _core.GetCoreComponent(ref _component);

    public CoreAccessComponent(Core core)
    {
        if (core == null)
        {
            Debug.LogWarning($"Core is Null for component {typeof(T)}");
        }
        
        this._core = core;
    }
}
