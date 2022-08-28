using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Equipment"))
        {
            EquipmentDataSO equipmentData = other.GetComponent<EquipmentInteractableController>().GetEquipmentData();
        }
    }
}
