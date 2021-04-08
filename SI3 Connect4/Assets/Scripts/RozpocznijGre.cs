using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RozpocznijGre : MonoBehaviour
{
    Rogzrywka gra;
    int ktoryGracz = 2;
    int licznik = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Info.Instance.kolejnosc);
        Debug.Log(Info.Instance.rzad);
        Debug.Log(Info.Instance.czyKoniec);
        Debug.Log(Info.Instance.czy);
        Debug.Log(Info.Instance.poOpadnieciu);
        Debug.Log(Info.Instance.liczbaRuchow);
        Debug.Log(Info.Instance.kolumnaCzlowieka);
        Debug.Log(Info.Instance.nowyRuchCzlowieka);
        Debug.Log(Info.Instance.blad);
        Debug.Log(Info.Instance.wykonywanyRuch);
        Debug.Log(Info.Instance.kolorWrzucanegoZetonu);
        Debug.Log(Info.Instance.tuJuzNie);
        Debug.Log(Info.Instance.zmiana);
        Debug.Log(Info.Instance.pierwszyGracz);
        Debug.Log(Info.Instance.drugiGracz);
        Debug.Log(Info.Instance.kolorPierwszy);
        Debug.Log(Info.Instance.kolorDrugi);
        Debug.Log(Info.Instance.czyCzlowiek1);
        Debug.Log(Info.Instance.czyCzlowiek2);
        gra = new Rogzrywka();
        Info.Instance.poOpadnieciu = true;
        Info.Instance.kolejnosc = Info.Instance.pierwszyGracz;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Info.Instance.czyKoniec && licznik == 0)
        {
            licznik++;
        }
        if (!Info.Instance.czyKoniec && Info.Instance.liczbaRuchow != 42)
        {
            if (Info.Instance.tuJuzNie && Info.Instance.nowyRuchCzlowieka)
            {
                nextMove();
                Info.Instance.tuJuzNie = false;
            }
            else
            {
                if (Info.Instance.nowyRuchCzlowieka && !Info.Instance.wykonywanyRuch)
                {
                    nextMove();
                }
                if (Info.Instance.poOpadnieciu && !Info.Instance.wykonywanyRuch && Info.Instance.zmiana)
                {
                    if (Info.Instance.liczbaRuchow % 2 == 1)
                    {
                        ktoryGracz = 2;
                    }
                    else
                    {
                        ktoryGracz = 1;
                    }
                    Info.Instance.zmiana = false;            
                    if (ktoryGracz == 1 && !Info.Instance.czyCzlowiek1)
                    {
                        play(ktoryGracz);
                    }
                    else if (ktoryGracz == 2 && !Info.Instance.czyCzlowiek2)
                    {
                        play(ktoryGracz);
                    }
                }
            }
        }
    }

    private void nextMove()
    {
        if (ktoryGracz == 1 && Info.Instance.czyCzlowiek1)
        {
            play(ktoryGracz);
        }
        else if (ktoryGracz == 2 && Info.Instance.czyCzlowiek2)
        {
            play(ktoryGracz);
        }
    }

    private void play(int ktoryGracz)
    {
        gra.graj(ktoryGracz);
        Info.Instance.wykonywanyRuch = false;
    }
}
