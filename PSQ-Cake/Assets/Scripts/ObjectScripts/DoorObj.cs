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
            if (Player.Instance.canTalk == true)
            {
                
                ChatbubbleUI.Instance.AddText("xI should get the key first!");
            }
            Player.Instance.canTalk = false;

            StartCoroutine(DelayedActionCanTalk());
            
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

    IEnumerator DelayedActionCanTalk()
    {
        // Delay for 3 seconds
        yield return new WaitForSeconds(4);

        Player.Instance.canTalk = true;
    }
}
