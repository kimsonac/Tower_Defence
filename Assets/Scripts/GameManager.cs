using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public event Action<int> OnGoldChange;
    private int gold = 20;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeGoldText();
    }

    private void ChangeGoldText()
    {
        OnGoldChange(gold);
    }

    public void GoldDeduction(int amount)
    {
        gold -= amount;

        if(gold <= 0)
        {
            // 게임 오버
        }

        ChangeGoldText();
    }

    public void GoldCollect(int amount)
    {
        gold += amount;
        ChangeGoldText();
    }

}
