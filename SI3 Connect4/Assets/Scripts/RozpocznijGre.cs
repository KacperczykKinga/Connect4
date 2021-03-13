using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RozpocznijGre : MonoBehaviour
{
    Rogzrywka gra;
    int ktoryGracz = 2;
    int trzymacz = 1000000000;
    int licznik = 0;

    // Start is called before the first frame update
    void Start()
    {
        gra = new Rogzrywka();
        // Info.Instance.rzad = 1;
        //Info.Instance.czy = true;
        // gra.graj(ktoryGracz);
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
        if (Info.Instance.tuJuzNie && Info.Instance.nowyRuchCzlowieka && !Info.Instance.czyKoniec && Info.Instance.liczbaRuchow != 42)
        {
            if (ktoryGracz == 1 && Info.Instance.czyCzlowiek1)
            {
                gra.graj(ktoryGracz);
                //Info.Instance.wykonywanyRuch = false;
                //StartCoroutine(czekaj(0));
               // Debug.Log(ktoryGracz);
                Info.Instance.wykonywanyRuch = false;
            }
            else if (ktoryGracz == 2 && Info.Instance.czyCzlowiek2)
            {
                gra.graj(ktoryGracz);
                //Info.Instance.wykonywanyRuch = false;
                // StartCoroutine(czekaj(0));
               // Debug.Log(ktoryGracz);
                Info.Instance.wykonywanyRuch = false;
            }
            Info.Instance.tuJuzNie = false;
        }
        else
        {
            if (Info.Instance.nowyRuchCzlowieka && !Info.Instance.czyKoniec && Info.Instance.liczbaRuchow != 42 && !Info.Instance.wykonywanyRuch)
            {

                if (ktoryGracz == 1 && Info.Instance.czyCzlowiek1)
                {
                    gra.graj(ktoryGracz);
                   // Debug.Log(ktoryGracz);
                    Info.Instance.wykonywanyRuch = false;
                }
                else if (ktoryGracz == 2 && Info.Instance.czyCzlowiek2)
                {
                    gra.graj(ktoryGracz);
                  //  Debug.Log(ktoryGracz);
                    Info.Instance.wykonywanyRuch = false;
                }
            }
            if (Info.Instance.poOpadnieciu && !Info.Instance.czyKoniec && Info.Instance.liczbaRuchow != 42 && !Info.Instance.wykonywanyRuch && Info.Instance.zmiana)
            {
                Debug.Log("zmiana gracza");
                if (Info.Instance.liczbaRuchow % 2 == 1)
                {
                    ktoryGracz = 2;
                }
                else
                {
                    ktoryGracz = 1;
                }
                Debug.Log(ktoryGracz);
                Info.Instance.zmiana = false;
            //    Debug.Log(Info.Instance.liczbaRuchow);     
                if (ktoryGracz == 1 && !Info.Instance.czyCzlowiek1)
                {
                    gra.graj(ktoryGracz);
                  //  Debug.Log(ktoryGracz);
                    Info.Instance.wykonywanyRuch = false;
                }
                else if (ktoryGracz == 2 && !Info.Instance.czyCzlowiek2)
                {
                    gra.graj(ktoryGracz);
                   // Debug.Log(ktoryGracz);
                    Info.Instance.wykonywanyRuch = false;
                }
            }
        }
    }
}
