using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float timeBetweenShots = 1f;

    private float curTime = 0f;

    public GameObject projectile;

    public Transform shootPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= timeBetweenShots)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Shoot");
                curTime = 0;
                Shoot();
            }
        }
    }


    void Shoot()
    {
        var t = Instantiate(projectile, shootPos.position, Quaternion.identity).transform;
        t.forward = transform.forward;
    }
}
