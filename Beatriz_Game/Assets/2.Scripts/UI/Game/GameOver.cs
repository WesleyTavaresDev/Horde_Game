using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float timeToAppear;

    private Canvas gameOverRenderer;
    private GraphicRaycaster gameOverRaycast;

    private void OnEnable() => PlayerLifeController.onDie += ShowGameOver;
    private void OnDisable() => PlayerLifeController.onDie -= ShowGameOver;

    private void Awake() 
    {
        gameOverRaycast = GetComponent<GraphicRaycaster>();
        gameOverRenderer = GetComponent<Canvas>();    
        HideGameOver();
    }

    private void ShowGameOver()
    {    
        StartCoroutine(OnShowGameOver());
    }

    private IEnumerator OnShowGameOver()
    {
        yield return new WaitForSeconds(timeToAppear);
        gameOverRenderer.enabled = true;
        gameOverRaycast.enabled = true;
    }

    private void HideGameOver()
    {
        gameOverRenderer.enabled = false;
        gameOverRaycast.enabled = false;
    }
}
