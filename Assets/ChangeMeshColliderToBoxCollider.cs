using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ChangeMeshColliderToBoxCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        foreach (MeshRenderer mesh in GetComponentsInChildren<MeshRenderer>())
        {
            BoxCollider boxCollider;

            if (mesh.gameObject.GetComponent<BoxCollider>() != null)
                boxCollider = mesh.gameObject.GetComponent<BoxCollider>();
            else
                boxCollider = mesh.gameObject.AddComponent<BoxCollider>();

            boxCollider.size = mesh.transform.InverseTransformVector(mesh.bounds.extents * 2);
        }

        MeshCollider[] colliders = GetComponentsInChildren<MeshCollider>();

        for(int i = 0; i < colliders.Length; i++)
        {
            DestroyImmediate(colliders[i]);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
