using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayervsPlayerMenu : MonoBehaviour
{
    public GameObject start;
    public GameObject cFYellow, cFRed, cFGreen;
    public GameObject cSYellow, cSRed, cSGreen;
    public GameObject lFYellow, lFRed, lFGreen;
    public GameObject lSYellow, lSRed, lSGreen;
    bool rFYellow, rFRed, rFGreen;
    bool rSYellow, rSRed, rSGreen;
    Info info;

    void Start()
    {
        start.SetActive(false);
        info = Info.Instance;
        rFYellow = false;
        rFRed = false;
        rFGreen = false;
        rSYellow = false;
        rSRed = false;
        rSGreen = false;
    }


    void Update()
    {
        if (rFYellow)
        {
            RectTransform rectTransformY = cFYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0.5f));
            RectTransform rectTransformR = cFRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformG = cFGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0));
        }
        else if (rFRed)
        {
            RectTransform rectTransformY = cFYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformR = cFRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0.5f));
            RectTransform rectTransformG = cFGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0));
        }
        else if (rFGreen)
        {
            RectTransform rectTransformY = cFYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformR = cFRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformG = cFGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0.5f));
        }

        if (rSYellow)
        {
            RectTransform rectTransformY = cSYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0.5f));
            RectTransform rectTransformR = cSRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformG = cSGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0));
        }
        else if (rSRed)
        {
            RectTransform rectTransformY = cSYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformR = cSRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0.5f));
            RectTransform rectTransformG = cSGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0));
        }
        else if (rSGreen)
        {
            RectTransform rectTransformY = cSYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformR = cSRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformG = cSGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0.5f));
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene(0);
    }

    public void startPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void firstYellow()
    {
        info.kolorPierwszy = "Y";
        secondAllTrue();
        cFYellow.GetComponent<Image>().color = Color.white;
        cFRed.GetComponent<Image>().color = Color.gray;
        cFGreen.GetComponent<Image>().color = Color.gray;
        cSYellow.SetActive(false);
        lSYellow.SetActive(false);
        rFYellow = true;
        rFRed = false;
        rFGreen = false;
        if (info.kolorPierwszy != "" && info.kolorDrugi != "") start.SetActive(true);
    }

    public void firstRed()
    {
        info.kolorPierwszy = "R";
        secondAllTrue();
        cFYellow.GetComponent<Image>().color = Color.gray;
        cFRed.GetComponent<Image>().color = Color.white;
        cFGreen.GetComponent<Image>().color = Color.gray;
        cSRed.SetActive(false);
        lSRed.SetActive(false);
        rFYellow = false;
        rFRed = true;
        rFGreen = false;
        if (info.kolorPierwszy != "" && info.kolorDrugi != "") start.SetActive(true);
    }

    public void firstGreen()
    {
        info.kolorPierwszy = "G";
        secondAllTrue();
        cFYellow.GetComponent<Image>().color = Color.gray;
        cFRed.GetComponent<Image>().color = Color.gray;
        cFGreen.GetComponent<Image>().color = Color.white;
        cSGreen.SetActive(false);
        lSGreen.SetActive(false);
        rFYellow = false;
        rFRed = false;
        rFGreen = true;
        if (info.kolorPierwszy != "" && info.kolorDrugi != "") start.SetActive(true);
    }

    public void secondYellow()
    {
        info.kolorDrugi = "Y";
        firstAllTrue();
        cSYellow.GetComponent<Image>().color = Color.white;
        cSRed.GetComponent<Image>().color = Color.gray;
        cSGreen.GetComponent<Image>().color = Color.gray;
        cFYellow.SetActive(false);
        lFYellow.SetActive(false);
        rSYellow = true;
        rSRed = false;
        rSGreen = false;
        if (info.kolorPierwszy != "" && info.kolorDrugi != "") start.SetActive(true);
    }

    public void secondRed()
    {
        info.kolorDrugi = "R";
        firstAllTrue();
        cSYellow.GetComponent<Image>().color = Color.gray;
        cSRed.GetComponent<Image>().color = Color.white;
        cSGreen.GetComponent<Image>().color = Color.gray;
        cFRed.SetActive(false);
        lFRed.SetActive(false);
        rSYellow = false;
        rSRed = true;
        rSGreen = false;
        if (info.kolorPierwszy != "" && info.kolorDrugi != "") start.SetActive(true);
    }

    public void secondGreen()
    {
        info.kolorDrugi = "G";
        firstAllTrue();
        cSYellow.GetComponent<Image>().color = Color.gray;
        cSRed.GetComponent<Image>().color = Color.gray;
        cSGreen.GetComponent<Image>().color = Color.white;
        cFGreen.SetActive(false);
        lFGreen.SetActive(false);
        rSYellow = false;
        rSRed = false;
        rSGreen = true;
        if (info.kolorPierwszy != "" && info.kolorDrugi != "") start.SetActive(true);
    }

    public void firstAllTrue()
    {
        cFYellow.SetActive(true);
        cFRed.SetActive(true);
        cFGreen.SetActive(true);
        lFYellow.SetActive(true);
        lFRed.SetActive(true);
        lFGreen.SetActive(true);
    }

    public void secondAllTrue()
    {
        cSYellow.SetActive(true);
        cSRed.SetActive(true);
        cSGreen.SetActive(true);
        lSYellow.SetActive(true);
        lSRed.SetActive(true);
        lSGreen.SetActive(true);
    }

}
