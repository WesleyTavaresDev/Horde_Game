using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStat"
)]
public class EnemyStats : ScriptableObject
{
   public List<EnemyStatsInfo> stats = new();

   public float GetStat(EnemyStatsEnum statType)
   {
        foreach(var stat in  stats)
        {
            if(stat.statsType == statType)
                return stat.value;
        }

        Debug.LogError($"There's no {statType}");
        return 0;
   }
}
