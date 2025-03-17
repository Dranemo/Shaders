using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] List<CameraScript> cameras;
    CameraScript currentCamera;
    int currentCameraIndex = 0;

    string textStart = "Q // D : Changer de caméra - ";
    [SerializeField] TMPro.TextMeshProUGUI textUI;

    void Start()
    {
        // Trier la liste des caméras par id en ordre croissant
        cameras.Sort((camera1, camera2) => camera1.id.CompareTo(camera2.id));
        if (cameras.Count > 0)
        {
            currentCamera = cameras[0];
            // Activer la première caméra
            SetActiveCamera(currentCamera);
            textUI.text = textStart + currentCamera.text;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
            ChangeCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeCamera(-1);
        }
    }

    void ChangeCamera(int direction)
    {
        currentCameraIndex = (currentCameraIndex + direction + cameras.Count) % cameras.Count;
        currentCamera = cameras[currentCameraIndex];
        SetActiveCamera(currentCamera);

        textUI.text = textStart + currentCamera.text;
    }

    void SetActiveCamera(CameraScript camera)
    {
        foreach (var cam in cameras)
        {
            cam.gameObject.SetActive(cam == camera);
        }
    }
}
