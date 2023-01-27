using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnEnable() => PlayerLifeController.onDie += ShowGameOver;
    private void OnDisable() => PlayerLifeController.onDie -= ShowGameOver;

    private void ShowGameOver()
    {

    }
}
