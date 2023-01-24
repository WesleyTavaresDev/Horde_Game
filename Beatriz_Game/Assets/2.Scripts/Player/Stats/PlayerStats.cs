using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{

    public List<PlayerStatsInfo> stats = new List<PlayerStatsInfo>();

    public float GetStat(PlayerStatsEnum stat)
    {
        foreach (var s in stats)
        {
            if(s.statType == stat)
                return s.value;
        }

        Debug.LogError($"There's no {stat} on stats list");
        return 0;
    }
}

