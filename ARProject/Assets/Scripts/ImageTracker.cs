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

    public void Awake() {
        trackedImages = GetComponent<ARTrackedImageManager>();
    }

    public void OnEnable() {
        trackedImages.trackedImagesChanged += OnTrackedImagesChanged;
    }

    public void OnDisable() {
        trackedImages.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    public void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs) {
        foreach (var trackedImage in eventArgs.added) {
            foreach (var arPrefab in ARPrefabs) {
                if (trackedImage.referenceImage.name == arPrefab.name) {
                    GameObject arObject = Instantiate(arPrefab, trackedImage.transform);
                    arObject.transform.localPosition = Vector3.zero;
                    arObject.transform.localRotation = Quaternion.identity; // Resets rotation
                    ARObjects.Add(arObject);
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated) {
            foreach (var arObject in ARObjects) {
                if (arObject.name == trackedImage.referenceImage.name) {
                    arObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
                }
            }
        }
    }
}
