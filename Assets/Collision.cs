using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
  bool hasCoin;

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
    } 
    else if (other.tag == "Bank" && hasCoin) 
    {
      Debug.Log("You win");
      hasCoin = false;
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
  }
}
