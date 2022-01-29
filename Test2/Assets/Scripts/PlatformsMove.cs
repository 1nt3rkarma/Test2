using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    [SerializeField] GameObject objectToRotate;

    [Space]
    [SerializeField] int minScale;
    [SerializeField] int maxScale;

    private float initialFingersDistance;

    private Vector3 initialScale;
    private float firstPoint;
    private float secondPoint;

    //так и не поняла что это такое - спросить у владушки
    private int m_inc = 0;

    private void Update()
    {
        if (Input.touchCount == 0)
        {
            m_inc = 0;
            return;
        }

        if (objectToRotate == null)
            return;

        if (Input.touchCount == 1)
        {
            if (m_inc == 0)
            {
                firstPoint = (int)Input.GetTouch(0).position.x;
                secondPoint = (int)Input.GetTouch(0).position.x;
            }

            m_inc++;

            if (m_inc <= 10)
                return;

            secondPoint = (int)Input.GetTouch(0).position.x;

            if (firstPoint < secondPoint)
                Rotate(false);

            else if (firstPoint > secondPoint)
                Rotate(true);
            
            return;
        }

        if (Input.touches.Length == 2)
        {
            Scale();
            return;
        }
    }


    private void LateUpdate()
    {
        if (m_inc >= 10)
            firstPoint = (int)Input.GetTouch(0).position.x;
    }

    private void Rotate(bool right)
    {
        if (right)
            objectToRotate.transform.Rotate(Vector3.right * Time.deltaTime * 100f);
        else
            objectToRotate.transform.Rotate(Vector3.left * Time.deltaTime * 100f);
    }

    private void Scale()
    {
        if (Input.touches.Length == 2)
        {
            Touch t1 = Input.touches[0];
            Touch t2 = Input.touches[1];

            if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
            {
                initialFingersDistance = Vector2.Distance(t1.position, t2.position);
                initialScale = objectToRotate.transform.localScale;
            }
            else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            {
                float currentFingersDistance = Vector2.Distance(t1.position, t2.position);
                var scaleFactor = currentFingersDistance / initialFingersDistance;

                Vector3 m_scale = initialScale * scaleFactor;

                m_scale.x = Mathf.Clamp(m_scale.x, minScale, maxScale);
                m_scale.y = Mathf.Clamp(m_scale.y, minScale, maxScale);
                m_scale.z = Mathf.Clamp(m_scale.z, minScale, maxScale);
                objectToRotate.transform.localScale = m_scale;
            }
        }

    }
}