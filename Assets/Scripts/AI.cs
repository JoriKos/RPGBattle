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
    }

    private void Update()
    {
        if (!uiManager.GetPlayerTurnStatus())
        {
            randomTarget = Random.Range(0, 2);

            if (randomTarget == 0)
            {
                wizard.SetHealth(enemiesArray[0].GetAttackDamage(), true);
                wizard.SetHealth(enemiesArray[1].GetAttackDamage(), true);
                uiManager.SetPlayerTurnStatus(true);
            }

            if (randomTarget > 0)
            {
                knight.SetHealth(enemiesArray[0].GetAttackDamage(), true);
                knight.SetHealth(enemiesArray[1].GetAttackDamage(), true);
                uiManager.SetPlayerTurnStatus(true);
            }
        }
    }
}
