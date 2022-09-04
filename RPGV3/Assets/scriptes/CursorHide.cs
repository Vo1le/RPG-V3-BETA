using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour
{
   private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
     {
         
    mAnimator.SetTrigger("jumpt");
    
       
    }
    
    if(Input.GetButtonDown("Vertical"))
    {
    mAnimator.SetTrigger("trig");
     
    }
    if(Input.GetButtonUp("Vertical"))
     {
       mAnimator.SetTrigger("stoprun");
    }
    	  if(Input.GetButtonDown("Horizontal"))
    {
    mAnimator.SetTrigger("trig");
    }
    if(Input.GetButtonUp("Horizontal"))
    {
       mAnimator.SetTrigger("stoprun");
    }
     if (Input.GetKeyDown(KeyCode.LeftShift))
    {
            
            mAnimator.SetTrigger("sprintt");
    }
    if(Input.GetKeyUp(KeyCode.LeftShift))
    {
        
       mAnimator.SetTrigger("stoprun");
    }
    }
}
