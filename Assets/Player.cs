using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  



public class Player : MonoBehaviour
{
    //[SerializedField] 
    private float _moveSpeed = 5f;

    private Vector2 pointerInput, movementInput; 

    public Rigidbody2D rb; 

    bool isDash = false;
    bool canDash = true; 

     public float dashSpeed = 10f;
    public float dashDuration = .1f;
    public float dashCooldown = 1f;
   // private WeaponParent weaponParent; 

    [SerializeField] 
    private InputActionReference movement, attack, pointerPosition; 
    // Start is called before the first frame update

    // Update is called once per frame
    
    private void Awake() {

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       
        
    }

    void FixedUpdate() {
        if(isDash) {
            return; 
        }
     

        movementInput.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movementInput * _moveSpeed; 


    }


    public void DoDash (InputAction.CallbackContext context) {
        if (canDash) {
               StartCoroutine(Dash());
        }
    }

    public IEnumerator Dash () {
        canDash = false;
        isDash = true; 
        rb.velocity = movementInput * dashSpeed; 
        yield return new WaitForSeconds(dashDuration);
        isDash = false; 
    
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

   // private Vector2 GetPointerInput() {
        //Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
       // mousePos.z = Camera.mainClipPlane; 
        //return Camera.main.ScreenToWorldPoint(mousePos);
   // }
}
