using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private float spawnSpeed;
    private int idx;

    private void Start()
    {
        idx = 0;
        StartCoroutine(_SpawnEnemy());
    }

    private IEnumerator _SpawnEnemy()
    {
        while (true)
        {
            enemys[idx].SetActive(true);
            yield return new WaitForSeconds(spawnSpeed);
            idx++;
            
            if(idx >= enemys.Length && !enemys[0].activeSelf)
            {
                idx = 0;
            }
        }
    }
}
