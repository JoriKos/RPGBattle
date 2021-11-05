using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Character character;
    [SerializeField] private Wizard wizard;
    [SerializeField] private Knight knight;
    [SerializeField] private Enemy[] enemiesArray;
    private int randomTarget;

    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        character = GameObject.Find("UIManager").GetComponent<Character>();
        for (int i = 0; i < enemiesArray.Length; i++)
        {
            character.GetEnemyAtIndex(i).GetComponent<Enemy>();
        }
    }

    private void Update()
    {
        if (!uiManager.GetPlayerTurnStatus())
        {
            randomTarget = Random.Range(0, character.GetPlayerLength());

            if (randomTarget == 0)
            {
                for (int i = 0; i < enemiesArray.Length; i++)
                {
                    wizard.SetHealth(enemiesArray[i].GetAttackDamage(), true);
                }
            }

            if (randomTarget == 1)
            {
                for (int i = 0; i < enemiesArray.Length; i++)
                {
                    knight.SetHealth(enemiesArray[i].GetAttackDamage(), true);
                }
            }

            uiManager.SetPlayerTurnStatus(true);
        }
    }
}
