using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Proper class name would be Ship part
public abstract class ExampleAbstractClass : MonoBehaviour
{
    public abstract void TakeDamage();

    public abstract GameObject ReturnParentShip();
}

public static class ExtensionMethodExample
{
    public static GameObject GetParent(this GameObject gameObject)
    {
        return gameObject.transform.parent.gameObject;
    }
}
