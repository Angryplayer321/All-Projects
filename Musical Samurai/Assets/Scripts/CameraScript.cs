using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float cameraHeight;
    // Start is called before the first frame update

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+cameraHeight, transform.position.z);

    }
}
