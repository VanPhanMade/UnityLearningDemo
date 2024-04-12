using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHull : ExampleAbstractClass
{
    public override GameObject ReturnParentShip()
    {
        Debug.Log("Hull found under radar!");
        return transform.parent.gameObject;
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
