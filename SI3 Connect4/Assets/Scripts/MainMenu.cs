using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Info info;
    public GameObject orange;
    public AudioSource clickButton;

    // Start is called before the first frame update
    void Start()
    {
       info = Info.Instance;
    }

    private void Update()
    {
        RectTransform rectTransform = orange.GetComponent<RectTransform>();
        rectTransform.Rotate(new Vector3(0, 0, 0.5f));
    }
    
    public void credits()
    {
        clickButton.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CzlowiekvsCzlowiek()
    {
        clickButton.Play();
        info.pierwszyGracz = "CZLOWIEK";
        info.drugiGracz = "CZLOWIEK";
        info.czyCzlowiek1 = true;
        info.czyCzlowiek2 = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void CzlowiekvsMaszyna()
    {
        clickButton.Play();
        info.pierwszyGracz = "CZLOWIEK";
        info.drugiGracz = "MASZYNA";
        info.czyCzlowiek1 = true;
        info.czyCzlowiek2 = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
