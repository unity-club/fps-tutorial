using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
	public Transform player;
	public float mouseSensitivity;
	private float cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float x = mouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
		float y = mouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

		cameraRotation -= y;
		cameraRotation = Mathf.Clamp(cameraRotation, -90, 90);

		transform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);

		player.Rotate(Vector3.up * x);
    }
}
