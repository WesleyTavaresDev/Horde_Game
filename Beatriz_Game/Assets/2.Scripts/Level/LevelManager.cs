using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public enum LevelType {Normal, Horde}
    public LevelType levelType;
    
    void Start()
    {
        switch(levelType)
        {
            case LevelType.Horde:
            break;
        }
    }

    void Update()
    {
        
    }
}
