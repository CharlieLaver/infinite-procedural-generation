using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {
    
    protected List<string> collectedObjects = new List<string>();
    private RaycastHit hit;

    protected void pickUp() {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null && bc.gameObject.GetComponent<Rigidbody>() != null) {
                    float dist = Vector3.Distance(transform.position, bc.gameObject.transform.position);
                    if (dist <= 10) {
                        collectedObjects.Add(bc.gameObject.name);
                        Destroy(bc.gameObject);
                    }
                }
            }
        }
    }
}