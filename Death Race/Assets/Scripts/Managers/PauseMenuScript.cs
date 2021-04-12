using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] string MainMenuScene = "Start Scene";

    [SerializeField] GameObject panelPauseMenu;

    bool isGamePaused = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("In update of PauseMenuScript");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key is pressed. and isGamePaused = " + isGamePaused );
            if (isGamePaused)               // when game is paused 
            {
                panelPauseMenu.SetActive(false);
                Time.timeScale = 1;
                isGamePaused = false;
            }
            else                            // When game is not paused.
            {
                panelPauseMenu.SetActive(true);
                Time.timeScale = 0;
                isGamePaused = true;
            }
        }
    }

    public void GotoMainMenu() {
        panelPauseMenu.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
        SceneManager.LoadScene(MainMenuScene);
        
    }

    public void ResumeGame() {
        panelPauseMenu.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }


}
