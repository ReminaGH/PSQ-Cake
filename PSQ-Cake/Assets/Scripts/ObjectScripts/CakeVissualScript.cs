using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeVissualScript : MonoBehaviour
{
    public static CakeVissualScript Instance { get; private set; }

    public Animator animator;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();

    }
}
