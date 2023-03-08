using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public List<GameObject> prefabs = new();

    public List<GameObject> aliveEnemies = new();
    public int curRound = 0;

    public Transform[] positions;

    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        aliveEnemies = aliveEnemies.Where(x => x != null).ToList();

        if (aliveEnemies.Count == 0)
        {
            curRound++;
            textMeshProUGUI.text = "Round " + curRound;
            for (int i = 0; i < positions.Length; i++)
            {
                for (int v = 0; v < curRound; v++)
                {
                    aliveEnemies.Add(Instantiate(prefabs[0], positions[i]));
                }

                if (curRound > 3)
                {
                    for (int v = 0; v < curRound / 2; v++)
                    {
                        aliveEnemies.Add(Instantiate(prefabs[1], positions[i]));
                    }
                }
            }
        }
    }
}