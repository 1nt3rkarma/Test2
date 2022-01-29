using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private void Update()
    {
        ChangeGravity();
    }

    private void ChangeGravity()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.tapCount == 2)
            {
                if (touch.phase == TouchPhase.Stationary)
                {
                    if (Physics.gravity.y < 0f)
                        Physics.gravity = new Vector3(0, 9.81f, 0);
                    else if (Physics.gravity.y >= 9f)
                        Physics.gravity = new Vector3(0, -9.81f, 0);
                }
            }
        }
    }
}
