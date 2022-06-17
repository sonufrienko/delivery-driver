using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collision : MonoBehaviour
{
  bool hasCoin;
  SpriteRenderer spriteRenderer;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("BAM");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    switch (other.tag)
    {
      case "Coin":
        if (!hasCoin)
        {
          Destroy(other.gameObject);
          Debug.Log("Got coin");
          hasCoin = true;
          spriteRenderer.color = new Color32(222, 197, 16, 255);
        }
        break;
      case "Bank":
        if (hasCoin)
        {
          Debug.Log("You win");
          hasCoin = false;
          spriteRenderer.color = new Color32(255, 255, 255, 255);
        }
        break;
      default:
        break;
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
  }
}
