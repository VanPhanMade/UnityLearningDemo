using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTextOnButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ShipText;

    public void SetShipDataName(string newName)
    {
        ShipText.text = newName;
    }
}
