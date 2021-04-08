using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plansza : ScriptableObject
{
    public Kolko[,] polaWPlanszy = new Kolko[6, 7];

    public Plansza()
    {
        for (int k = 0; k < 6; k++)
        {
            for (int r = 0; r < 7; r++)
            {
                polaWPlanszy[k, r] = new Kolko();
            }
        }
    }

    public Boolean czyPelnaPlansza()
    {
        for (int k = 0; k < 6; k++)
        {
            for (int r = 0; r < 7; r++)
            {
                if (polaWPlanszy[k, r].pokazKolor().Equals("P"))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public int wrzucZeton(String kolor, int miejsce, String info)
    {
        int pierwszeWolne = 5;

      //  Debug.Log(miejsce + " " + info);
        while (pierwszeWolne >= 0 && !polaWPlanszy[pierwszeWolne, miejsce].pokazKolor().Equals("P"))
        {
            pierwszeWolne--;
        }
        if (pierwszeWolne == -1)
        {
            return -1;
        }
        else
        {
            polaWPlanszy[pierwszeWolne, miejsce].zmienNaKolor(kolor);
            return pierwszeWolne;
        }
    }

    public Boolean czyKoniec(String kolor, int kol)
    {
        for (int kolumna = 0; kolumna <= 2; kolumna++)
        {
            for (int rzad = 0; rzad < 7; rzad++)
            {

                if (polaWPlanszy[kolumna, rzad].pokazKolor().Equals(kolor) && polaWPlanszy[kolumna + 1, rzad].pokazKolor().Equals(kolor) &&
                    polaWPlanszy[kolumna + 2, rzad].pokazKolor().Equals(kolor) && polaWPlanszy[kolumna + 3, rzad].pokazKolor().Equals(kolor))
                {
                    return true;
                }
                if (rzad >= 3 && polaWPlanszy[kolumna, rzad].pokazKolor().Equals(kolor) && polaWPlanszy[kolumna + 1, rzad - 1].pokazKolor().Equals(kolor) &&
                    polaWPlanszy[kolumna + 2, rzad - 2].pokazKolor().Equals(kolor) && polaWPlanszy[kolumna + 3, rzad - 3].pokazKolor().Equals(kolor))
                {
                    return true;
                }
                if (rzad <= 3 && polaWPlanszy[kolumna, rzad].pokazKolor().Equals(kolor) && polaWPlanszy[kolumna + 1, rzad + 1].pokazKolor().Equals(kolor) &&
                    polaWPlanszy[kolumna + 2, rzad + 2].pokazKolor().Equals(kolor) && polaWPlanszy[kolumna + 3, rzad + 3].pokazKolor().Equals(kolor))
                {
                    return true;
                }
            }
        }

        int liczbaWKolumnie = 0;
        for (int rz = 0; rz < 7; rz++)
        {
            // Console.WriteLine(kolumna + " " + rzad);
            if (polaWPlanszy[kol, rz].pokazKolor().Equals(kolor))
            {
                liczbaWKolumnie++;
                if (liczbaWKolumnie == 4)
                {
                    return true;
                }
            }
            else
            {
                liczbaWKolumnie = 0;
            }
        }
        return false;
    }

    public void cofnijWrzucenieZetonu(int rzad, int kolumna)
    {
        polaWPlanszy[kolumna, rzad].zmienNaKolor("P");
    }
}
