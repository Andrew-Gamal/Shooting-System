using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] int xPos;
    [SerializeField] int zPos;
    [SerializeField] int EnemyCount;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }
   
    IEnumerator EnemySpawn()
    {
        while(EnemyCount < 10)
        {
            xPos = Random.Range(30, 60);
            zPos = Random.Range(50, 60);
            Instantiate(Enemy, new Vector3(xPos, 5, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            EnemyCount += 1;
        }
    }
  
}
