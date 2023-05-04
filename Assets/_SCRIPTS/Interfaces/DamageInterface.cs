using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DamageInterface 
{
    //Interface is somewhere to define a method's or function signature that a class is going to have, if a class implements an interface we are saying that this class definitely has these functions  

    void Damage(float _damageAmount);
}
