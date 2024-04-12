using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This could be the hull, broadside, etc.
public class TypeOfShipPart : ExampleAbstractClass
{
    public override GameObject ReturnParentShip()
    {
        return gameObject.GetParent();
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
