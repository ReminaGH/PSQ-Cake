using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjVissual : MonoBehaviour
{
    [SerializeField] private InteractableObj interactableObj;
    [SerializeField] private GameObject visualGameObject1;
    [SerializeField] private GameObject visualGameObject2;

    private void Start()
    {
        Player.Instance.OnSelectedObjChanged += Player_OnSelectedObjChanged;

    }

    private void Player_OnSelectedObjChanged(object sender, Player.OnSelectedObjChangedEventArgs e)
    {
        if(e.selectedObj == interactableObj)
        {
            Show();
        } 
        else
        {
            Hide();
        }
        
    }

    private void Show()
    {
        visualGameObject2.SetActive(true);

    }
    private void Hide()
    {
        visualGameObject2.SetActive(false);

    }
}
