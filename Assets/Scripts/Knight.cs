using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    private int chosenAttack; //1 = wide 2 = focused
    [SerializeField] private int health;
    [SerializeField] private Character enemies;
    [SerializeField] private int wideAttackDamage; //1. Wide attack, attacks all enemies. Less damage.
    [SerializeField] private int focusedAttackDamage; //2. Focused attack, attacks one enemy. More damage.

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
