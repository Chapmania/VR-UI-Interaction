using System.Collections;
using System.Collections.Generic;
//--------//--------//
using UnityEngine;
using UnityEngine.UI;
//--------//--------//
using Valve.VR;
//--------//--------//

public class VRUIInteraction : MonoBehaviour
{
    [SerializeField]
    private float defaultLength;
    [SerializeField]
    private GameObject dot;
    private LineRenderer lineRenderer = null;

    [SerializeField]
    private SteamVR_Input_Sources inputSource;
    [SerializeField]
    private SteamVR_Action_Boolean clickAction;


    // Start is called before the first frame update
    void Start()
    {
        //get lineRenderer component form current GO
        lineRenderer = GetComponent<LineRenderer>();
        //adding a funtion to controllers trigger up event
        clickAction.AddOnStateUpListener(TriggerComplete, inputSource);
    }

    // Update is called once per frame
    void Update()
    {
        //use default or distance
        float targetLength = defaultLength;
        //raycast
        RaycastHit hit = CreateRaycast(targetLength);

        Vector3 endpos = transform.position + (transform.forward * targetLength);

        //check for UI hit
        if (hit.collider != null)
        {
            //set endpos to hit point
            endpos = hit.point;
        }
            

        //set dot a position
        dot.transform.position = endpos;
        //Debug.Log(endpos);

        //set pos of line renderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endpos);
    }

    RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }

    public void TriggerComplete(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger Pressed");

        //use default or distance
        float targetLength = defaultLength;
        //raycast
        RaycastHit hit = CreateRaycast(targetLength);

        //check collision tag
        if(hit.collider.tag == "UI")
        {
            Debug.Log("HIT UI");
            //Get Button Component from Hit GO
            Button button = hit.collider.gameObject.GetComponent<Button>();
            //Invoke onClick Funtions
            button.onClick.Invoke();
        }
        else
        {
            Debug.Log("HIT OBJECT NAME : " + hit.collider.name);
        }
        
    }
}
