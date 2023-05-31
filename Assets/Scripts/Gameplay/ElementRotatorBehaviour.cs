using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MoreMountains.FeedbacksForThirdParty.MMFeedbackHaptics;
using UnityEngine.AI;

public class ElementRotatorBehaviour : MonoBehaviour
{
    public float rotator_Speed;
    public float rotator_Radius;
  
    private void Awake()
    {
        /*
        for (int i = 0; i < transform.childCount; i++)
        {
            float angle = i * Mathf.PI * 2f / transform.childCount;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 0.5f , Mathf.Sin(angle) * radius);
            transform.GetChild(i).transform.localPosition = newPos;
        }
        */
    }

    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            float angle = i * Mathf.PI * 2f / transform.childCount;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * rotator_Radius, 0.5f, Mathf.Sin(angle) * rotator_Radius);
            transform.GetChild(i).transform.localPosition = newPos;
        }

        transform.RotateAround(transform.position, transform.up, rotator_Speed * Time.deltaTime);
    }
}