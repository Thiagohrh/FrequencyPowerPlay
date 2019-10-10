using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangaPanel : MonoBehaviour {

    public int step = 0;
    public int stepsMax;
    public Animator anim;

    void Awake()
    {
        if (anim == null) 
        anim = GetComponent<Animator>();
    }

    public bool Click(float speed =-1)
    {
        Debug.Log("Step");
        step++;
        anim.SetInteger("Step",step);
        anim.SetTrigger("StepT");
        if(speed >0)
        anim.SetFloat("AnimationSpeed",speed/2);
        bool b = step >= stepsMax;

        //if(b)
        //{
        //    step = 0; // Was testing cycling through the same panel
        //}
        return b;
    }
}
