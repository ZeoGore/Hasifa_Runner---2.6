using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public bool swipeLeft, swipeRight, swipeUp;

    private bool isTouching = false;

    private Vector2 touchStartPosition, swipeDelta;
    [SerializeField] private float swipeThreshold = 10; // the distance that needs to be "touched"

    private void Update()
    {
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;

        if (Input.GetMouseButtonDown(0))
        {
            isTouching = true;
            touchStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouching = false;

            swipeDelta = new Vector2(
                Input.mousePosition.x - touchStartPosition.x,
                Input.mousePosition.y - touchStartPosition.y);

            if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x))
            {
                if (swipeDelta.y > swipeThreshold)
                {
                    swipeUp = true;
                }
            }
            else // x > y
            {
                if (swipeDelta.x > swipeThreshold)
                {
                    swipeRight = true;
                }
                else if (swipeDelta.x < -swipeThreshold)
                {
                    swipeLeft = true;
                }
            }

            swipeDelta = Vector2.zero;
        }

    }
}
