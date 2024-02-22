using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public float reachRange = 3f;

    private Camera fpsCam;
    private GameObject player;

    private bool playerEntered;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private string msg;

    private int rayLayerMask;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        fpsCam = Camera.main;
        if (fpsCam == null) 
        {
            Debug.LogError("A camera tagged 'MainCamera' is missing.");
        }

        LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
        rayLayerMask = 1 << iRayLM.value;

        setupGui();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerEntered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)     
        {
            playerEntered = false;
            showInteractMsg = false;
        }
    }

    void Update()
    {
        if(playerEntered)
        {
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, reachRange, rayLayerMask))
            {

                
                    showInteractMsg = true;
                    msg = "Presiona E/Click para acostarte";

                    if ((Input.GetKeyUp(KeyCode.E) || Input.GetButtonDown("Fire1")) && showInteractMsg)
                    {
                        foreach (MeshCollider coll in GetComponentsInChildren<MeshCollider>()) { coll.enabled = false; }
                        player.GetComponent<FPSController>().canMove = false;
                        player.transform.rotation = transform.rotation;
                        player.GetComponent<CharacterController>().Move(transform.position - player.transform.position);

                        showInteractMsg= false;
                    }

                
            }
            else
            {
                showInteractMsg = false;
            }
        }
    }

    private void setupGui()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.white;
        msg = "Presiona E para abrir";
    }

    void OnGUI()
    {
        if (showInteractMsg)  
        {
            GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
        }
    }

}
