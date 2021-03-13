using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolko : ScriptableObject
{
    private String kolor;

    public Kolko()
    {
        kolor = "P";
    }

    public void zmienNaKolor(String k)
    {
        kolor = k;
    }

    public String pokazKolor()
    {
        return kolor;
    }
}
