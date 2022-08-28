using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform arrowSlot;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float bulletSpeed = 20;
     private GameObject currentSpawnedArrowInstance;
    private bool isDrawable;
    private bool isDrawable2;

    private void Update()
    {
        if (!isDrawable2)
        
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimator.SetLayerWeight(1, 1);

                playerAnimator.Play("Draw", 1, 0);

            }
            if (Input.GetMouseButtonUp(0))
            {
                playerAnimator.Play("Release", 1, 0);
            }
        


    }
    public void SpawnArrow()
    {
        isDrawable = true;
        isDrawable2 = true;

        currentSpawnedArrowInstance = Instantiate(arrowPrefab, arrowSlot);
    }

    public void ReleaseArrow()
    {
        if (!isDrawable)
        {
            ResetLayers();
            return;
        }

        currentSpawnedArrowInstance.transform.parent = null;
        currentSpawnedArrowInstance.GetComponent<Rigidbody>().AddForce(-currentSpawnedArrowInstance.transform.forward * bulletSpeed, ForceMode.Impulse);
        currentSpawnedArrowInstance.GetComponent<Rigidbody>().useGravity = true;
        isDrawable = false;
    }
    public void ResetLayers()
    {
        isDrawable2 = false;
        playerAnimator.SetLayerWeight(1, 0);
    }



}
