using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Info info;
    public GameObject orange;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CzlowiekvsCzlowiek()
    {
        info.pierwszyGracz = "CZLOWIEK";
        info.drugiGracz = "CZLOWIEK";
        info.czyCzlowiek1 = true;
        info.czyCzlowiek2 = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void CzlowiekvsMaszyna()
    {
        info.pierwszyGracz = "CZLOWIEK";
        info.drugiGracz = "MASZYNA";
        info.czyCzlowiek1 = true;
        info.czyCzlowiek2 = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
