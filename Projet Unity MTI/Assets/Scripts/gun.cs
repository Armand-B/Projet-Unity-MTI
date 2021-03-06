﻿using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
  

    public AudioSource sound;
    public Animator anim;
    public Camera  fpsCam;
    public ParticleSystem muzzleFLash;

    public GameObject impactEffect;

    // Update is called once per frame
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            sound.Play();
            print("yes");
            anim.Play("shot");
            Shoot();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            if (fpsCam.fieldOfView == 40)
            {
                fpsCam.fieldOfView = 60;
            }
            else
            {
               fpsCam.fieldOfView = 40;
            }
            
        }
    }


    void Shoot()
    {

        muzzleFLash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range))
        {
           
            target target  = hit.transform.GetComponent<target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGo =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
           

        }
    }
}
