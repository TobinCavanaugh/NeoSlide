using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public NavMeshAgent navMeshAgent;

    public Transform shooter;

    public GameObject projectile;

    public float timeBetweenShots = 2f;
    private float curTime;

    public LayerMask lineCastMask;

    public int shotsInBurst = 1;
    public float timeBetweenBurstShots = .1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerBody").transform;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.position);
        shooter.LookAt(player.position);

        curTime += Time.deltaTime * Random.Range(.97f, 1.03f);


        if (curTime >= timeBetweenShots)
        {
            if (!Physics.Linecast(transform.position, player.position, lineCastMask))
            {
                StartCoroutine(Shoot());

            }
        }
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i < shotsInBurst; i++)
        {
            var t = Instantiate(projectile, shooter.position, Quaternion.identity).transform;
            t.forward = shooter.forward;
            yield return new WaitForSeconds(timeBetweenBurstShots);
        }
        
        curTime = 0;

    }
}