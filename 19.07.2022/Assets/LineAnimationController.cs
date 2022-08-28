using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimationController : MonoBehaviour
{
    [SerializeField] private Renderer lineRenderer;
    [SerializeField] private float animationDelay;
    private float yOffSetValue;
    private void Start()
    {
        yOffSetValue = lineRenderer.material.GetTextureOffset("_MainTex").y;
        StartCoroutine(AnimateLine());
    }

    IEnumerator AnimateLine()
    {
        for(float i = 0; i >= -1; i -= 0.01f)
        {
            lineRenderer.material.SetTextureOffset("_MainTex", new Vector2(i,yOffSetValue));

            yield return new WaitForSeconds(animationDelay);
        }
        StartCoroutine(AnimateLine());

    }
}
