﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHPAppear : MonoBehaviour
{
    //public GameObject HPAppear;
    public GameObject colliderDisable;
    public GameObject WallAppear;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //HPAppear.SetActive(true);
            colliderDisable.SetActive(false);
            WallAppear.SetActive(true);


        }
    }
}
