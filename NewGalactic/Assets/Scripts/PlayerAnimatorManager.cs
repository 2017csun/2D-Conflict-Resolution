﻿using UnityEngine;
using System.Collections;

public class PlayerAnimatorManager : Photon.MonoBehaviour
{
    #region MONOBEHAVIOUR MESSAGES

    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        if (!animator)
        {
            Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine == false && PhotonNetwork.connected == true)
        {
            return;
        }
    }


    #endregion
}
