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
    if (other.tag == "Coin" && !hasCoin)
    {
      Destroy(other.gameObject);
      Debug.Log("Got Golden Coin");
      hasCoin = true;
      spriteRenderer.color = new Color32(222, 197, 16, 255);
    }
    else if (other.tag == "Bank" && hasCoin)
    {
      Debug.Log("You win");
      hasCoin = false;
      spriteRenderer.color = new Color32(255, 255, 255, 255);
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
  }
}
