using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    bool hasPackage;
    [SerializeField] float destroyObjectTimer;
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log ("Oyyy, you dingus!");
   }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Package" && !hasPackage){
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Picked up package!");
            Destroy(other.gameObject, destroyObjectTimer);
        }

        if(other.tag == "Customer" && hasPackage){
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package delivered!");
        }
   }
}
