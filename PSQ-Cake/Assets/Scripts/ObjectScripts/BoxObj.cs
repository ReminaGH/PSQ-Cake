using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObj : InteractableObj
{
    public override void Interact()
    {

        if(Player.Instance.hasHammer == true) 
        {

            Hide();

        }
        else
        {

            Debug.Log("I need hamma!");

        }
        

    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }

}
