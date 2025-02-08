using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimpoint : MonoBehaviour
{


    public Transform parentObject; 
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (parentObject != null)
        {
            // Set this object as a child of the parent
            transform.SetParent(parentObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
         if (parentObject != null)
        {
            transform.position = parentObject.position + offset;
        }
    }
}
