using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpreadMenu : MonoBehaviour
{
    private bool menu, clicked;
    public GameObject menuButton, reload, home, end;
    public Sprite menuIn, menuOut;
    public AudioSource menuSound;
    private int reloadNumber, homeNumber, endNumber;

    void Start()
    {
        menu = false;
        clicked = false;
        reloadNumber = 50;
        homeNumber = 100;
        endNumber = 150;
        reload.SetActive(false);
        home.SetActive(false);
        end.SetActive(false);
    }

    private void Update()
    {
        if(clicked && menu)
        {
            if (reloadNumber > 0)
            {
                Transform transform = reload.GetComponent<Transform>();
                transform.Translate(new Vector3(0, 1f, 0));
                reloadNumber--;
            }
            if (homeNumber > 0)
            {
                Transform transform = home.GetComponent<Transform>();
                transform.Translate(new Vector3(0, 1f, 0));
                homeNumber--;
            }
            if (endNumber > 0)
            {
                Transform transform = end.GetComponent<Transform>();
                transform.Translate(new Vector3(0, 1f, 0));
                endNumber--;
            }
            if (reloadNumber < 35)
            {
                reload.SetActive(true);
                home.SetActive(true);
                end.SetActive(true);
            }
        }
      
        else if(clicked && !menu)
        {
          
            if (reloadNumber < 50)
            {
                Transform transform = reload.GetComponent<Transform>();
                transform.Translate(new Vector3(0, -1f, 0));
                reloadNumber++;
            }
            if (homeNumber < 100)
            {
                Transform transform = home.GetComponent<Transform>();
                transform.Translate(new Vector3(0, -1f, 0));
                homeNumber++;
            }
            if (endNumber < 150)
            {
                Transform transform = end.GetComponent<Transform>();
                transform.Translate(new Vector3(0, -1f, 0));
                endNumber++;
            }
            if(reloadNumber > 30)
            {
                reload.SetActive(false);
            }
            if(homeNumber > 80)
            {
                home.SetActive(false);
            }
            if(endNumber > 130)
            {
                end.SetActive(false);
            }
        }
    }

    public void clickOnMenuButton()
    {
        menuSound.Play();
        if(!menu)
        {
            clicked = true;
            menu = true;
            menuButton.GetComponent<Image>().sprite = menuIn;       
        }
        else
        {
            menu = false;
            clicked = true;
            menuButton.GetComponent<Image>().sprite = menuOut;
        }
    }

}
