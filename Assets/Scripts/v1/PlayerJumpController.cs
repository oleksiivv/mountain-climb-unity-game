using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;

    public float jumpForce = 2;

    private bool canJump = false;

    public Vector3 initPos;

    public Animator animator;

    public PlayerDeathController playerDeathController;

    void Start(){
        if(rigidbody==null){
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }
    }

    void Update(){
        if(Input.GetMouseButtonDown(0) && canJump){
            rigidbody.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
        else if(Input.GetMouseButtonDown(0) && !canJump){
            rigidbody.AddForce(Vector3.up*-jumpForce/2, ForceMode.Impulse);
        }
        else if(canJump){
            animator.SetBool("run", true);
        }

        if(playerDeathController.alive)transform.position = Vector3.MoveTowards(transform.position, new Vector3(initPos.x, transform.position.y, initPos.z), 0.25f);
    }

    void OnCollisionEnter(Collision other){
        canJump = true;
        //animator.SetBool("jump", false);
    }

    void OnCollisionStay(Collision other){
        if(IsInvoking(nameof(fixJumpDelay))){
            CancelInvoke(nameof(fixJumpDelay));
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.tag.Equals("Ground")){
            if(!IsInvoking(nameof(fixJumpDelay)))Invoke(nameof(fixJumpDelay), 0.05f);

            Invoke(nameof(jumpAnimationReset), 0.5f);
        }
    }

    void fixJumpDelay(){
        canJump = false;
        animator.SetBool("run", false);
        animator.SetBool("jump", true);
    }

    void jumpAnimationReset(){
        animator.SetBool("run", true);
        animator.SetBool("jump", false);
    }
}
