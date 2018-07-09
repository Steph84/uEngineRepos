﻿using UnityEngine;

public class Controls : MonoBehaviour {

    private Vector3 currentPos = new Vector3();
    private float unitPerSec = 4.0f;

    // Use this for initialization
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update () {
        float moveSpeed = unitPerSec * Time.deltaTime;

		if(Input.GetKey(KeyCode.UpArrow))
        {
            currentPos.y = currentPos.y + moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentPos.y = currentPos.y - moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentPos.x = currentPos.x - moveSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentPos.x = currentPos.x + moveSpeed;
        }

        transform.position = currentPos;
	}
}
