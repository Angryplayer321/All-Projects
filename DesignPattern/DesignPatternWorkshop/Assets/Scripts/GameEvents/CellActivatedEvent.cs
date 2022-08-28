using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
public class CellActivatedEvent : GameEvent
{
    public int ID;

    public GameObject cellObject;

    public CellActivatedEvent(int _ID, GameObject _cellObject)
    {
        ID = _ID;
        cellObject = _cellObject;
    }
}
