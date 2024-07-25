using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=1-_-716Ouy8
// https://www.youtube.com/watch?v=mpM0C6quQjs

public class AddShipToScrollBar : MonoBehaviour
{
    [SerializeField] private GameObject ButtonPrefab;

    private static AddShipToScrollBar _Instance;
    public static AddShipToScrollBar Instance
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = FindObjectOfType<AddShipToScrollBar>();
                if (_Instance == null)
                {
                    _Instance = new GameObject().AddComponent<AddShipToScrollBar>();
                }
            }
            return _Instance;
        }
    }
    private void Awake()
    {
        if (_Instance != null) Destroy(this);
        else { _Instance = this; }
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Creates a button on the scrolling content panel
    /// </summary>
    public void AddShipDataToScrollBar(string ShipName)
    {
        GameObject NewShipData = Instantiate(ButtonPrefab);
        NewShipData.transform.parent = this.transform;
        NewShipData.GetComponent<SetTextOnButton>().SetShipDataName(ShipName);
    }
}
