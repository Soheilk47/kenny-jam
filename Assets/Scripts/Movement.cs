using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Space(15)]
    public float speed = 1f;

    public float steerSpeed = 1f;

    public float moveThresold = 10f;

    private float verInput;
    private float moveFactor;

    private float horInput;
    private float steerFactor;

    private void FixedUpdate()
    {
        Move();
        Steer();
    }

    private void Move()
    {
        verInput = Input.GetAxis("Vertical");
        moveFactor = Mathf.Lerp(moveFactor, verInput, Time.deltaTime / moveThresold);
        transform.Translate(0, 0, moveFactor * speed);
    }

    private void Steer()
    {
        horInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horInput, Time.deltaTime / moveThresold);
        transform.Rotate(0, steerFactor * steerSpeed, 0);
    }
}