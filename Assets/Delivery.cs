using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    //SpriteRenderer spriteRenderer;

    void Start() {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Coll");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package")
        {
            Debug.Log("You've picked up a Package");
            // other.GetComponent<SpriteRenderer>().enabled = false;
            // other.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(other.gameObject, 0.5f);
            GetComponent<SpriteRenderer>().color = other.GetComponent<SpriteRenderer>().color;
            //spriteRenderer.color = other.spriteRenderer.color;
            hasPackage = true;
        }
        if ((other.tag == "Customer") && (hasPackage == true))
        {
            Debug.Log("You've delivered the package to the Customer");
            // other.GetComponent<SpriteRenderer>().enabled = false;
            // other.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(other.gameObject, 0.5f);
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (other.tag == "Customer")
        {
            Debug.Log("There is no package");
        }
    }
}
