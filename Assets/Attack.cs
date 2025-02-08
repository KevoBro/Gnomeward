using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject slashPrefab;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Slash();

        }
    }

    void Slash() {
        GameObject slash = Instantiate(slashPrefab, attackPoint.position + new Vector3(0, .3f, 0), (attackPoint.rotation * Quaternion.Euler(0, 0, 90f))); 
        Rigidbody2D rb = slash.GetComponent<Rigidbody2D>();

    }
}
