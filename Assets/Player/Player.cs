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

    Animator animator;

   // private WeaponParent weaponParent; 

    [SerializeField] 
    private InputActionReference movement, attack, pointerPosition; 
    // Start is called before the first frame update

    void Start() {
        animator = GetComponent<Animator>();

    }
    
    private void Awake() {

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if(isDash) {
            return; 
        }
     

        movementInput.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movementInput * _moveSpeed; 
        if (rb.velocity.x == rb.velocity.y && rb.velocity.x <0) {
            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkLeft", true);
        } else if (rb.velocity.x == rb.velocity.y && rb.velocity.x > 0) {
            animator.SetBool("walkDown", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkRight", true);
        } else if (rb.velocity.x > 0 && (rb.velocity.x > rb.velocity.y)) {
            animator.SetBool("walkUp", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", true);
        } else if (rb.velocity.y < 0 && (rb.velocity.x == Math.Abs(rb.velocity.y))) {
            animator.SetBool("walkDown", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkRight", true);
        }else if (rb.velocity.y < 0 && (rb.velocity.x == rb.velocity.y)) {
            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkLeft", true);
        }else if (rb.velocity.y > 0 && (-rb.velocity.x == rb.velocity.y)) {
            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkLeft", true);
        }else if (rb.velocity.x < 0 && (Math.Abs(rb.velocity.x) > rb.velocity.y)) {
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkLeft", true);
         }  else if (rb.velocity.y > 0 && (Math.Abs(rb.velocity.x) < rb.velocity.y)) {
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkDown", false);
            animator.SetBool("walkUp", true);
        }    else if (rb.velocity.y < 0 && (Math.Abs(rb.velocity.x) < Math.Abs(rb.velocity.y))) {
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", true);
         } else {
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", false);

         }

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

    public void Attack (InputAction.CallbackContext context) {
        animator.SetTrigger("swordAttack"); 

    }

   // private Vector2 GetPointerInput() {
        //Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
       // mousePos.z = Camera.mainClipPlane; 
        //return Camera.main.ScreenToWorldPoint(mousePos);
   // }
}
