using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeLevel : MonoBehaviour
{
    [SerializeField] private uint horders;
    [SerializeField] private int currentHorde;
    [SerializeField] private List<Horde> hordes = new();
    
    [SerializeField] private uint quantityOfEnemies;

    public void Init()
    {
        InstantiateEnemies();
    }

    void InstantiateEnemies()
    {
        for (int i = 0; i <= hordes[currentHorde].enemies.Count - 1; i++)
        { 
            for(int j = 0; j < hordes[currentHorde].enemies[i].quantity; j++)
            {
                Instantiate(hordes[currentHorde].enemies[i].enemy, hordes[currentHorde].enemies[i].spawnerArea.GetRandomPosition(), Quaternion.identity);
                quantityOfEnemies++;
            }
        }
    }

    private void Update()
    {
        if(quantityOfEnemies <= 0)
        {
            if(horders > 0)
            {
            }
        }
    }

    public void DecreaseQuantityOfEnemies() => quantityOfEnemies--;
}
