using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject flash;
    public GameObject enemyExplosion;
    public GameObject fireEffectPrefab;
    public GameObject coinSpown;
    public Transform []gunpoint;
    public float bulletFireGap = 0.5f;
    public float speed = 0.5f;
    public HealthBar healthBar;
    public float health = 6f;
    float barSize = 1f;
    float damage = 0;
    float padding = 0.8f;
    float minX;
    float maxX;

    void Start()
    {
        getBoundary();
        StartCoroutine(Shoot());
        flash.SetActive(false);
        damage = barSize / health;
    }

    
    void Update()
    {
        float newXpos = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector2(newXpos, transform.position.y);

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void DamageHealthBar()
    {
        if(health>0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthBar.BarSize(barSize);

        }
    }
    private void OnTriggerEnter2D(Collider2D Object)
    {   if(Object.gameObject.tag=="PlayerBullet")
        { 
            DamageHealthBar();
            Destroy(Object.gameObject);
            GameObject fireEffect = Instantiate(fireEffectPrefab, Object.transform.position, Quaternion.identity);
            Destroy(fireEffect, 0.1f);
            if (health<=0)
            {
                Destroy(gameObject);
                GameObject Coin = Instantiate(coinSpown, transform.position, Quaternion.identity);
                GameObject explosionClone = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                Destroy(explosionClone, 0.3f);
            }
        }

    }
    void Fire()
     {
        for (int i = 0; i < gunpoint.Length; i++)
        {
        Instantiate(enemyBullet, gunpoint[i].position, Quaternion.identity);
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletFireGap);
            Fire();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            flash.SetActive(false);
        }
    }

    void getBoundary()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}
