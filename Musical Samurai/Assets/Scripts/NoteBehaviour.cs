using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    
    [SerializeField] private PlayerMovement playerMovement;
    private RectTransform myObject;
    private float startingPoint;
    private Vector3 position;
    private void Start()
    {
        myObject = GetComponent<RectTransform>();
    }


    private void LateUpdate()
    {

        position = playerMovement.GetMovementDistant();
        
        
        myObject.position += -position;
    }
}
