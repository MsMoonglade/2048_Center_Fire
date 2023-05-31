using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRandomizer : MonoBehaviour
{
    public Material[] possibleMat;

    private MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();

        RandomMaterial();
    }

    private void RandomMaterial()
    {
        int actualMat = Random.Range(0, possibleMat.Length);
        renderer.material = possibleMat[actualMat];
    }
}
