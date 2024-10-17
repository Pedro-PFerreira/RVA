using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager trackedImages;
    public GameObject[] ARPrefabs;

    List<GameObject> ARObjects = new List<GameObject>();

    public void Awake()
    {
        trackedImages = GetComponent<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        trackedImages.trackedImagesChanged += OnTrackedImagesChanged;
    }

    public void OnDisable()
    {
        trackedImages.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    public void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        // Object creation
        foreach (var trackedImage in eventArgs.added)
        {
            Debug.Log("Tracked Image added: " + trackedImage.referenceImage.name);
            foreach (var arPrefab in ARPrefabs)
            {
                Debug.Log("Checking prefab: " + arPrefab.name);

                if (trackedImage.referenceImage.name == arPrefab.name)
                {
                    Debug.Log("Matching prefab found: " + arPrefab.name);
                    GameObject arObject = Instantiate(arPrefab);
                    arObject.transform.position = trackedImage.transform.position;
                    arObject.transform.rotation = trackedImage.transform.rotation;
                    arObject.transform.SetParent(trackedImage.transform, true);
                    ARObjects.Add(arObject);
                    Debug.Log("Prefab instantiated and added: " + arPrefab.name);
                }
            }
        }

        // Object position tracking
        foreach (var trackedImage in eventArgs.updated)
        {
            Debug.Log("Tracked Image updated: " + trackedImage.name);
            foreach (var gameObject in ARObjects)
            {
                if (gameObject.name == trackedImage.referenceImage.name)
                {
                    Debug.Log("Tracking state: " + trackedImage.trackingState);
                    gameObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
                    if (trackedImage.trackingState == TrackingState.Tracking)
                    {
                        gameObject.transform.position = trackedImage.transform.position;
                        gameObject.transform.rotation = trackedImage.transform.rotation;
                        Debug.Log("Position updated for: " + gameObject.name);
                    }
                }
            }
        }
    }
}
