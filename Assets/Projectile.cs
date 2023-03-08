using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public HealthType damageType;
    public float damage = 1;

    public float moveAmount = 1f;
    private void Update()
    {
        transform.position += transform.forward * (Time.deltaTime * moveAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health hp))
        {
            if (damageType != hp.healthType)
            {
                hp.Damage(damage);
            }
            else
            {
                return;
            }
        }
        else
        {
            Destroy(this.gameObject);

        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Health hp))
        {
            if (damageType != hp.healthType)
            {
                hp.Damage(damage);
            }
            else
            {
                return;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);

    }
}