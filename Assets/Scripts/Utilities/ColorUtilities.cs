using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUtilities : MonoBehaviour
{
    public static ColorUtilities instance;

    public Material[] colors;
    public Material[] colorsNoRim;
    public Material basicColor;

    private void Awake()
    {
        instance = this; 
    }

    public Material GetIndexMaterial(int value)
    {
        switch (value)
        {
            case 0:
                return basicColor;
                break;
            case 2:
                return colors[0];
                break;
            case 4:
                return colors[1];
                break;
            case 8:
                return colors[2];
                break;
            case 16:
                return colors[3];
                break;
            case 32:
                return colors[4];
                break;
            case 64:
                return colors[5];
                break;
            case 128:
                return colors[6];
                break;
            case 256:
                return colors[7];
                break;
            case 512:
                return colors[8];
                break;
            case 1024:
                return colors[9];
                break;
            case 2048:
                return colors[10];
                break;
        }

        return null;
    }

    public Material GetIndexMaterial(int value , bool noRim)
    {
        switch (value)
        {
            case 0:
                return basicColor;
                break;
            case 2:
                return colorsNoRim[0];
                break;
            case 4:
                return colorsNoRim[1];
                break;
            case 8:
                return colorsNoRim[2];
                break;
            case 16:
                return colorsNoRim[3];
                break;
            case 32:
                return colorsNoRim[4];
                break;
            case 64:
                return colorsNoRim[5];
                break;
            case 128:
                return colorsNoRim[6];
                break;
            case 256:
                return colorsNoRim[7];
                break;
            case 512:
                return colorsNoRim[8];
                break;
            case 1024:
                return colorsNoRim[9];
                break;
            case 2048:
                return colorsNoRim[10];
                break;
        }

        return null;
    }
}
