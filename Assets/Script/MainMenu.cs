using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
        
    }
}
