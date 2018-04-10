using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInteraction : MonoBehaviour {

    public GameObject wall;
    public Button wallButton;
    public Button destroyButton;

    bool wallSelected;
    bool destroySelected;

    BasicEnemy enemyClicked;
    OceanNodeScript oceanNodeClicked;
    WallScript wallClicked;

    // Use this for initialization
    void Start() {
        wallSelected = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

                    //kill enemy on click
                    enemyClicked = hit.collider.GetComponent<BasicEnemy>();
                    if (enemyClicked != null)
                    {
                        Destroy(enemyClicked.gameObject);
                    }

                    //create wall on click
                    oceanNodeClicked = hit.collider.GetComponent<OceanNodeScript>();
                    if (oceanNodeClicked != null && oceanNodeClicked.isBuilt == false)
                    {
                        if (wallSelected)
                        {
                            Instantiate(wall, hit.collider.transform);
                            oceanNodeClicked.isBuilt = true;
                        }
                    }

                    //destroy structure on click
                    wallClicked = hit.collider.GetComponent<WallScript>();
                    if (wallClicked != null)
                    {
                        if (destroySelected)
                        {
                            oceanNodeClicked = wallClicked.gameObject.GetComponentInParent<OceanNodeScript>();
                            oceanNodeClicked.isBuilt = false;
                            Destroy(wallClicked.gameObject);
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown("q"))
        {
            SetBuilderToWall();
        }
        if (Input.GetKeyDown("d"))
        {
            SetBuilderToDestroy();
        }

        enemyClicked = null;
    }

    public void SetBuilderToWall()
    {
        wallSelected = true;
        wallButton.interactable = false;
        destroySelected = false;
        destroyButton.interactable = true;
    }

    public void SetBuilderToDestroy()
    {
        destroySelected = true;
        destroyButton.interactable = false;
        wallSelected = false;
        wallButton.interactable = true;
    }
}
