using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Wizard wizard;
    [SerializeField] private Knight knight;
    [SerializeField] private Enemy[] enemies;

    public void WizardFocusedAttack(int i)
    {
        Debug.Log(i);
        enemies[i].SetHealth(wizard.GetFocusedDamage(), true);
    }

    public void WizardWideAttack()
    {
        enemies[0].SetHealth(wizard.GetWideDamage(), true);
        enemies[1].SetHealth(wizard.GetWideDamage(), true);
    }

    public void WizardFocusedHeal(int i)
    {
        if (i == 0)
        {
            knight.SetHealth(wizard.GetHealingAmount(), false);
        }
        if (i == 1)
        {
            wizard.SetHealth(wizard.GetHealingAmount(), false);
        }
    }

    public void WizardWidedHeal()
    {
        wizard.SetHealth(wizard.GetHealingAmount(), false);
        knight.SetHealth(wizard.GetHealingAmount(), false);
    }

    public void KnightFocusedAttack(int i)
    {
        enemies[i].SetHealth(knight.GetFocusedDamage(), true);
    }

    public void KnightWideAttack()
    {
        enemies[0].SetHealth(knight.GetWideDamage(), true);
        enemies[1].SetHealth(knight.GetWideDamage(), true);
    }

    public void KnightFocusedHeal(int i)
    {
        if (i == 0)
        {
            wizard.SetHealth(knight.GetHealingAmount(), false);
        }
        if (i == 1)
        {
            wizard.SetHealth(knight.GetHealingAmount(), false);
        }
    }

    public void KnightWideHeal()
    {
        wizard.SetHealth(knight.GetHealingAmount(), false);
        knight.SetHealth(knight.GetHealingAmount(), false);
    }
}
