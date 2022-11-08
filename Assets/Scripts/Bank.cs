using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.gameManager.OnGoldChange += PrintScreen;
    }

    public void PrintScreen(int gold)
    {
        if(gold <= 0)
        {
            text.text = "Game Over!";
        }
        else
        {
            text.text = string.Format("{00}", gold);
        }

    }
}
