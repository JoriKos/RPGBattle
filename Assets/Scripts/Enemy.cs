using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Todo: Attack AI, heal AI
    [SerializeField] private int health;
    [SerializeField] private int attackDamage; //Single attack, selected person
    [SerializeField] private Character players;

    private void Awake()
    {
        
    }
}
