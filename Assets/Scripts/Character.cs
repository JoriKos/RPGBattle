using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] players;

    private void Awake()
    {
        FillGameObjectArray(enemies, "Enemy");
        FillGameObjectArray(players, "Player");
    }

    public int GetEnemyLength()
    {
        return enemies.Length;
    }
    public GameObject GetEnemyAtIndex(int index)
    {
        return enemies[index];
    }

    public GameObject GetPlayerAtIndex(int index)
    {
        return players[index];
    }

    public int GetPlayerLength()
    {
        return players.Length;
    }

    private void FillGameObjectArray(GameObject[] array, string objectName)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = GameObject.Find(objectName + i);
        }
    }
}
