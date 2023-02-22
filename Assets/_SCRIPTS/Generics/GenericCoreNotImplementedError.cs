using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericCoreNotImplementedError<CoreT>
{
    public static CoreT TryGet(CoreT _value, string _name)
    {
        if (_value != null)
        {
            return _value;
        }
        
        Debug.LogError(typeof(CoreT) +" not implemented on " + _name);
        return default;
    }
}
