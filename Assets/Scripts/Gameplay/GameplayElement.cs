using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameplayElement : MonoBehaviour
{
    [Header ("Movement Variables")]
    public float moveTime;
    public LayerMask cubeDetectMask;

    [Header("Local References")]
    public TMP_Text valueText;
    public TrailRenderer trail;
    public ParticleSystem mergeParticle;
    public ParticleSystem explosionParticle;
    public ParticleSystem[] particle_To_Color_Next;
    public ParticleSystem[] particle_To_Color_Same;

    [HideInInspector]
    public int currentValue;

    [HideInInspector]
    public bool alreadyTaken;

    private MeshRenderer renderer;

    //use this only when hit wall with same value and road clear
    private int fixedDistanceForDestroyInWall = 5917;
    private float wallDestroySpeedFixer = 0.25f;

    private void Awake()
    {        
        renderer = GetComponent<MeshRenderer>();
        valueText.text = currentValue.ToString();

        DisableTrail();
    }

    private void Start()
    {
      SetMaterials();
    }

    public void IncreaseValue()
    {
        alreadyTaken = true;

        currentValue *= 2;

        if(currentValue > 2048)
            currentValue = 2048;

        valueText.text = currentValue.ToString();

      //SetMaterials();
    }

    public void DecreaseValue()
    {
        alreadyTaken = true;

        currentValue /= 2;

        if(currentValue < 2)
            currentValue = 2;

        valueText.text = currentValue.ToString();

      // SetMaterials();
    }


    public GameObject HaveValueInRange(Vector3 dir)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, 1.75f, cubeDetectMask))
        {
            if (!hit.transform.GetComponent<GameplayElement>().alreadyTaken)
            {
                if (hit.transform.GetComponent<GameplayElement>().currentValue == currentValue)
                {
                    hit.transform.GetComponent<GameplayElement>().alreadyTaken = true;
                    return hit.transform.gameObject;
                }
            }
        }

        return null;
    }

    private void CompleteWallDestroyMove(Vector3 faceDir)
    {
        explosionParticle.transform.parent = null;
        Quaternion rot = Quaternion.LookRotation(faceDir);
        explosionParticle.transform.rotation = rot;
        explosionParticle.Play();

        Destroy(this.gameObject);
    }
   
    public void StartGoInMerge()
    {
        valueText.transform.DOScale(Vector3.zero, 0.2f);
       // transform.DOScale(transform.localScale * 0.5f, 2f);          
    }

    public void StartReciveMerge()
    {
        SetNextMaterials_Smooth();

        Vector3 originalScale = new Vector3(1.5f, 1.5f , 1.5f);
        mergeParticle.Play();

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(originalScale * 0.9f, 0.2f));
        mySequence.Append(transform.DOScale(originalScale * 1.15f, 0.2f));
        mySequence.Append(transform.DOScale(originalScale , 0.2f));
    }

    public void EnableTrail(Vector3 dir)
    {
        Vector3 oppositeDir = -dir;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, oppositeDir, out hit, 2f, cubeDetectMask))
        {
            trail.emitting = false;
        }

        else
        {
            trail.emitting = trail;
        }
    }

    public void DisableTrail()
    {
        trail.emitting = false; 
    }

    private void SetMaterials()
    {
        renderer.material = ColorUtilities.instance.GetIndexMaterial(currentValue);
        trail.material = renderer.material;

        foreach (ParticleSystem p in particle_To_Color_Same)
        {
            p.startColor = ColorUtilities.instance.GetIndexMaterial(currentValue).GetColor("_BaseColor");
        }

        foreach (ParticleSystem p in particle_To_Color_Next)
        {
            p.startColor = ColorUtilities.instance.GetIndexMaterial(currentValue * 2).GetColor("_BaseColor");
        }
    }

    private void SetNextMaterials_Smooth()
    {
        Material newColor = ColorUtilities.instance.GetIndexMaterial(currentValue * 2);

        //main color
        renderer.material.DOColor(newColor.GetColor("_BaseColor") , "_BaseColor" , 0.5f);
        trail.material.DOColor(newColor.GetColor("_BaseColor") , "_BaseColor" , 0.5f);

        //hightlight color
        renderer.material.DOColor(newColor.GetColor("_HColor"), "_HColor", 0.5f);
        trail.material.DOColor(newColor.GetColor("_HColor"), "_HColor", 0.5f);

        foreach (ParticleSystem p in particle_To_Color_Same)
        {
            p.startColor = ColorUtilities.instance.GetIndexMaterial(currentValue * 2).GetColor("_BaseColor");
        } 

        foreach (ParticleSystem p in particle_To_Color_Next)
        {
            p.startColor = ColorUtilities.instance.GetIndexMaterial((currentValue * 2)).GetColor("_BaseColor");
        }
    }
}
