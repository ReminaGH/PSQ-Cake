using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObj : InteractableObj
{
    public override void Interact()
    {

        if(Player.Instance.hasHammer == true) 
        {
            CakeVissualScript.Instance.animator.SetBool("isFound", true);
            Hide();

        }
        else
        {
            if (Player.Instance.canTalk == true) { 
            ChatbubbleUI.Instance.AddText("xI think I left my hammer downstairs!");
            }
            Player.Instance.canTalk = false;

            StartCoroutine(DelayedActionCanTalk());

        }
        

    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }

    IEnumerator DelayedActionCanTalk()
    {
        // Delay for 3 seconds
        yield return new WaitForSeconds(4);

        Player.Instance.canTalk = true;
    }

}
