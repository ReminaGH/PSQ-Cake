using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObj : InteractableObj
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player.Instance.hasKey = true;
        Hide(); 
        
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
