using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;

    private bool swiped;

    private void Awake()
    {
        swiped = false;
    }

    void Update()
    {
        if (!GameManager.instance.IsInGameStatus())
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.StartGame();
            }
        }

        if (GameManager.instance.IsInGameStatus())
        {
            foreach (Touch touch in Input.touches)
            {

                if (touch.phase == TouchPhase.Began)
                {

                    fingerUp = touch.position;
                    fingerDown = touch.position;

                }

                //Detects Swipe while finger is still moving
                if (touch.phase == TouchPhase.Moved)
                {


                    fingerDown = touch.position;
                }
            }
        }
    }
}