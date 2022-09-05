using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FullMenu : MonoBehaviour
{

    public AudioSource menuSound;

    public void ExitGame()
    {
        menuSound.Play();
        Application.Quit();
    }

    public void ReloadGame()
    {
        menuSound.Play();
        Info.Instance.restartGame();
        SceneManager.LoadScene(5);
    }

    public void ReloadGame2()
    {
        menuSound.Play();
        Info.Instance.restartGame();
        SceneManager.LoadScene(4);
    }

    public void BackHome()
    {
        menuSound.Play();
        Info.Instance.resetGame();
        SceneManager.LoadScene(0);
    }

}
