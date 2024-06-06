using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadcrumbsObj : InteractableObj
{

    public override void Interact()
    {

        Hide();

    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }

}
