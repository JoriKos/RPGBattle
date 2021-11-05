using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int attackDamage; //Single attack, selected person
    [SerializeField] private Character players;

    private void Awake()
    {
        players = GameObject.Find("UIManager").GetComponent<Character>();
    }

    public int GetAttackDamage()
    {
        return attackDamage;
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
