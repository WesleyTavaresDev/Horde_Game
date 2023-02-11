using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private string runAnimation;
    [SerializeField] private string stopAnimation;
    Animator anim;

    private void OnEnable() => anim = GetComponent<Animator>();

    public void Run() => anim.SetTrigger(runAnimation);
    

    public void Stop() => anim.SetTrigger(stopAnimation);
    
}

