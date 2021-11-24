using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : weapon {

    public static int projectiles = 100;
    public static Text projectileCount;
    private RaycastHit hit;

    protected void projectileCountUI() {
        projectileCount = GameObject.Find("projectileCountUI").GetComponent<Text>();
        projectileCount.text = inventory.projectiles.ToString();
    }

    protected void pickUp() {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null && bc.gameObject.GetComponent<Rigidbody>() != null) {
                    float dist = Vector3.Distance(transform.position, bc.gameObject.transform.position);
                    if (dist <= 10) {
                        inventory.projectiles++;
                        Destroy(bc.gameObject);
                    }
                }
            }
            projectileCount.text = inventory.projectiles.ToString();
        }
    }
}