using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TapAnyButtonText : MonoBehaviour
{
    private TMP_Text tapAnyButton;
    private Color myTextColor;
    // Start is called before the first frame update
    void Start()
    {
        tapAnyButton = GetComponent<TMP_Text>();
    }

    void FixedUpdate()
    {
        myTextColor = tapAnyButton.color;
        myTextColor.a = (myTextColor.a+0.02f) % 1f;
        tapAnyButton.color = myTextColor;
        if (PlayerMovement.hasStarted == true) Destroy(transform.gameObject);
    }


}
