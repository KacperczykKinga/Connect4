using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FullMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadGame()
    {
        Info.Instance.restartGame();
        SceneManager.LoadScene(5);
    }

    public void ReloadGame2()
    {
        Info.Instance.restartGame();
        SceneManager.LoadScene(4);
    }

    public void BackHome()
    {
        Info.Instance.resetGame();
        SceneManager.LoadScene(0);
    }

}
