using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class TouchScreenControlExample : MonoBehaviour
{
    public bool isJumpedPressed = false;
    /// <summary>
    /// The position (X and Y distance) finger moved in previous frame
    /// </summary>
    public Vector2 fingerDeltaPosition;

    public Image JumpButton;
    public int JumpButtonFingerID = -1;
    private bool IsInRect(RectTransform rect, Vector2 screenPoint)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch _touch in TouchScreenInputWrapper.touches)
        {
            if (_touch.phase == TouchPhase.Began)
            {
                if (IsInRect(JumpButton.rectTransform, _touch.position))
                {
                    //Jump button pressed
                    Debug.Log("Jump button pressed");
                    isJumpedPressed = true;
                    JumpButtonFingerID = _touch.fingerId;
                    
                }
            }
            else if (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Canceled)
            {
                if (_touch.fingerId == JumpButtonFingerID)
                {
                    //Jump button released
                    Debug.Log("Jump button released");
                    JumpButtonFingerID = -1;
                    isJumpedPressed = false;
                }
            }

            fingerDeltaPosition = _touch.deltaPosition;
        }

    }
}