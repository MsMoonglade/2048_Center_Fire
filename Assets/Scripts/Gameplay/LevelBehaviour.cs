using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;
using System;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class LevelBehaviour : MonoBehaviour
{
    public static LevelBehaviour instance;

    public float cameraFov;

    [HideInInspector]
    private bool levelEnded = false;
    
    private void OnEnable()
    {
        instance = this;     
    }     
}

/*
  public void CheckForCombo()
    {
        GameObject[] childNotOrder = new GameObject[gameplayElement.Count];
        GameObject[] childInOrder = new GameObject[gameplayElement.Count];

        for (int i = 0; i < gameplayElement.Count; i++)
        {
            childNotOrder[i] = gameplayElement[i].gameObject;
        }

        if (lastDir == Vector3.forward)
            childInOrder = childNotOrder.OrderBy(go => go.transform.localPosition.z).ToArray();
        else if (lastDir == Vector3.back)
            childInOrder = childNotOrder.OrderBy(go => -go.transform.localPosition.z).ToArray();
        else if (lastDir == Vector3.right)
            childInOrder = childNotOrder.OrderBy(go => go.transform.localPosition.x).ToArray();
        else if (lastDir == Vector3.left)
            childInOrder = childNotOrder.OrderBy(go => -go.transform.localPosition.x).ToArray();

        for (int i = 0; i < childInOrder.Length; i++)
        {
            GameObject current = childInOrder[i];
            if (!current.GetComponent<GameplayElement>().alreadyTaken)
            {
                GameObject target = childInOrder[i].GetComponent<GameplayElement>().HaveValueInRange(lastDir);

                
                if (target == null)
                {
                    target = childInOrder[i].GetComponent<GameplayElement>().HaveValueInRange(-lastDir);
                }
                Vector3 rotated = Quaternion.AngleAxis(90, Vector3.up) * lastDir;
                if (target == null)
                    target = childInOrder[i].GetComponent<GameplayElement>().HaveValueInRange(rotated);
                if (target == null)
                    target = childInOrder[i].GetComponent<GameplayElement>().HaveValueInRange(-rotated);
                

if (target != null && target.GetComponent<GameplayElement>())
{
    current.GetComponent<GameplayElement>().StartGoInMerge();
    target.GetComponent<GameplayElement>().StartReciveMerge();

    current.transform.DOMove(target.transform.position, 0.25f)
        .OnComplete(() => CompleteCubeMerge(current, target));
}
            }
        }

        childFinishMove = true;

foreach (GameObject o in destroyedWithCombo)
{
    if (o != null)
    {
        o.transform.parent = destroyedParent.transform;
        o.gameObject.SetActive(false);
        o.transform.position = new Vector3(100, 100, 100);
    }
}
    }
        
    

    void CompleteCubeMerge(GameObject current, GameObject target)
{
    current.transform.localScale = Vector3.zero;
    current.GetComponent<Collider>().enabled = false;
    destroyedWithCombo.Add(current);

    target.GetComponent<GameplayElement>().IncreaseValue();
}
*/