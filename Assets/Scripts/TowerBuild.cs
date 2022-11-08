using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] GameObject valid_Layout;
    [SerializeField] GameObject unvalid_Layout;
    [SerializeField] GameObject towerPrefab;
    [SerializeField] GameObject towerLayout;

    private bool isBulit = false;

    private void OnMouseOver()
    {
        if (gameObject.CompareTag("Valid") && !isBulit)
        {
            valid_Layout.SetActive(true);
        }

        if (gameObject.CompareTag("Unvalid") || isBulit)
        {
            unvalid_Layout.SetActive(true);
        }
        towerLayout.SetActive(true);
    }

    private void OnMouseExit()
    {
        if(valid_Layout.activeSelf || unvalid_Layout.activeSelf)
        {
            valid_Layout.SetActive(false);
            unvalid_Layout.SetActive(false);
        }

        towerLayout.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!isBulit && gameObject.CompareTag("Valid"))
        {
            isBulit = true;
            towerLayout.SetActive(false);
            towerPrefab.SetActive(true);
        }
        
    }
}
