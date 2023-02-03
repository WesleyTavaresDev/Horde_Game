using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
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

    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(effectAnim.length);
    }

}

