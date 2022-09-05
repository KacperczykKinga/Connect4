using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onePlayerWybrane : MonoBehaviour
{
    public GameObject start;
    public GameObject cYellow, cRed, cGreen;
    public AudioSource fruitSound;
    bool rYellow, rRed, rGreen;
    Info info;

    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(false);
        info = Info.Instance;
        rYellow = false;
        rRed = false;
        rGreen = false;
    }

    void Update()
    {
        if(rYellow)
        {
            RectTransform rectTransformY = cYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0.5f));
            RectTransform rectTransformR = cRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformG = cGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0));
        }
        else if(rRed)
        {
            RectTransform rectTransformY = cYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformR = cRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0.5f));
            RectTransform rectTransformG = cGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0));
        }
        else if(rGreen)
        {
            RectTransform rectTransformY = cYellow.GetComponent<RectTransform>();
            rectTransformY.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformR = cRed.GetComponent<RectTransform>();
            rectTransformR.Rotate(new Vector3(0, 0, 0));
            RectTransform rectTransformG = cGreen.GetComponent<RectTransform>();
            rectTransformG.Rotate(new Vector3(0, 0, 0.5f));
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene(0);
    }

    public void startPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void firstYellow()
    {
        info.kolorPierwszy = "Y";
        cYellow.GetComponent<Image>().color = Color.white;
        cRed.GetComponent<Image>().color = Color.gray;
        cGreen.GetComponent<Image>().color = Color.gray;
        rYellow = true;
        rRed = false;
        rGreen = false;
        secondColor("Y");
        fruitSound.Play();
    }

    public void firstRed()
    {
        info.kolorPierwszy = "R";
        cYellow.GetComponent<Image>().color = Color.gray;
        cRed.GetComponent<Image>().color = Color.white;
        cGreen.GetComponent<Image>().color = Color.gray;
        rYellow = false;
        rRed = true;
        rGreen = false;
        secondColor("R");
        fruitSound.Play();
    }

    public void firstGreen()
    {
        info.kolorPierwszy = "G";
        cYellow.GetComponent<Image>().color = Color.gray;
        cRed.GetComponent<Image>().color = Color.gray;
        cGreen.GetComponent<Image>().color = Color.white;
        rYellow = false;
        rRed = false;
        rGreen = true;
        secondColor("G");
        fruitSound.Play();
    }

    public void secondColor(string kolor)
    {

        List<string> dostepneKoloryKompa = new List<string> { "Y", "R", "G" };
        dostepneKoloryKompa.Remove(kolor);
        start.SetActive(true);
        int wylosowany = Random.Range(1, 2);
        info.kolorDrugi = dostepneKoloryKompa[wylosowany];
    }
}
