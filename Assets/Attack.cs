using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform rotationPoint; 
    public GameObject slashPrefab;
    public Vector3 attackOffset;
    public Rigidbody2D characterRb;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Slash();

        }
    }

    void Slash() {
    Vector3 adjustedOffset = rotationPoint.TransformDirection(attackOffset);

        GameObject slash = Instantiate(slashPrefab, rotationPoint.position + adjustedOffset, (rotationPoint.rotation * Quaternion.Euler(0, 0, 90f))); 
        Rigidbody2D rbSlash = slash.GetComponent<Rigidbody2D>();

       // slash.transform.parent = transform;

        Rigidbody2D rb = slash.GetComponent<Rigidbody2D>();
        
    if (rb != null && characterRb != null) {
        rb.velocity += characterRb.velocity; // Carry character’s velocity over to the slash
    }

    }
}
