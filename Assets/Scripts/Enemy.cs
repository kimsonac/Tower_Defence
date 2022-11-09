using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform[] destinations;
    [SerializeField] private Text healthText;
    [SerializeField] private GameObject spawn_VFX;
   // [SerializeField] private GameObject success_VFX;
    //[SerializeField] private GameObject fail_VFX;

    private NavMeshAgent agent;
    private Vector3 next;
    private int index;
    private int health;

    private void OnEnable()
    {
        spawn_VFX.SetActive(true);
        health = 5;
        healthText.text = string.Format("{0}", health);
        agent = GetComponent<NavMeshAgent>();
        transform.position = startPosition.position;
    }

    private void OnDisable()
    {
        spawn_VFX.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(_MoveToDestination());
    }

    private IEnumerator _MoveToDestination()
    {
        while(index < destinations.Length)
        {
            yield return null;
            next = new Vector3(destinations[index].position.x, 0, destinations[index].position.z);
            agent.SetDestination(destinations[index].position);

            if(Vector3.Distance(transform.position, destinations[index].position) <= 0.1f)
            {
                index++;
            }
        }

        gameObject.SetActive(false);
       // Destroy(Instantiate(fail_VFX, transform.position, Quaternion.identity), 1f);
        GameManager.gameManager.GoldDeduction(5);
    }

    private void OnParticleCollision(GameObject other)
    {
        health -= 1;

        if(health <= 0)
        {
         //   Destroy(Instantiate(success_VFX, transform.position, Quaternion.identity), 1f);
            gameObject.SetActive(false);
            GameManager.gameManager.GoldCollect(10);
            healthText.text = "0";
        }

        healthText.text = string.Format("{0}", health);
    }
}
