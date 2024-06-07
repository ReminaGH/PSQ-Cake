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

            ChatbubbleUI.Instance.AddText("I think I left my hammer downstairs!");

        }
        

    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }

}
