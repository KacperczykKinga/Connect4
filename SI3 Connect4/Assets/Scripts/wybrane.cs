using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wybrane : MonoBehaviour
{
    public GameObject firstP, firstC;
    public GameObject secondP, secondC;
    public GameObject firstY, firstR, firstG;
    public GameObject secondY, secondR, secondG;

    // Start is called before the first frame update
    void Start()
    {
        if(Info.Instance.czyCzlowiek1)
        {
            firstP.SetActive(true);
            firstC.SetActive(false);
        }
        else if(!Info.Instance.czyCzlowiek1)
        {
            firstP.SetActive(false);
            firstC.SetActive(true);
        }

        if (Info.Instance.czyCzlowiek2)
        {
            secondP.SetActive(true);
            secondC.SetActive(false);
        }
        else if (!Info.Instance.czyCzlowiek2)
        {
            secondP.SetActive(false);
            secondC.SetActive(true);
        }

        if (Info.Instance.kolorPierwszy.Equals("Y"))
        {
            firstY.SetActive(true);
            firstR.SetActive(false);
            firstG.SetActive(false);
        }
        else if (Info.Instance.kolorPierwszy.Equals("R"))
        {
            firstY.SetActive(false);
            firstR.SetActive(true);
            firstG.SetActive(false);
        }
        else if (Info.Instance.kolorPierwszy.Equals("G"))
        {
            firstY.SetActive(false);
            firstR.SetActive(false);
            firstG.SetActive(true);
        }

        if (Info.Instance.kolorDrugi.Equals("Y"))
        {
            secondY.SetActive(true);
            secondR.SetActive(false);
            secondG.SetActive(false);
        }
        else if (Info.Instance.kolorDrugi.Equals("R"))
        {
            secondY.SetActive(false);
            secondR.SetActive(true);
            secondG.SetActive(false);
        }
        else if (Info.Instance.kolorDrugi.Equals("G"))
        {
            secondY.SetActive(false);
            secondR.SetActive(false);
            secondG.SetActive(true);
        }
    }

    public void startGame()
    {
        Debug.Log("AAAAAAAAAAAa");
        Debug.Log(Info.Instance.pierwszyGracz);
        Debug.Log(Info.Instance.drugiGracz);
        Debug.Log(Info.Instance.kolorPierwszy);
        Debug.Log(Info.Instance.kolorDrugi);
        Debug.Log(Info.Instance.liczbaRuchow);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backToHome()
    {
        SceneManager.LoadScene(0);
    }

}
