using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerObj : InteractableObj
{
    private string HammerText;

    public override void Interact()
    {

        Hide();
        Player.Instance.hasHammer = true;

    }

    public override void InteractAlt()
    {

        HammerText = "xHammer!";
        ChatbubbleUI.Instance.AddText(HammerText);

    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }
}
