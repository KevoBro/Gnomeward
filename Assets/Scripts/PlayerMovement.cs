using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb; 
    public Camera cam; 
    public Transform firepoint; 
    Vector2 movement; 
    Vector2 mousePos;

    Vector2 movementDirection;

    public float dashSpeed = 10f;
    public float dashDuration = 1f;
    public float dashCooldown = 1f;

    public Transform rotationPoint; 

    public Vector3 attackOffset;

    public GameObject slashPrefab;

    public Rigidbody2D characterRb;

    bool isDash = false; 

    // Update is called once per frame
    void Update()
    {   

        if(isDash) {
            return; 

        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Dash());

        }
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(movement.x, movement.y).normalized; 
    
         if(Input.GetButtonDown("Fire1")) {
            Slash();

        }
    }


    void FixedUpdate() {
        if(isDash) {
            return; 
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);


    }

    private IEnumerator Dash() {
        isDash = true; 
        rb.velocity = new Vector2(movementDirection.x * dashSpeed, movementDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDash = false; 
    }

     void Slash() {
    Vector3 adjustedOffset = rotationPoint.TransformDirection(attackOffset);

        GameObject slash = Instantiate(slashPrefab, rotationPoint.position + adjustedOffset, (rotationPoint.rotation * Quaternion.Euler(0, 0, 90f))); 
        Rigidbody2D rbSlash = slash.GetComponent<Rigidbody2D>();

       slash.transform.parent = transform;

        /**Rigidbody2D slashRb = slash.GetComponent<Rigidbody2D>();
    slashRb.velocity = new Vector2(0,0);
    if (rb != null && characterRb != null) {
        slashRb.velocity += characterRb.velocity; // Carry character’s velocity over to the slash
    } **/

    }
}
