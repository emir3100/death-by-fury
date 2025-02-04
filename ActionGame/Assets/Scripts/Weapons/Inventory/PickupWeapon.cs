﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public WeaponManager WeaponManagerScript;
    public float PickUpRange;
    [HideInInspector]
    public SphereCollider SphereCollider;
    [HideInInspector]
    public GameObject player;
    public bool IsInTrigger;
    private WeaponID WeaponId;
    

    

    public virtual void Start()
    {
        if(player == null)
            player = GameObject.FindWithTag("Player");

        if (WeaponManagerScript == null)
            WeaponManagerScript = GameObject.FindWithTag("WeaponManager").GetComponent<WeaponManager>();

        SphereCollider = this.gameObject.GetComponent<SphereCollider>();
        WeaponId = this.gameObject.GetComponent<WeaponID>();
        
    }

    public virtual void Update()
    {
        SphereCollider.radius = PickUpRange;

        if (IsInTrigger && Input.GetKeyDown(KeyCode.F))
            WeaponManagerScript.AddWeapon(WeaponId);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            IsInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            IsInTrigger = false;
        }
    }
}
