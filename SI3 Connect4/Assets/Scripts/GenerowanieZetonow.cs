using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerowanieZetonow : MonoBehaviour
{
    public GameObject jedenZoltyZeton;
    public GameObject jedenCzerwonyZeton;
    public GameObject jedenZielonyZeton;
    float y = 6;
    float krok = 1.52f;
    float start = -4.58f;

    public void Update()
    {
        //generujZolty(0);
        if(Info.Instance.czy)
        {
            if(Info.Instance.kolorWrzucanegoZetonu.Equals("C") && Info.Instance.kolorPierwszy.Equals("R"))
            {
                generujCzerwony(Info.Instance.rzad);
            }
            else if(Info.Instance.kolorWrzucanegoZetonu.Equals("C") && Info.Instance.kolorPierwszy.Equals("Y"))
            {
                generujZolty(Info.Instance.rzad);
            }
            else if (Info.Instance.kolorWrzucanegoZetonu.Equals("C") && Info.Instance.kolorPierwszy.Equals("G"))
            {
                generujZielony(Info.Instance.rzad);
            }
            else if (Info.Instance.kolorWrzucanegoZetonu.Equals("Z") && Info.Instance.kolorDrugi.Equals("R"))
            {
                generujCzerwony(Info.Instance.rzad);
            }
            else if (Info.Instance.kolorWrzucanegoZetonu.Equals("Z") && Info.Instance.kolorDrugi.Equals("Y"))
            {
                generujZolty(Info.Instance.rzad);
            }
            else if (Info.Instance.kolorWrzucanegoZetonu.Equals("Z") && Info.Instance.kolorDrugi.Equals("G"))
            {
                generujZielony(Info.Instance.rzad);
            }
            Info.Instance.czy = false;
        }
    }

    public void generujZolty(int x)
    {
        GameObject zoltyZeton = Instantiate(jedenZoltyZeton);
        zoltyZeton.transform.position = new Vector3(start + x * krok, y, -8);
    }

    public void generujCzerwony(int x)
    {
        GameObject czerwonyZeton = Instantiate(jedenCzerwonyZeton);
        czerwonyZeton.transform.position = new Vector3(start + x * krok, y, -8);
    }

    public void generujZielony(int x)
    {
        GameObject zielonyZeton = Instantiate(jedenZielonyZeton);
        zielonyZeton.transform.position = new Vector3(start + x * krok, y, -8);
    }
}
