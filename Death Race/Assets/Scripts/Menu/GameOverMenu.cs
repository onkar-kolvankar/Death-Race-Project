using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public void GotoMainMenu() {
        SceneManager.LoadScene("Start Scene");
    }

    public void QuitGame() {
        Application.Quit();
    }

}
