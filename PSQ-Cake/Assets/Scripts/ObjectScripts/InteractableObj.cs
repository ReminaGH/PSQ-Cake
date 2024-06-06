using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    private GameInput gameInput;


    public void Interact() {

        Debug.Log("Interact: E");

    }

    public void InteractAlt()
    {

        Debug.Log("Interact: F");
        

    }
    private void Show()
    {
        

    }
    private void Hide()
    {

        this.gameObject.SetActive(false);

    }
   
    
}


