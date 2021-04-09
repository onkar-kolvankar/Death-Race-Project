using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuMP : MonoBehaviour
{
    GameManager o_GameManager;

    // Panel ref for Multi player
    public GameObject o_PanelMainMenu;
    public GameObject o_PanelModTrackSelectMP;
    public GameObject o_PanelCarSelectMP1;
    public GameObject o_PanelCarSelectMP2;

    public RawImage o_RawImageTrackSelectedMP;
    public RawImage o_RawImageModeSelectedMP;
    public RawImage o_RawImageCarSelectedMP1;
    public RawImage o_RawImageCarSelectedMP2;

    public Texture[] o_trackImagesMP;
    public Texture[] o_carImagesMP;

    public TMP_Text o_TrackSelectedTextboxMP, o_ModeSelectedTextboxMP, o_CarSelectedTextboxMP1, o_CarSelectedTextboxMP2;


    private int o_currentTrackTextureIndexMP = 0;
    private int o_currentCarTextureIndexMP1 = 0;
    private int o_currentCarTextureIndexMP2 = 0;

    // ------------------------- Menu Multiplayer START ---------------------------

    void Start()
    {
        o_GameManager = FindObjectOfType<GameManager>();

    }
    // --------------1] PanelModeTrackSelectionMP

    public void GotoMainMenuMP()
    {
        o_PanelModTrackSelectMP.SetActive(false);
        o_PanelMainMenu.SetActive(true);
    }

    public void NextTrackMP()
    {
        if (o_currentTrackTextureIndexMP < o_trackImagesMP.Length - 1)
        {
            o_currentTrackTextureIndexMP++;
            o_RawImageTrackSelectedMP.texture = o_trackImagesMP[o_currentTrackTextureIndexMP];
            o_TrackSelectedTextboxMP.text = o_trackImagesMP[o_currentTrackTextureIndexMP].name;
        }
        else
        {
            o_currentTrackTextureIndexMP = 0;
            o_RawImageTrackSelectedMP.texture = o_trackImagesMP[o_currentTrackTextureIndexMP];
            o_TrackSelectedTextboxMP.text = o_trackImagesMP[o_currentTrackTextureIndexMP].name;

        }
    }

    public void PrevTrackMP()
    {
        if (o_currentTrackTextureIndexMP > 0)
        {
            o_currentTrackTextureIndexMP--;
            o_RawImageTrackSelectedMP.texture = o_trackImagesMP[o_currentTrackTextureIndexMP];
            o_TrackSelectedTextboxMP.text = o_trackImagesMP[o_currentTrackTextureIndexMP].name;

        }
        else
        {
            o_currentTrackTextureIndexMP = o_trackImagesMP.Length - 1;
            o_RawImageTrackSelectedMP.texture = o_trackImagesMP[o_currentTrackTextureIndexMP];
            o_TrackSelectedTextboxMP.text = o_trackImagesMP[o_currentTrackTextureIndexMP].name;

        }

    }
    public void GotoNextCarSelectionMP1()
    {
        // Save the track and mode selected in the GameManager.
        o_GameManager.o_trackSelected = o_RawImageTrackSelectedMP.texture.name;
        o_PanelModTrackSelectMP.SetActive(false);
        o_PanelCarSelectMP1.SetActive(true);

    }

    // ---------2] Car selection MP 1-----------
    public void GotoModeTrackSelectionMP()
    {
        o_PanelCarSelectMP1.SetActive(false);
        o_PanelModTrackSelectMP.SetActive(true);
    }

    public void NextCarMP1()
    {
        if (o_currentCarTextureIndexMP1 < o_carImagesMP.Length - 1)
        {
            o_currentCarTextureIndexMP1++;
            o_RawImageCarSelectedMP1.texture = o_carImagesMP[o_currentCarTextureIndexMP1];
            o_CarSelectedTextboxMP1.text = o_carImagesMP[o_currentCarTextureIndexMP1].name;
        }
        else
        {
            o_currentCarTextureIndexMP1 = 0;
            o_RawImageCarSelectedMP1.texture = o_carImagesMP[o_currentCarTextureIndexMP1];
            o_CarSelectedTextboxMP1.text = o_carImagesMP[o_currentCarTextureIndexMP1].name;
        }
    }

    public void PrevCarMP1()
    {
        if (o_currentCarTextureIndexMP1 > 0)
        {
            o_currentCarTextureIndexMP1--;
            o_RawImageCarSelectedMP1.texture = o_carImagesMP[o_currentCarTextureIndexMP1];
            o_CarSelectedTextboxMP1.text = o_carImagesMP[o_currentCarTextureIndexMP1].name;
        }
        else
        {
            o_currentCarTextureIndexMP1 = o_carImagesMP.Length -1 ;
            o_RawImageCarSelectedMP1.texture = o_carImagesMP[o_currentCarTextureIndexMP1];
            o_CarSelectedTextboxMP1.text = o_carImagesMP[o_currentCarTextureIndexMP1].name;
        }

    }
    public void GotoCarSelectionMP2()
    {
        // Save the track and mode selected in the GameManager.
        o_GameManager.o_carsSelectedMP[0] = o_RawImageCarSelectedMP1.texture.name;

        o_PanelCarSelectMP1.SetActive(false);
        o_PanelCarSelectMP2.SetActive(true);

    }

    // ---------2] Car selection MP 2-----------
    public void GotoCarSelectionMP1()
    {
        o_PanelCarSelectMP2.SetActive(false);
        o_PanelCarSelectMP1.SetActive(true);
    }

    public void NextCarMP2()
    {
        if (o_currentCarTextureIndexMP2 < o_carImagesMP.Length - 1)
        {
            o_currentCarTextureIndexMP2++;
            o_RawImageCarSelectedMP2.texture = o_carImagesMP[o_currentCarTextureIndexMP2];
            o_CarSelectedTextboxMP2.text = o_carImagesMP[o_currentCarTextureIndexMP2].name;
        }
        else
        {
            o_currentCarTextureIndexMP2 = 0;
            o_RawImageCarSelectedMP2.texture = o_carImagesMP[o_currentCarTextureIndexMP2];
            o_CarSelectedTextboxMP2.text = o_carImagesMP[o_currentCarTextureIndexMP2].name;

        }
    }

    public void PrevCarMP2()
    {
        if (o_currentCarTextureIndexMP2 > 0)
        {
            o_currentCarTextureIndexMP2--;
            o_RawImageCarSelectedMP2.texture = o_carImagesMP[o_currentCarTextureIndexMP2];
            o_CarSelectedTextboxMP2.text = o_carImagesMP[o_currentCarTextureIndexMP2].name;

        }
        else
        {
            o_currentCarTextureIndexMP2 = o_carImagesMP.Length - 1;
            o_RawImageCarSelectedMP2.texture = o_carImagesMP[o_currentCarTextureIndexMP2];
            o_CarSelectedTextboxMP2.text = o_carImagesMP[o_currentCarTextureIndexMP2].name;

        }

    }
    public void StartRaceMP()
    {
        // Save the track and mode selected in the GameManager.
        o_GameManager.o_carsSelectedMP[1] = o_RawImageCarSelectedMP2.texture.name;

        string track_selected = o_GameManager.o_trackSelected;
        SceneManager.LoadScene(track_selected);
    }

}
