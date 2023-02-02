using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeLevel : MonoBehaviour
{
    [SerializeField] private List<SpawnableAttributes> enemies = new();
    public void Init()
    {
        Debug.Log("Horde started");

        InstantiateEnemies();
    }

    void InstantiateEnemies()
    {
        for (int i = 0; i <= enemies.Count - 1; i++)
        { 
            for(int j = 0; j < enemies[i].quantity; j++)
            {
                Instantiate(enemies[i].enemy, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
