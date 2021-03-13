using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocena : ScriptableObject
{
    Plansza planszaNaKtorejGra;
    String kolor;
    int[,] punktyZaRuch = {
        {3,4,5,7,5,4,3},
        {4,6,8,10,8,6,4},
        {5,8,11,13,11,8,5},
        {5,8,11,13,11,8,5},
        {4,6,8,10,8,6,4},
        {3,4,5,7,5,4,3}
    };

    public Ocena(Plansza p, String k)
    {
        planszaNaKtorejGra = p;
        kolor = k;
    }

    public int ocenaGlebokosc(String kolorGracza, int rzad, int kolumna, int glebokosc)
    {
        if (planszaNaKtorejGra.czyKoniec(kolorGracza, kolumna))
        {
            if (kolorGracza.Equals(kolor))
            {
                return glebokosc;
            }
            else
            {
                return -glebokosc;
            }
        }
        else if (planszaNaKtorejGra.czyPelnaPlansza())
        {
            return 0;
        }
        else if (glebokosc == 0)
        {
            return 0;
        }
        else
        {
            return -1000;
        }

    }

    public int ocenaRuchow(String kolorGracza)
    {
        int ocenaStanu = 50;
        for(int i = 0; i < 6; i ++)
        {
            for(int j = 0; j < 6; j ++)
            {
                if(planszaNaKtorejGra.polaWPlanszy[i,j].pokazKolor().Equals(kolorGracza))
                {
                    ocenaStanu += punktyZaRuch[i, j];
                }
                else if(!planszaNaKtorejGra.polaWPlanszy[i, j].pokazKolor().Equals("P"))
                {
                  //  ocenaStanu -= punktyZaRuch[i, j];
                }
            }
        }
        return ocenaStanu;
    }
}
