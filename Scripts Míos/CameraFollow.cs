using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Gets the current position of the camera, makes it follow the player
    void LateUpdate() 
    {
        if(!player)
        {
            return; // doesn't execute what's below
        }

        tempPos = transform.position;
        tempPos.x = player.position.x;
        transform.position = tempPos;

        if(tempPos.x < minX)
        {
            tempPos.x = minX;
        }

        if(tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }
    }
}
