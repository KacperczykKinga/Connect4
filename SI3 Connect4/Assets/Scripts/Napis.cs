using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Napis : MonoBehaviour
{
    public GameObject secondPlayer, fPCOn, fPCOut, sPCOn, sPCOut, tloKonca, wygrana, tuNie;
    public GameObject centerMenu, sideMenu;
    public Sprite machine, red, green;

    // Start is called before the first frame update
    void Start()
    {
        tloKonca.SetActive(false);
        centerMenu.SetActive(false);
        sideMenu.SetActive(true);
        if (Info.Instance.drugiGracz == "MASZYNA")
        {
            secondPlayer.GetComponent<SpriteRenderer>().sprite = machine;
        }
        if (Info.Instance.kolorPierwszy.Equals("R"))
        {
            fPCOn.GetComponent<SpriteRenderer>().sprite = red;
            fPCOut.GetComponent<SpriteRenderer>().sprite = red;
        }
        else if (Info.Instance.kolorPierwszy.Equals("G"))
        {
            fPCOn.GetComponent<SpriteRenderer>().sprite = green;
            fPCOut.GetComponent<SpriteRenderer>().sprite = green;
        }

        if (Info.Instance.kolorDrugi.Equals("R"))
        {
            sPCOn.GetComponent<SpriteRenderer>().sprite = red;
            sPCOut.GetComponent<SpriteRenderer>().sprite = red;
        }
        else if (Info.Instance.kolorDrugi.Equals("G"))
        {
            sPCOn.GetComponent<SpriteRenderer>().sprite = green;
            sPCOut.GetComponent<SpriteRenderer>().sprite = green;
        }
        wygrana.SetActive(false);
        tuNie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Info.Instance.kolejnosc.ToString() == "CZLOWIEK 1" || Info.Instance.kolejnosc.ToString() == "CZLOWIEK")
        {
            fPCOn.SetActive(true);
            sPCOn.SetActive(false);
        }
        else
        {
            sPCOn.SetActive(true);
            fPCOn.SetActive(false);
        }

        if (Info.Instance.czyKoniec)
        {
            tloKonca.SetActive(true);
            wygrana.SetActive(true);
            string wygrany = Info.Instance.kolejnosc;
            if (Info.Instance.kolorWrzucanegoZetonu.Equals("Z"))
            {
                wygrany = Info.Instance.drugiGracz;
            }
            else
            {
                wygrany = Info.Instance.pierwszyGracz;
            }
            if (wygrany == "CZLOWIEK") wygrany = "Player";
            else if (wygrany == "CZLOWIEK 1") wygrany = "Player 1";
            else if (wygrany == "CZLOWIEK 2") wygrany = "Player 2";
            else if (wygrany == "MASZYNA") wygrany = "Computer";
            wygrana.GetComponent<UnityEngine.UI.Text>().text = wygrany + " won";
            centerMenu.SetActive(true);
            sideMenu.SetActive(false);

        }
        else if(Info.Instance.liczbaRuchow == 42)
        {
            wygrana.SetActive(true);
            wygrana.GetComponent<UnityEngine.UI.Text>().text = "Remis";
            centerMenu.SetActive(true);
            sideMenu.SetActive(false);
        }
        else if(Info.Instance.tuJuzNie)
        {
            tuNie.SetActive(true);
        }
        else if(!Info.Instance.tuJuzNie)
        {
            tuNie.SetActive(false);
        }


    }

}
