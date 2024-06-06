using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    private GameInput gameInput;


    public virtual void Interact() 
    {
        
    }

    public virtual void InteractAlt()
    {

    }
    private void Show()
    {
        
    }
    private void Hide()
    {

        this.gameObject.SetActive(false);

    }
   
    
}


