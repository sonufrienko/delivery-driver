using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField] float steerSpeed = 220.0f;
  [SerializeField] float moveSpeed = 6.0f;
  [SerializeField] float slowSpeed = 4f;
  [SerializeField] float boostSpeed = 12f;

  bool isBoost;
  bool isSlow;

  void Start()
  {
  }

  void Update()
  {
    float currentSpeed = moveSpeed;
    if (isBoost)
    {
      currentSpeed = boostSpeed;
    }
    else if (isSlow)
    {
      currentSpeed = slowSpeed;
    }

    float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
    float moveAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

    transform.Rotate(0, 0, -steerAmount);
    transform.Translate(0, moveAmount, 0);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    switch (other.tag)
    {
      case "Bomb":
        Debug.Log("Bomb");
        isBoost = false;
        isSlow = true;
        break;
      case "Rocket":
        Debug.Log("Rocket");
        isBoost = true;
        isSlow = false;
        break;
      default:
        break;
    }
  }
}
