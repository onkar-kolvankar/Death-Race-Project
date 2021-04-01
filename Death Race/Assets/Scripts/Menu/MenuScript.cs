using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    GameManager o_gameManager;

    // Panel ref for Single player 
    public GameObject o_PanelMainMenu;
    public GameObject o_PanelModTrackSelectionMenu;
    public GameObject o_PanelModTrackSelectMP;
    public GameObject o_PanelCarSelectionMenu;
    public GameObject o_PanelLeaderboardMenu;

    public RawImage o_RawImageTrackSelected;
    public RawImage o_RawImageModeSelected;
    public RawImage o_RawImageCarSelected;

    // textboxes below rawImage component describing the name of the value selected
    // NOT WORKING
    public TextMeshPro o_TrackSelectedTextbox , o_ModeSelectedTextbox , o_CarSelectedTextbox;

    public Texture[] o_trackImages;
    public Texture[] o_carImages;

    private int o_currentTrackTextureIndex = 0;
    private int o_currentCarTextureIndex = 0;

    void Start() {
        o_gameManager = FindObjectOfType<GameManager>();

    }

    // --------------- Main Menu SINGLE PLAYER-----------------
    public void o_SetSinglePlayerGotoTrackSelection()
    {
        o_gameManager.o_gameMode = "Singleplayer";
        o_gameManager.o_totalPlayerCount = 1;

        // Turn off Main menu panel and enable track and mode selection panel.
        o_PanelMainMenu.SetActive(false);
        o_PanelModTrackSelectionMenu.SetActive(true);
    }

    public void o_SetMultiPlayerGotoTrackSelection() {
        o_gameManager.o_gameMode = "Multiplayer";
        o_gameManager.o_totalPlayerCount = 2;       // Taking 2 players by DEFAULT
        o_gameManager.o_carsSelectedMP = new string[o_gameManager.o_totalPlayerCount]; // Initializing the cars array to DEFAULT

        // Turn off Main menu panel and enable track and mode selection panel for MP.
        o_PanelMainMenu.SetActive(false);
        o_PanelModTrackSelectMP.SetActive(true);

    }

    public void o_ShowLearderboard() {
        o_PanelMainMenu.SetActive(false);
        o_PanelLeaderboardMenu.SetActive(true);


    }

    public void o_LoadOptionsPanel() {
        // Here we load options panel and hide main panel
        Debug.Log("Loading options panel");
    }


    public void o_ExitGame()
    {
        // Here we Exit the game.
        Application.Quit();
    }

    // -------------------------Main menu over END------------------------------

    // ------------------------ Mode and Track Slection menu START-----------------
    public void o_GotoMainMenu()
    {

        o_PanelModTrackSelectionMenu.SetActive(false);
        o_PanelMainMenu.SetActive(true);
        
    }

    public void o_GotoCarSelectionMenu()
    {
        // save the current mode and track in gamemanagerObj
        // It stores the name of the texture assigned to the rawImage.
        o_gameManager.o_trackSelected = o_RawImageTrackSelected.texture.name;
        // KEEP THE NAME OF SCENE AND TRACK IMAGE SAME.

        o_PanelModTrackSelectionMenu.SetActive(false);
        o_PanelCarSelectionMenu.SetActive(true);
    }

    public void o_ShowNextTrack()
    {

        if (o_currentTrackTextureIndex < o_trackImages.Length - 1) {
            o_RawImageTrackSelected.texture = o_trackImages[o_currentTrackTextureIndex + 1];
           // o_TrackSelectedTextbox.Text = o_trackImages[o_currentTrackTextureIndex + 1].name;
            o_currentTrackTextureIndex ++;
        }
        else
        {
            o_currentTrackTextureIndex = 0;
            o_RawImageTrackSelected.texture = o_trackImages[o_currentTrackTextureIndex];
        }
    }

    public void o_ShowPrevTrack()
    {
        if (o_currentTrackTextureIndex > 0)
        {
            o_RawImageTrackSelected.texture = o_trackImages[o_currentTrackTextureIndex - 1];
           // o_TrackSelectedTextbox.text = o_trackImages[o_currentTrackTextureIndex - 1].name;
            o_currentTrackTextureIndex--;
        }
        else
        {
            o_currentTrackTextureIndex = o_trackImages.Length - 1;
            o_RawImageTrackSelected.texture = o_trackImages[o_currentTrackTextureIndex];
        }


    }
    // ------------------------ Mode and Track Slection menu END-----------------

    // ------------------------- Car Selection Menu START ------------------------------

    public void o_GotoTrackSelection() {


        o_PanelCarSelectionMenu.SetActive(false);
        o_PanelModTrackSelectionMenu.SetActive(true);
    }

    public void o_ShowNextCar()
    {
        if (o_currentCarTextureIndex < o_carImages.Length - 1)
        {
            o_RawImageCarSelected.texture = o_carImages[o_currentCarTextureIndex + 1];
            o_currentCarTextureIndex++;
        }
        else
        {
            o_currentCarTextureIndex = 0;
            o_RawImageCarSelected.texture = o_carImages[o_currentCarTextureIndex];
        }
    }
    public void o_ShowPrevCar()
    {
        if (o_currentCarTextureIndex > 0)
        {
            o_RawImageCarSelected.texture = o_carImages[o_currentCarTextureIndex - 1];
            o_currentCarTextureIndex--;
        }
        else
        {
            o_currentCarTextureIndex = o_carImages.Length - 1;
            o_RawImageCarSelected.texture = o_carImages[o_currentCarTextureIndex];
        }
    }

    public void o_StartRace() {
        // set car in the gamemanager.
        o_gameManager.o_carSelected = o_RawImageCarSelected.texture.name;

        // check which scene needs to be loaded.


        // Load the scene corresponding to the selected track in the gamemanager.
        o_DecideSceneToLoad();
    }

    private void o_DecideSceneToLoad() {
        string track_selected = o_gameManager.o_trackSelected;


        SceneManager.LoadScene(track_selected);


    }


    // ------------------------- Car Selection Menu END------------------------------

    // -------------------------- LEADERBOARD PANEL ---------------------------------

    public void o_GotoMainMenuFromLeaderboard() {
        o_PanelLeaderboardMenu.SetActive(false);
        o_PanelMainMenu.SetActive(true);
    }

    // -----------------------------LEADERBOARD CODE ENDS HERE ---------------------


}
