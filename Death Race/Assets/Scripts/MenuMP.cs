﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMP : MonoBehaviour
{
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

    private int o_currentTrackTextureIndexMP = 0;
    private int o_currentCarTextureIndexMP1 = 0;
    private int o_currentCarTextureIndexMP2 = 0;

    // ------------------------- Menu Multiplayer START ---------------------------


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
            o_RawImageTrackSelectedMP.texture = o_trackImagesMP[o_currentTrackTextureIndexMP + 1];
            o_currentTrackTextureIndexMP++;
        }
        else
        {
            o_currentTrackTextureIndexMP = 0;
            o_RawImageTrackSelectedMP.texture = o_trackImagesMP[o_currentTrackTextureIndexMP];
        }
    }

    public void PrevTrackMP()
    {
        if (o_currentTrackTextureIndexMP > 0)
        {
            o_RawImageTrackSelectedMP.texture = o_trackImagesMP[o_currentTrackTextureIndexMP - 1];
            // o_TrackSelectedTextbox.text = o_trackImages[o_currentTrackTextureIndex - 1].name;
            o_currentTrackTextureIndexMP--;
        }
        else
        {
            o_currentTrackTextureIndexMP = o_trackImagesMP.Length - 1;
            o_RawImageTrackSelectedMP.texture = o_trackImagesMP[o_currentTrackTextureIndexMP];
        }

    }
    public void GotoNextCarSelectionMP1()
    {
        // Save the track and mode selected in the GameManager.

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
            o_RawImageCarSelectedMP1.texture = o_carImagesMP[o_currentCarTextureIndexMP1 + 1];
            o_currentCarTextureIndexMP1++;
        }
        else
        {
            o_currentCarTextureIndexMP1 = 0;
            o_RawImageCarSelectedMP1.texture = o_carImagesMP[o_currentCarTextureIndexMP1];
        }
    }

    public void PrevCarMP1()
    {
        if (o_currentCarTextureIndexMP1 > 0)
        {
            o_RawImageCarSelectedMP1.texture = o_carImagesMP[o_currentCarTextureIndexMP1 - 1];
            o_currentCarTextureIndexMP1--;
        }
        else
        {
            o_currentCarTextureIndexMP1 = o_carImagesMP.Length -1 ;
            o_RawImageCarSelectedMP1.texture = o_carImagesMP[o_currentCarTextureIndexMP1];
        }

    }
    public void GotoCarSelectionMP2()
    {
        // Save the track and mode selected in the GameManager.

        o_PanelCarSelectMP1.SetActive(false);
        o_PanelCarSelectMP2.SetActive(true);

    }

    // ---------2] Car selection MP 1-----------
    public void GotoCarSelectionMP1()
    {
        o_PanelCarSelectMP2.SetActive(false);
        o_PanelCarSelectMP1.SetActive(true);
    }

    public void NextCarMP2()
    {
        if (o_currentCarTextureIndexMP2 < o_carImagesMP.Length - 1)
        {
            o_RawImageCarSelectedMP2.texture = o_carImagesMP[o_currentCarTextureIndexMP2 + 1];
            o_currentCarTextureIndexMP2++;
        }
        else
        {
            o_currentCarTextureIndexMP2 = 0;
            o_RawImageCarSelectedMP2.texture = o_carImagesMP[o_currentCarTextureIndexMP2];
        }
    }

    public void PrevCarMP2()
    {
        if (o_currentCarTextureIndexMP2 > 0)
        {
            o_RawImageCarSelectedMP2.texture = o_carImagesMP[o_currentCarTextureIndexMP2 - 1];
            o_currentCarTextureIndexMP2--;
        }
        else
        {
            o_currentCarTextureIndexMP2 = o_carImagesMP.Length - 1;
            o_RawImageCarSelectedMP2.texture = o_carImagesMP[o_currentCarTextureIndexMP2];
        }

    }
    public void StartRaceMP()
    {
        // Save the track and mode selected in the GameManager.

        

    }

}