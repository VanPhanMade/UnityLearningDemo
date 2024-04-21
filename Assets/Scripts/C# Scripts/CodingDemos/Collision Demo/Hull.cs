using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : ExampleAbstractClass
{
    public override GameObject ReturnParentShip()
    {
        return this.gameObject.GetParent();
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
