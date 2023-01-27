using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerLifeUI : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    [SerializeField] private float duration;

    [SerializeField] private Image blackBar;
    [SerializeField] private float backBarDuration;

    private void OnEnable() => PlayerLifeController.uiLife += UpdateUI;
    private void OnDisable() => PlayerLifeController.uiLife -= UpdateUI;

    private void UpdateUI(float lifePoints, float maxLifePoints)
    {
        DOTweenModuleUI.DOFillAmount(lifeBar,lifePoints / maxLifePoints, duration).OnComplete(() => StartCoroutine(UpdateBackBar()));
    }
    private IEnumerator UpdateBackBar()
    {
        yield return new WaitForSeconds(0.5f);
        DOTweenModuleUI.DOFillAmount(blackBar, lifeBar.fillAmount, backBarDuration);
    }
}
