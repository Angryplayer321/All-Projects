using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipnormals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for (int i=0 ; i<normals.Length; i++)
        {
            normals[i] = -1 * normals[i];
        }
        mesh.normals = normals;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
