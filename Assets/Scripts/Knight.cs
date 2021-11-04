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
        enemies = GameObject.Find("EnemyParty").GetComponent<Character>();
    }

    private void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0)) //Left click. Wide attack.
        {
            chosenAttack = 1;
            Attack(1);
            Debug.Log("Wide attack");
        }
        if (Input.GetMouseButtonDown(1)) //Right click. Focused attack.
        {
            chosenAttack = 2;
            Attack(2);
            Debug.Log("Focused attack");
        }
        */
    }

    private void Attack(int attack)
    {
        switch (chosenAttack)
        {
            case 1: //wide attack
                for (int i = 0; i < enemies.GetEnemyLength(); i++)
                {
                    //Todo: Damage all enemies
                }
                break;
            case 2: //focused attack
                //Todo: Pick enemy
                break;
            
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
