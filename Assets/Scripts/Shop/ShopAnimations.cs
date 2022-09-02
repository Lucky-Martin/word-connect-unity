using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimations : MonoBehaviour
{
    [SerializeField] CanvasGroup dimBackground;
    [SerializeField] GameObject modal;
    [SerializeField] public float animationDuration = 0.5f;
    [SerializeField] public float dimBackgroundAlpha = 0.3f;

    public void OpenShop()
    {
        gameObject.SetActive(true);

        dimBackground.alpha = 0;
        dimBackground.interactable = true;
        dimBackground.blocksRaycasts = true;
        dimBackground.LeanAlpha(dimBackgroundAlpha, animationDuration);

        modal.transform.localScale = new Vector2(0, 0);
        modal.transform.LeanScale(new Vector2(1, 1), animationDuration*2).setEaseOutBack().setDelay(animationDuration / 2);
    }

    public void CloseShop()
    {
        StartCoroutine(AnimateShopClose());
    }

    private IEnumerator AnimateShopClose()
    {
        modal.transform.LeanScale(new Vector2(0, 0), animationDuration).setEaseOutQuart();
        yield return new WaitForSeconds(animationDuration/2);
        dimBackground.LeanAlpha(0, animationDuration).setOnComplete(DisableGameObject);
    }

    private void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
