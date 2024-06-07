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
        if (Player.Instance.canTalk == true)
        {
            HammerText = "xHammer!";
            ChatbubbleUI.Instance.AddText(HammerText);
        }
        Player.Instance.canTalk = false;
     
        StartCoroutine(DelayedActionCanTalk());

    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }
    IEnumerator DelayedActionCanTalk()
    {
        // Delay for 3 seconds
        yield return new WaitForSeconds(3);

        Player.Instance.canTalk = true;
    }
}
