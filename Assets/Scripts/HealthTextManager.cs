using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HealthTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] text;
    [SerializeField] private Wizard wizard;
    [SerializeField] private Knight knight;
    [SerializeField] private Enemy[] enemies;

    private void Update()
    {
        text[0].text = wizard.GetHealth().ToString();
        text[1].text = knight.GetHealth().ToString();
        text[2].text = enemies[0].GetHealth().ToString();
        text[3].text = enemies[1].GetHealth().ToString();
    }
}
