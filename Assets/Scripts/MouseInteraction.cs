using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInteraction : MonoBehaviour {

    public GameObject wall;
    public GameObject tower;
    public Button wallButton;
    public Button destroyButton;
    public Button towerButton;
    public Material walkable;
    public Material notWalkable;

    bool wallSelected;
    bool destroySelected;
    bool towerSelected;

    BasicEnemy enemyClicked;
    OceanNodeScript oceanNodeClicked;
    WallScript wallClicked;
    TowerScript towerClicked;

    LayerMask currentLayerMask;
    Renderer currentColor;
    
    // Use this for initialization
    void Start() {
        wallSelected = false;
        destroySelected = false;
        towerSelected = false;

        currentLayerMask = 8;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,100 ,1 << currentLayerMask))
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

                    //create structure on click
                    oceanNodeClicked = hit.collider.GetComponent<OceanNodeScript>();
                    if (oceanNodeClicked != null && oceanNodeClicked.isBuilt == false)
                    {
                        //wall
                        if (wallSelected)
                        {
                            Instantiate(wall, hit.collider.transform);
                            oceanNodeClicked.isBuilt = true;
                        }
                        //tower
                        if (towerSelected)
                        {
                            Instantiate(tower, hit.collider.transform);
                            oceanNodeClicked.isBuilt = true;
                        }
                        currentColor = oceanNodeClicked.gameObject.GetComponent<Renderer>();
                        currentColor.material = notWalkable;
                    }
                    //destroy structure on click
                    if (destroySelected)
                    {
                        //wall
                        wallClicked = hit.collider.GetComponent<WallScript>();
                        if (wallClicked != null)
                        {
                            oceanNodeClicked = wallClicked.gameObject.GetComponentInParent<OceanNodeScript>();
                            oceanNodeClicked.isBuilt = false;
                            Destroy(wallClicked.gameObject);
                            currentColor = oceanNodeClicked.gameObject.GetComponent<Renderer>();
                            currentColor.material = walkable;
                        }
                        //tower
                        towerClicked = hit.collider.GetComponentInParent<TowerScript>();
                        if (towerClicked != null)
                        {
                            oceanNodeClicked = towerClicked.gameObject.GetComponentInParent<OceanNodeScript>();
                            oceanNodeClicked.isBuilt = false;
                            Destroy(towerClicked.gameObject);
                            currentColor = oceanNodeClicked.gameObject.GetComponent<Renderer>();
                            currentColor.material = walkable;
                        }
                    }
                }
            }
        }

        //keyboard shortcuts
        //select wall
        if (Input.GetKeyDown("q"))
        {
            SetBuilderToWall();
        }
        //select tower
        if (Input.GetKeyDown("w"))
        {
            SetBuilderToTower();
        }
        //select destroy
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
        towerSelected = false;
        towerButton.interactable = true;
        currentLayerMask = 8;
    }

    public void SetBuilderToDestroy()
    {
        destroySelected = true;
        destroyButton.interactable = false;
        wallSelected = false;
        wallButton.interactable = true;
        towerSelected = false;
        towerButton.interactable = true;
        currentLayerMask = 9;
    }

    public void SetBuilderToTower()
    {
        towerSelected = true;
        towerButton.interactable = false;
        wallSelected = false;
        wallButton.interactable = true;
        destroySelected = false;
        destroyButton.interactable = true;
        currentLayerMask = 8;
    }
}
