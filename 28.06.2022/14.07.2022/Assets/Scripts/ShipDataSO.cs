using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewShipData", menuName="ScriptableObjects/NewShipDataAsset")]
public class ShipDataSO : ScriptableObject
{
    [SerializeField] private string shipName;

    [SerializeField] private int shipPrice;

    [SerializeField] private float shipHealth;

    [SerializeField] private float shipSpeed;

    [SerializeField] private Sprite shipIcon;

    public Sprite GetShipIcon()
    {
        return shipIcon;
    }

    public string GetShipMenu()
    {
        return shipName;
    }

    public int GetShipPrice()
    {
        return shipPrice;
    }



  
}
