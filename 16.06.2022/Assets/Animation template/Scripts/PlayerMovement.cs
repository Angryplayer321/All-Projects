using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimation;

    private void Start()
    {
        playerAnimation = GetComponentInChildren<Animator>();

    }
    private void Update()
    {
         float verticalInput = Input.GetAxis("Vertical");
         float horizontalInput = Input.GetAxis("Horizontal");
        playerAnimation.SetFloat("vertic", verticalInput);
        playerAnimation.SetFloat("horiz", horizontalInput);


    }
}
