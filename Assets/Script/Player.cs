using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject fireEffectPrefab;
    public float MovementSpeed = 10f;
    public Score scoreCount;
    float padding = 0.8f;
    float minX;
    float maxX;
    float minY;
    float maxY;

    public PlayerHealthbar healthBar;
    public float health = 20f;
    float barSize = 1f;
    float damage = 0;
    void Start()
    {
        getBoundary();
        damage = barSize / health;
    }
    void DamageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthBar.BarSize(barSize);

        }
    }
    void getBoundary()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3 (0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3 (1, 0, 0)).x - padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3 (0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3 (0, 1, 0)).y - padding;
    }
    
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        float newXpos = Mathf.Clamp(transform.position.x + deltaX,minX,maxX) ;
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXpos, newYpos);
    }
    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.gameObject.tag == "EnemyBullet")
        {
            DamageHealthBar();
            Destroy(Object.gameObject);
            GameObject fireEffect = Instantiate(fireEffectPrefab, Object.transform.position, Quaternion.identity);
            Destroy(fireEffect, 0.1f);
            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject explosion = Instantiate(playerExplosion, transform.position, Quaternion.identity);
                Destroy(explosion, 0.4f);
            }
        }

        if (Object.gameObject.tag == "Coin")
        {
            Destroy(Object.gameObject);
            scoreCount.AddScore();
        }
    }
}
