using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;
using TMPro;

public class PowerCounter : MonoBehaviour
{
    [SerializeField] string kategoriArea;
    [SerializeField] TextMeshPro powerLabel;
    public CardGroup slot1;
    public CardGroup slot2;
    public CardGroup slot3;
    public CardGroup slot4;
    public int power;

    public void CountPower()
    {
        int power1 = 0;
        int power2 = 0;
        int power3 = 0;
        int power4 = 0;
        try
        {
            if (slot1.MountedCards != null)
            {
                //ngitung power slot 1
                if (kategoriArea == slot1.MountedCards[0].GetComponent<TrashCard>().Kategori.ToString())
                {
                    power1 = slot1.MountedCards[0].GetComponent<TrashCard>().Value;
                }
                else
                {
                    power1 = slot1.MountedCards[0].GetComponent<TrashCard>().Penalty;
                }
            }
            else { power1 = 0; }
        }
        catch { }
        try
        {
            if (slot2.MountedCards != null)
            {
                //ngitung power slot 2
                if (kategoriArea == slot2.MountedCards[0].GetComponent<TrashCard>().Kategori.ToString())
                {
                    power2 = slot2.MountedCards[0].GetComponent<TrashCard>().Value;
                }
                else
                {
                    power2 = slot2.MountedCards[0].GetComponent<TrashCard>().Penalty;
                }
            }
            else { power2 = 0; }
        }
        catch { }
        try
        {
            if (slot3.MountedCards != null)
            {
                //ngitung power slot 3
                if (kategoriArea == slot3.MountedCards[0].GetComponent<TrashCard>().Kategori.ToString())
                {
                    power3 = slot3.MountedCards[0].GetComponent<TrashCard>().Value;
                }
                else
                {
                    power3 = slot3.MountedCards[0].GetComponent<TrashCard>().Penalty;
                }
            }
            else { power3 = 0; }
        }
        catch { }
        try
        {
            if (slot4.MountedCards != null)
            {
                //ngitung power slot 4
                if (kategoriArea == slot4.MountedCards[0].GetComponent<TrashCard>().Kategori.ToString())
                {
                    power4 = slot4.MountedCards[0].GetComponent<TrashCard>().Value;
                }
                else
                {
                    power4 = slot4.MountedCards[0].GetComponent<TrashCard>().Penalty;
                }
            }
            else { power4 = 0; }
        }
        catch { }
        power = power1 + power2 + power3 + power4;

    }

    public void DisplayPower()
    {
        powerLabel.text = power.ToString();
    }

    private void Update()
    {
        DisplayPower();
    }
}
