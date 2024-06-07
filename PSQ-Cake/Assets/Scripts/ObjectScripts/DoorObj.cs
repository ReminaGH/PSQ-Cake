using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObj : InteractableObj
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

       if(Player.Instance.hasKey)
        { 
            Debug.Log("Touced");
            Hide();
        }
       else
        {
            ChatbubbleUI.Instance.AddText("I should get the key first!");
        }
    }
    private void Show()
    {
        this.gameObject.SetActive(true);
    }
    private void Hide()
    {
        this.gameObject.SetActive(false);

    }
}
