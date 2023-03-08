using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public HealthType healthType;

    public float curHealth;
    public float maxHealth = 10;

    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void Damage(float amount)
    {
        curHealth -= amount;

        if (slider is not null)
        {
            slider.maxValue = maxHealth;
            slider.value = curHealth;
        }

        if (curHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        curHealth += amount;

        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        
        if (slider is not null)
        {
            slider.maxValue = maxHealth;
            slider.value = curHealth;
        }
    }

    private void Die()
    {
        Debug.Log($"{name} Died!");

        if (healthType == HealthType.Enemy)
        {
            Destroy(this.gameObject);
            GameObject.Find("PlayerBody").GetComponent<Health>().Heal(1);
        }
    }
}

public enum HealthType
{
    Player, Enemy
}