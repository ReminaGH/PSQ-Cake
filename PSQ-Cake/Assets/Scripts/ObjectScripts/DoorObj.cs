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
            Debug.Log("I should get the key");
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
