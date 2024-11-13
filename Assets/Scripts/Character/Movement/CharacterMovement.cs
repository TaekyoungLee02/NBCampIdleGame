using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour
{
    public float speed;

    private TopDownController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        controller.OnMove += Move;
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
