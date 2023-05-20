using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SevenGame.Utility;

public class LifeUI : MonoBehaviour
{

    [SerializeField] private Image lifeImage;
    [SerializeField] private Image trailImage;

    private bool lifeEnabled = true;



    public void RemoveLife()
    {
        lifeEnabled = false;
    }

    public void GiveLife()
    {
        lifeEnabled = true;
    }

    public void GiveLifeImmediate()
    {
        lifeEnabled = true;
        lifeImage.color = new Color(1f, 0f, 0f, 1f);
        trailImage.fillAmount = 0f;
    }


    private void Update()
    {
        if (lifeEnabled)
        {
            lifeImage.color = Color.Lerp(lifeImage.color, new Color(1f, 0f, 0f, 1f), GameUtility.timeUnscaledDelta * 2f);
            trailImage.fillAmount = Mathf.Lerp(trailImage.fillAmount, 0f, GameUtility.timeUnscaledDelta * 4f);
            return;
        }

        lifeImage.color = Color.Lerp(lifeImage.color, new Color(0.18f, 0.18f, 0.18f, 1f), GameUtility.timeUnscaledDelta * 5f);
        trailImage.fillAmount = Mathf.Lerp(trailImage.fillAmount, 1f, GameUtility.timeUnscaledDelta * 10f);
    }
}
