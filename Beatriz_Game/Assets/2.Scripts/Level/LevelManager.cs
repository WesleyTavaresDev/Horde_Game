using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public enum LevelType {Normal, Horde}
    public LevelType levelType;

    public HordeLevel hordeLevel;
    
    void Start()
    {
        switch(levelType)
        {
            case LevelType.Horde:
                hordeLevel.Init();
            break;
        }
    }

    void Update()
    {
        
    }
}
