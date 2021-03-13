using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : ScriptableObject
{
    public string pierwszyGracz = "";
    public string drugiGracz = "";
    public string kolejnosc = "";
    public string kolorPierwszy = ""; ///popracuj nad tymi dwoma by miec 3 kolory
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
}
