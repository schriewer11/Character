using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeonardController : MonoBehaviour
{
    private Animator anim;
    private bool accept_Input = true;

    public AnimationClip jumpAnimClip;
    public AnimationClip rumbaAnimClip;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

        if (jumpAnimClip != null || rumbaAnimClip != null)
        {
            AddInputblockingAnimEndCallBack(jumpAnimClip);
            AddInputblockingAnimEndCallBack(rumbaAnimClip); 
        }

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
    public void AddInputblockingAnimEndCallBack(AnimationClip clip)
    {
        AnimationEvent animDoneEvent = new AnimationEvent();
        animDoneEvent.time = clip.length;
        animDoneEvent.functionName = "OnInputBlockingAnimationDone";
        clip.AddEvent(animDoneEvent);
    }

    private void HandleInput()
    {
        // C is crouch
        anim.SetBool("Crouch", Input.GetKey(KeyCode.C));

        //im.SetBool("Jump", Input.GetKey(KeyCode.Space));

        // R is rumba
        if (Input.GetKey(KeyCode.R))
        {
            anim.SetBool("Crouch", false);
            anim.SetTrigger("Rumba");
            accept_Input = false;
        }

        // Space is jump
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Crouch", false);
            anim.SetBool("Jump", Input.GetKey(KeyCode.Space));
            accept_Input = false;
        }
    }

}
