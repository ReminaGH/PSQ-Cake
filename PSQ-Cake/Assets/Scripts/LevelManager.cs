using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] GameObject introAnimation;

    public string sceneName;
    public float transitionTime = 7f;

    public void changeScene() 
    {
        introAnimation.SetActive(true);
        animator.SetTrigger("playAnitmation");
        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene() 
    {
        animator.SetTrigger("playAnitmation");

        yield return new WaitForSeconds(transitionTime);    

        SceneManager.LoadScene(sceneName);

    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
