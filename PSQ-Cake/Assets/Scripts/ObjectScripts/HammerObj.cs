using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerObj : InteractableObj
{
    public override void Interact()
    {

        Hide();
        Player.Instance.hasHammer = true;

    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }
}
