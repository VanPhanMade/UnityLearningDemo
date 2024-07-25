using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDataForUI : MonoBehaviour
{
    void Start()
    {
        AddShipToScrollBar.Instance.AddShipDataToScrollBar(transform.name);
    }
}
