using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private AnimationClip effectAnim;
    Animator anim;
    private void Start() {
        anim = GetComponent<Animator>();
    }   
    public void Run()
    {
        if(anim is null)
            anim = GetComponent<Animator>();
        anim.SetTrigger("Run");
    }
}

