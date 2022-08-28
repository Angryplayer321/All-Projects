using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  [CreateAssetMenu(fileName = "NewEquipmentData", menuName = "ScriptableObjects/EquipmentData")]
public class EquipmentDataSO : ScriptableObject
{
    public EquipmentType equipmentType;

    public GameObject equipmentSMR;

    public Sprite equipmentIcon;

    public string equipmentName;

    public float equipmentHealth;

    public float EquipmentDamageProtection;
}

public enum EquipmentType { NONE,HEAD,BODY,LEGS,FEET}