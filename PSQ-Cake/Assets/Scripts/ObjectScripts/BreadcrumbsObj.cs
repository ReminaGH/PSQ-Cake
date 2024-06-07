using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadcrumbsObj : InteractableObj
{

    private string BreadcrumbText;

    public override void Interact()
    {

        Hide();

    }
    public override void InteractAlt()
    {
        Player.Instance.confusedAimationPlayed(3);
        BreadcrumbText = "xWhat's all this mess about?";
        ChatbubbleUI.Instance.AddText(BreadcrumbText);
        Hide();

    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }

}
