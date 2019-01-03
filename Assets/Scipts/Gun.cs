using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 50f;

    public float maxAmmo = 20;
    public float currrentAmmo = 0  ;
    public float reloadTime = 1f;

    private bool isReloading = false;


    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    [SerializeField]
    private Transform weaponHolder;

    private void Awake()
    {
        transform.SetParent(weaponHolder);
    }

    // Start is called before the first frame update
    void Start()
    {
        currrentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;
        

        if (currrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }



        if (fireRate <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Shoot();
            }

        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {

                InvokeRepeating("Shoot", 0f, 1f / fireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }

        }
    }



    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(.2f);
        currrentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {

       

        currrentAmmo--;


        RaycastHit hit;
        //Debug.Log(currrentAmmo);
        muzzleFlash.Play();

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform);
            

            if (hit.collider.tag == "Crate")
            {

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                
               
            }
            if (hit.collider.tag == "Bottle")
            {

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }


            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObj, 2f);
        }
    }
}
