using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StraightMoving : MonoBehaviour
{
    float speed = 0.2f;

    //UIFunctions uIFunction;
    [SerializeField] GameObject gameOverMenu;

    void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Game Over");

        //Почему он требует какую-то ссылку ??????
        //uIFunction.GameOver();

        //не могу придумать лучше
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);

    }

    private void Move()
    {
        var vector = new Vector3(transform.position.x, transform.position.y, 100);

        transform.position = Vector3.MoveTowards
            (transform.position,
            vector,
            speed * Time.fixedDeltaTime);
    }
}
