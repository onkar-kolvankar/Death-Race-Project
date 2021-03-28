using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    GameManager o_gameManager;

    public GameObject o_PanelMainMenu;
    public GameObject o_PanelModTrackSelectionMenu;
    public GameObject o_PanelCarSelectionMenu;

    public RawImage o_RawImageTrackSelected;
    public RawImage o_RawImageModeSelected;
    public RawImage o_RawImageCarSelected;

    // textboxes below rawImage component describing the name of the value selected
    //public GameObject o_TrackSelectedTextbox , o_ModeSelectedTextbox , o_CarSelectedTextbox;

    public Texture[] o_trackImages;

    private int currentTrackTextureIndex = 0;

    

    void Start() {
        o_gameManager = FindObjectOfType<GameManager>();

        Debug.Log("called again");
    }

    // --------------- Main Menu -----------------
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
        o_gameManager.o_totalPlayerCount = 2;

    }

    public void o_LoadOptionsPanel() {
        // Here we load options panel and hide main panel
        Debug.Log("Loading options panel");
    }

    public void o_ExitGame()
    {
        // Here we Exit the game.

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

        if (currentTrackTextureIndex < o_trackImages.Length - 1) {
            o_RawImageTrackSelected.texture = o_trackImages[currentTrackTextureIndex + 1];
            o_TrackSelectedTextbox.text = o_trackImages[currentTrackTextureIndex + 1].name;
            currentTrackTextureIndex ++;
        }
        else
        {
            currentTrackTextureIndex = 0;
            o_RawImageTrackSelected.texture = o_trackImages[currentTrackTextureIndex];
        }
    }

    public void o_ShowPrevTrack()
    {
        if (currentTrackTextureIndex > 0)
        {
            o_RawImageTrackSelected.texture = o_trackImages[currentTrackTextureIndex - 1];
            o_TrackSelectedTextbox.text = o_trackImages[currentTrackTextureIndex - 1].name;
            currentTrackTextureIndex--;
        }
        else
        {
            currentTrackTextureIndex = o_trackImages.Length - 1;
            o_RawImageTrackSelected.texture = o_trackImages[currentTrackTextureIndex];
        }


    }
    // ------------------------ Mode and Track Slection menu END-----------------

    // ------------------------- Car Selection Menu START ------------------------------

    public void o_GoBackToTrackSelection() {


        o_PanelCarSelectionMenu.SetActive(false);
        o_PanelModTrackSelectionMenu.SetActive(true);
    }

    public void o_ShowNextCar()
    {
        Debug.Log("Showing next track");
    }
    public void o_ShowPrevCar()
    {
        Debug.Log("Showing next track");
    }

    public void o_Race() { 
        // set car in the gamemanager.

        // Load the scene corresponding to the selected track in the gamemanager.

    }


    // ------------------------- Car Selection Menu END------------------------------



}
