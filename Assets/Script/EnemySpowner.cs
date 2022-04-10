using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
{
    public GameObject []enemy;
    public float respownTime=2f;
    void Start()
    {
        StartCoroutine(enemySpowner());
    }

    void Update()
    {
        
    }

    
    void spownEnemy()
    {
        int enemyRange = Random.Range(0, enemy.Length);
        int RangeXpos = Random.Range(-2, 2);
        Instantiate(enemy[enemyRange], new Vector2(RangeXpos, transform.position.y), Quaternion.identity);
    }
    IEnumerator enemySpowner()
    {
        while (true)
        {
            spownEnemy();
            yield return new WaitForSeconds(respownTime);
        }
    }
}
