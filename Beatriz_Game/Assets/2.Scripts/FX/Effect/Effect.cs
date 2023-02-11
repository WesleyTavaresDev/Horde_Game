using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private string runAnimation;
    [SerializeField] private string stopAnimation;
    [SerializeField] private AnimationClip effectAnim;
    Animator anim;

    private void OnEnable() => anim = GetComponent<Animator>();

    public void Run()
    {
        anim.SetTrigger(Animator.StringToHash(runAnimation));
    }

    public void Stop() 
    {
        anim.SetTrigger(Animator.StringToHash(stopAnimation));
    }
}

