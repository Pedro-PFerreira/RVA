using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlacement : MonoBehaviour
{

    public GameObject arObjectToPlace;
    public GameObject placementIndicator;

    private GameObject spawnedObject;

    private Pose placementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            ARPlaceObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementPose(){
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid){
            placementPose = hits[0].pose;
            Vector3 cameraForward = Camera.current.transform.forward;
            Vector3 cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementIndicator(){
        if (spawnedObject == null || !placementPoseIsValid){
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else{
            placementIndicator.SetActive(false);
        }
    }

    private void ARPlaceObject(){
        spawnedObject = Instantiate(arObjectToPlace, placementPose.position, placementPose.rotation);
    }

}
