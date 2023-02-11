using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawnable : MonoBehaviour
{
    [SerializeField] private HordeLevel hordeLevel;

    protected virtual void Start() {
        hordeLevel = GameObject.FindGameObjectWithTag("LevelController").GetComponent<HordeLevel>();
    }

    public virtual void OnKill()
    {
        hordeLevel.DecreaseQuantityOfEnemies();
    }


}
