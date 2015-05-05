using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    public string levelname;
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Application.LoadLevel(levelname);
    }

    public void Tutorial()
    {
        Application.LoadLevel("Tutorial 1");
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void NextLevel()
    {
        Application.LoadLevel(levelname);
    }
}
