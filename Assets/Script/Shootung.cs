using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootung : MonoBehaviour
{

    public GameObject playerBullet;
    public GameObject flash;
    public Transform gunpointL;
    public Transform gunpointR;
    public float bulletSpeed = 0.5f;
    void Start()
    {
        StartCoroutine(Shoot());
        flash.SetActive(false);
    }

    
    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(playerBullet, gunpointL.position, Quaternion.identity);
        Instantiate(playerBullet, gunpointR.position, Quaternion.identity);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpeed);
            Fire();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            flash.SetActive(false);
        }
    }


}
