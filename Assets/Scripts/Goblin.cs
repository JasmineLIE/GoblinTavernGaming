using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Goblin : MonoBehaviour
{
    [SerializeField] private string Name;

    /*
    * Cup Size: small, medium, large
    * Ice Cubes: 1, 3
    * Flavors: Sweet, Spicy, Bitter, Sour
    */
    [SerializeField] private bool[] CupSizePreference = new bool[3];
    [SerializeField] private bool[] IcePreference = new bool[2];
    [SerializeField] private bool[] FlavorPreference = new bool[4];
    [SerializeField] private string Occupation;
    [SerializeField] private string Alises;
    [SerializeField] private int TabAmount;
    [SerializeField] private string Description;
    [SerializeField] private int[] Preference = new int[3];
    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesiredDrink()
    {
        int CupNum = UnityEngine.Random.Range(0, CupSizePreference.Length);
        int IceNum = UnityEngine.Random.Range(0, IcePreference.Length);
        int FlavorNum = UnityEngine.Random.Range(0, FlavorPreference.Length);

        if (CupSizePreference[CupNum] == true) 
        {
            Preference[0] = CupNum;
        }
        else 
        {
            Preference[0] = -1;
        }

        if (IcePreference[IceNum] == true) 
        {
            Preference[1] = IceNum;
        } 
        else 
        {
            Preference[1] = -1;
        }
        
        if (FlavorPreference[FlavorNum] == true) 
        {
            Preference[2] = FlavorNum;  
        } 
        else 
        {
            Preference[2] = -1;
        }
    }

    public int Result(int Cup, int Ice, int Flavor)
    {
        int Result = 0;
        int Win = 10;
        int SlayWin = 20;
        
        if (Preference[0] == Cup)
        {
            Result += SlayWin;
        }
        else if (CupSizePreference[Cup] ==  true)
        {
            Result += Win;
        }

        if (Preference[1] == Ice)
        {
            Result += SlayWin;
        }
        else if (IcePreference[Ice] ==  true)
        {
            Result += Win;
        }

        if (Preference[2] == Flavor)
        {
            Result += SlayWin;
        }
        else if (FlavorPreference[Flavor] ==  true)
        {
            Result += Win;
        }

        return Result;   
    }
}
