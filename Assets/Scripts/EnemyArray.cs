using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArray : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private void Awake()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = GameObject.Find("Enemy" + i);
        }
    }

    public int GetLength()
    {
        return enemies.Length;
    }
}
