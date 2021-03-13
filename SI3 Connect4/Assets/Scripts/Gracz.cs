using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gracz : ScriptableObject
{
    static int najlepszy = 0;
    public String kolor;
    Plansza planszaNaKtorejGra;
    static System.Random losowacz = new System.Random();
    int glebokosc;
    String rodzaj = "CZLOWIEK";
    Ocena ocenaUzytecznosci;
    bool pierwszyRuch = true;
    String algorytm;
    String heurystyka;
    long iloscWezlow;
    long milisekundyDzialania;
    int ileWykonanychRuchow;
    Rogzrywka rozgrywka;

    public void AIThinking(object obj)
    {
        int najlepszaOcena = -100000;
        int najlepszyRuch = -1;
        List<int> kolumnyDoWykorzystania = obj as List<int>;
        while (kolumnyDoWykorzystania.Count > 0)
        {
            int i = kolumnyDoWykorzystania[losowacz.Next(0, kolumnyDoWykorzystania.Count)];
            kolumnyDoWykorzystania.Remove(i);
            int kolumna = planszaNaKtorejGra.wrzucZeton(kolor, i, "o kurdelebele");
            if (kolumna != -1)
            {
                int ocenaSciezki = 0;
                ocenaSciezki = alfaBeta(glebokosc, kolor.Equals("C") ? "Z" : "C", i, kolumna, kolor, Int32.MinValue, Int32.MaxValue);
                //  Console.WriteLine(kolor + " " + i + " " + ocenaSciezki);
                if (ocenaSciezki > najlepszaOcena)
                {
                    najlepszaOcena = ocenaSciezki;
                    najlepszyRuch = i;
                }
                planszaNaKtorejGra.cofnijWrzucenieZetonu(i, kolumna);
            }
        }
        Info.Instance.czyKoniec = rozgrywka.czyRuchWygral(this, najlepszyRuch);
    }

    public Gracz(String k, Plansza p, int g, String r, Rogzrywka r2)
    {
        rodzaj = r;
        glebokosc = g;
        iloscWezlow = 0;
        milisekundyDzialania = 0;
        ileWykonanychRuchow = 0;
        if (k.Equals("czerwony"))
        {
            kolor = "C";
        }
        else
        {
            kolor = "Z";
        }
        planszaNaKtorejGra = p;
        rozgrywka = r2;
    }

    public void podajRzad(Rogzrywka rozgrywka)
    {
        if (rodzaj.Equals("MASZYNA"))
        {
            ileWykonanychRuchow++;           
            List<int> kolumnyDoWykorzystania = new List<int>(new int[7] { 0, 1, 2, 3, 4, 5, 6 });
            ocenaUzytecznosci = new Ocena(planszaNaKtorejGra, kolor);

            if(kolor.Equals("C") && pierwszyRuch)
            {
                pierwszyRuch = false;
                Info.Instance.czyKoniec = rozgrywka.czyRuchWygral(this, kolumnyDoWykorzystania[losowacz.Next(0, kolumnyDoWykorzystania.Count)]);
            }
            else
            {
                ParameterizedThreadStart ts = new ParameterizedThreadStart(AIThinking);              
                Thread watekMysleniaMaszyny = new Thread(ts);
                // Uruchamiamy wątek pochodny
                watekMysleniaMaszyny.Start(kolumnyDoWykorzystania);              
            }
        }
        else
        {
            int kolumna = Info.Instance.kolumnaCzlowieka;
            Info.Instance.nowyRuchCzlowieka = false;
            Info.Instance.czyKoniec = rozgrywka.czyRuchWygral(this, kolumna);
        }
    }

    public int alfaBeta(int glebokoscDrzewa, String kolorGracza, int rzadGraczaPoprzedniego, int kolumnaGraczaPoprzedniego, String kolorGraczaPoprzedniego, int alfa, int beta)
    {
        iloscWezlow++;
        int ocenaPoprzedniego = 0;
        if (kolor.Equals("C"))
        {
            ocenaPoprzedniego = ocenaUzytecznosci.ocenaGlebokosc(kolorGraczaPoprzedniego, rzadGraczaPoprzedniego, kolumnaGraczaPoprzedniego, glebokoscDrzewa);           
        }
        else
        {
            ocenaPoprzedniego = ocenaUzytecznosci.ocenaGlebokosc(kolorGraczaPoprzedniego, rzadGraczaPoprzedniego, kolumnaGraczaPoprzedniego, glebokoscDrzewa);
        }
        if (ocenaPoprzedniego != -1000)
        {
            return ocenaPoprzedniego;
        }

        List<int> kolumnyDoWykorzystania = new List<int>(new int[7] { 0, 1, 2, 3, 4, 5, 6 });

        if (kolorGracza.Equals(this.kolor))
        {
            for (int i = 0; i < 7; i++)
            {
               
                int kolumna = planszaNaKtorejGra.wrzucZeton(kolorGracza, i , "fuck");
                if (kolumna != -1)
                {
                    int ocenaSciezki = alfaBeta(glebokoscDrzewa - 1, kolorGracza.Equals("C") ? "Z" : "C", i, kolumna, kolorGracza, alfa, beta);
                    if (ocenaSciezki > alfa)
                    {
                        alfa = ocenaSciezki;
                    }
                    planszaNaKtorejGra.cofnijWrzucenieZetonu(i, kolumna);
                    if(alfa >= beta)
                    {
                        return beta;
                    }
                }
            }
            return alfa;
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                int kolumna = planszaNaKtorejGra.wrzucZeton(kolorGracza, i, "kuxwa");
                if (kolumna != -1)
                {
                    int ocenaSciezki = alfaBeta(glebokoscDrzewa - 1, kolorGracza.Equals("C") ? "Z" : "C", i, kolumna, kolorGracza, alfa, beta);
                    if (ocenaSciezki < beta)
                    {
                        beta = ocenaSciezki;
                    }
                    planszaNaKtorejGra.cofnijWrzucenieZetonu(i, kolumna);
                }
                if (alfa >= beta)
                {
                    return alfa;
                }
            }
            return beta;
        }
    }

    public long getIloscWezlow()
    {
        return iloscWezlow;
    }

    public String getAlgorytm()
    {
        return algorytm;
    }

    public String getHeurystyka()
    {
        return heurystyka;
    }

    public long getMilisekundyTrwania()
    {
        return milisekundyDzialania;
    }

    public int getGlebokosc()
    {
        return glebokosc;
    }

    public int getIleWykonanychRuchow()
    {
        return ileWykonanychRuchow;
    }
}
