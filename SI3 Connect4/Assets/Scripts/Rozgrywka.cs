using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class Rogzrywka : ScriptableObject
{
    Plansza planszaRozgrywki;
    Gracz czerwony;
    Gracz zolty;

    public Rogzrywka()
    {
        planszaRozgrywki = new Plansza();
        string pier = Info.Instance.pierwszyGracz;
        string drug = Info.Instance.drugiGracz;
        czerwony = new Gracz("czerwony", planszaRozgrywki, Info.Instance.glebokosc, pier, this);
        zolty = new Gracz("zolty", planszaRozgrywki, Info.Instance.glebokosc, drug, this);
        if(pier.Equals("CZLOWIEK") && drug.Equals("CZLOWIEK"))
        {
            Info.Instance.pierwszyGracz = "CZLOWIEK 1";
            Info.Instance.drugiGracz = "CZLOWIEK 2";
        }
    }

    public void graj(int i)
    {
        Info.Instance.wykonywanyRuch = true;
        if (i == 1)
        {
            Info.Instance.kolorWrzucanegoZetonu = "C";
            czerwony.podajRzad(this);
          //  Info.Instance.czyKoniec = czyRuchWygral(czerwony);
        }
        else
        {
            Info.Instance.kolorWrzucanegoZetonu = "Z";
            zolty.podajRzad(this);
          //  Info.Instance.czyKoniec = czyRuchWygral(zolty);
        }
        Debug.Log(Info.Instance.kolorWrzucanegoZetonu);

    }

    public Boolean czyRuchWygral(Gracz gracz, int rzadDoKtoregoChceWrzucic)
    {
       // Thread.Sleep(1000);
        

        int kolumnaDoKtorejRzucil = planszaRozgrywki.wrzucZeton(gracz.kolor, rzadDoKtoregoChceWrzucic,"ja pitole");
        if (kolumnaDoKtorejRzucil != -1)
        {
            Info.Instance.rzad = rzadDoKtoregoChceWrzucic;
            Info.Instance.czy = true;
            Info.Instance.liczbaRuchow++;
            if(gracz.kolor.Equals("C"))
            {
                Info.Instance.kolejnosc = Info.Instance.drugiGracz;
            }
            else
            {
                Info.Instance.kolejnosc = Info.Instance.pierwszyGracz;
            }
            //   Debug.Log(Info.Instance.kolejnosc);
            Info.Instance.zmiana = true;
            return planszaRozgrywki.czyKoniec(gracz.kolor, kolumnaDoKtorejRzucil);
        }
        else
        {
            Info.Instance.tuJuzNie = true;
            return false;
        }


        
    }
}
