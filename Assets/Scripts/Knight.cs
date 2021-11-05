using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int healingAmount;
    [SerializeField] private int wideAttackDamage; //1. Wide attack, attacks all enemies. Less damage.
    [SerializeField] private int focusedAttackDamage; //2. Focused attack, attacks one enemy. More damage.
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

    public int GetHealingAmount()
    {
        return healingAmount;
    }

    public int GetFocusedDamage()
    {
        return focusedAttackDamage;
    }

    public int GetWideDamage()
    {
        return wideAttackDamage;
    }
}
