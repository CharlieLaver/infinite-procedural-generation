using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public Transform buildPos;
    public Camera camera;
    private Ray ray;
    private RaycastHit hit;
    private BoxCollider bc;
    private float howclose = 10;
    private float dist;
    private Text blockCountUI;
    private List<string> collectedObjects = new List<string>();

    void Start()
    {
        blockCountUI = GameObject.Find("blockCountUI").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collectedObjects.Count > 0)
            {
                GameObject x = Resources.Load<GameObject>("collectables/" + getPrefabName(collectedObjects[0]));
                GameObject projectile = Instantiate(x, buildPos.position, buildPos.rotation);
                projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 4000);
                collectedObjects.RemoveAt(0);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                bc = hit.collider as BoxCollider;

                if (bc != null && bc.gameObject.GetComponent<Rigidbody>() != null)
                {
                    dist = Vector3.Distance(transform.position, bc.gameObject.transform.position);

                    if (dist <= howclose)
                    {
                        collectedObjects.Add(bc.gameObject.name);
                        Destroy(bc.gameObject);
                    }
                }
            }
        }
        blockCountUI.text = collectedObjects.Count.ToString();
    }

    string getPrefabName(string name)
    {
        int howManyChars = name.IndexOf("#") + 1;
        return name.Substring(0, howManyChars);
    }

}
