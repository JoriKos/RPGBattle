using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int healingAmount;
    [SerializeField] private int spellDamage;
    [SerializeField] private Character enemies;

    private void Awake()
    {
        enemies = GameObject.Find("UIManager").GetComponent<Character>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SetHealth(int value, bool subtract) //value = value to modify with, subtract = subtract or add to health
    {
        switch (subtract)
        {
            case true:
                health -= value;
                break;
            case false:
                health += value;
                break;
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
