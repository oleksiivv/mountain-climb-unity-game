using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    [HideInInspector()]
    public bool alive = true;

    public Rigidbody rb;

    private bool dead = false;

    public BaseUiController uiController;

    public Animator animator;

    public AdmobController admob;

    public static int adsCnt;

    void Start(){
        alive=true;
        dead=false;

        if(rb == null){
            rb = gameObject.GetComponent<Rigidbody>();
        }
    }

    public void deathBehaviour(){
        //test version
        alive=false;
        GroundMove.sspeed = 0;

        animator.SetBool("run", false);
        animator.SetBool("jump", false);
        animator.SetBool("die", true);

        rb.AddForce(Vector3.right*-1.8f, ForceMode.Impulse);
        rb.AddForce(Vector3.up*2.5f, ForceMode.Impulse);

        uiController.deathPanel.SetActive(true);

        if(adsCnt%4 == 3){
            admob.showIntersitionalAd();
        }

        adsCnt++;
    }
}
