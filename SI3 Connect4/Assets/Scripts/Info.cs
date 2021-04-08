using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : ScriptableObject
{
    public string pierwszyGracz = "";
    public string drugiGracz = "";
    public string kolejnosc = "";
    public string kolorPierwszy = "";
    public string kolorDrugi = "";
    public int rzad = 0;
    public bool czyKoniec = false;
    public bool czy = false;
    public bool poOpadnieciu = false;
    public int liczbaRuchow = 0;
    public int kolumnaCzlowieka = 0;
    public bool nowyRuchCzlowieka = false;
    public bool czyCzlowiek1 = false;
    public bool czyCzlowiek2 = false;
    public bool blad = false;
    public bool wykonywanyRuch = false;
    public string kolorWrzucanegoZetonu = "C";
    public bool tuJuzNie = false;
    public int glebokosc = 6;
    public bool zmiana = true;
    public bool canNext = true;
    private static readonly Info instance = new Info();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static Info()
    {
    }

    private Info()
    {
    }

    public static Info Instance
    {
        get
        {
            return instance;
        }
    }

    public void restartGame()
    {    
        kolejnosc = ""; 
        rzad = 0; 
        czyKoniec = false; 
        czy = false; 
        poOpadnieciu = false; 
        liczbaRuchow = 0; 
        kolumnaCzlowieka = 0; 
        nowyRuchCzlowieka = false;     
        blad = false;
        wykonywanyRuch = false;
        kolorWrzucanegoZetonu = "C"; 
        tuJuzNie = false; 
        zmiana = true;
        canNext = true;
}

    public void resetGame()
    {
        pierwszyGracz = "";
        drugiGracz = "";
        kolorPierwszy = "";
        kolorDrugi = "";
        czyCzlowiek1 = false;
        czyCzlowiek2 = false;
        restartGame();
    }
}
