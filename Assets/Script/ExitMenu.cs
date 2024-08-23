using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    

    public void ShowCursor()
    {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
    }


   private void Start()
    {
    ShowCursor();
    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }


    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
