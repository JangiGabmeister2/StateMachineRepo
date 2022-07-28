using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 0.02f;
    void Update()
    {
        NewMovement();
        //OldMovement();
    }

    void NewMovement()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(xAxis,yAxis);

        move.Normalize();
        move *= playerSpeed * Time.deltaTime;

        transform.position += (Vector3) move;
    }

    void OldMovement()
    {
        //Camera.main.transform.position = playerPosition;

        if (Input.GetKey(KeyCode.W))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.y += playerSpeed * Time.deltaTime;
            transform.position = playerPosition;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.x += playerSpeed * Time.deltaTime;
            transform.position = playerPosition;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.x -= playerSpeed * Time.deltaTime;
            transform.position = playerPosition;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.y -= playerSpeed * Time.deltaTime;
            transform.position = playerPosition;
        }
    }
}
