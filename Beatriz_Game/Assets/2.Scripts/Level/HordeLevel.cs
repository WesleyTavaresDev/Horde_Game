using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeLevel : MonoBehaviour
{
    [SerializeField] private int horders;
    [SerializeField] private int currentHorde;
    [SerializeField] private List<Horde> hordes = new();
    
    [SerializeField] private uint quantityOfEnemies;
    [SerializeField] private Effect spawnEffect;
    [SerializeField] private Animator blockerHordeAnim;

    public void Init()
    {
        InstantiateEnemies();
        StartCoroutine(CameraShake.instance.Shake(0.2f, 0.1f));
        blockerHordeAnim.SetTrigger("Start");
        horders = hordes.Count;
    }

    void InstantiateEnemies()
    {
        for (int i = 0; i <= hordes[currentHorde].enemies.Count - 1; i++)
        { 
            for(int j = 0; j < hordes[currentHorde].enemies[i].quantity; j++)
            {
                Vector2 randomPos = hordes[currentHorde].enemies[i].spawnerArea.GetRandomPosition();
                var effect = Instantiate(spawnEffect.gameObject, new Vector2(randomPos.x, randomPos.y + 0.5f), Quaternion.identity) as GameObject ;
                effect.GetComponent<Effect>().Run();
                
                Instantiate(hordes[currentHorde].enemies[i].enemy, randomPos, Quaternion.identity);
                quantityOfEnemies ++;
            }
        }
    }

    private void CheckIfIsHorderCompleted()
    {
        if (quantityOfEnemies <= 0)
        {
            if (currentHorde >= horders)
            {
                if(blockerHordeAnim != null) 
                {
                    blockerHordeAnim.SetBool("End", true);
                    Destroy(blockerHordeAnim.gameObject, 0.7f);
                }
            }

            else
            {
                currentHorde++;
                Init();
            }
        }
    }

    public void DecreaseQuantityOfEnemies() 
    {
        quantityOfEnemies--;
    } 
        

    private void Update() 
    {
        CheckIfIsHorderCompleted();    
    }
}
