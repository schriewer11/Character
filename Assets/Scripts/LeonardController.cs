using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeonardController : MonoBehaviour
{
    private Animator anim;
    private bool accept_Input = true;

    public AnimationClip fireballAnimClip;
    public AnimationClip hurricaineKickAnimClip;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

        HandleAnimationBlocking();

    }

    // Update is called once per frame
    void Update()
    {
        if (accept_Input) 
        { 
            HandleInput(); 
        }
        
    }

    public void OnInputBlockingAnimationDone()
    {
        accept_Input = true;
    }

    // 
    public void HandleAnimationBlocking()
    {
        if (fireballAnimClip != null)
        {
            AnimationEvent fireballDoneEvent = new AnimationEvent();
            fireballDoneEvent.time = fireballAnimClip.length;
            fireballDoneEvent.functionName = "OnInputBlockingAnimationDone";
            fireballAnimClip.AddEvent(fireballDoneEvent);
        }
        if (hurricaineKickAnimClip != null)
        {
            AnimationEvent hurricKickDoneEvent = new AnimationEvent();
            hurricKickDoneEvent.time = hurricaineKickAnimClip.length;
            hurricKickDoneEvent.functionName = "OnInputBlockingAnimationDone";
            fireballAnimClip.AddEvent(hurricKickDoneEvent);
        }
    }

    private void HandleInput()
    {
        anim.SetBool("Crouch", Input.GetKey(KeyCode.C));
        if (Input.GetKey(KeyCode.G))
        {
            anim.SetTrigger("HurricaneKick");
            accept_Input = false;
        }
        if (Input.GetKey(KeyCode.F))
        {
            anim.SetTrigger("Fireball");
            accept_Input = false;
        }
    }

}
