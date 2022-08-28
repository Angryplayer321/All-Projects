using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class CellController : MonoBehaviour
{
    [SerializeField] private int ID;
    private void OnTriggerEnter(Collider other)
    {
        EventManager.Instance.Raise(new CellActivatedEvent(ID, transform.gameObject));   
    }
}
