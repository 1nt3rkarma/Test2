using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Transform sphere;
    public Text scoreText;

    private void Update()
    {
        ShowText();
    }

    public void ShowText()
    {
        scoreText.text = (sphere.position.z + 4).ToString("0");
    }
}
