using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject PrefMenu;
    [SerializeField] private GameObject objectMenu;
    [SerializeField] private GameObject[] emptyCoins;
    [SerializeField] private GameObject[] fullCoins;
    [SerializeField] public GameObject[] buttons;
    [SerializeField] private Text name;

    //[SerializeField] private List<GameObject> buttonsList;
    private bool ifSelected;
    private int coinsAmount;
    private bool active;


    void Start()
    {
        PrefMenu.SetActive(false);
    }

    void Update()
    {
        if (active == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateCoins(1);
                active = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ActivateCoins(2);
                active = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ActivateCoins(3);
                active = false;
            }
        }
    }

    public void ClosePrefMenu()
    {
        PrefMenu.SetActive(false);
    }

    public void activeButton()
    {
        PrefMenu.SetActive(true);
        active = true;
    }
    private void ActivateCoins(int amount)
    {
        for (var i = 0; i < emptyCoins.Length; i++)
        {
            fullCoins[i].SetActive(i < amount);
        }
        coinsAmount = amount;
    }
    
}
