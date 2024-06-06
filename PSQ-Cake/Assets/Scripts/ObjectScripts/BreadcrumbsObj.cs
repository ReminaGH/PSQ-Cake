using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadcrumbsObj : InteractableObj
{


    public override void Interact()
    {
        
        Debug.Log("Override Interact");

    }

    public override void InteractAlt()
    {
        
        Debug.Log("Override Interact Alt");
        this.gameObject.SetActive(false);

    }

}
