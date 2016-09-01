// based on a script by puppe -something or other im sorry i forgot on the unity forums

using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public float panSpeed = 20;
	Camera gameCamera;

	void Start ()
	{
		gameCamera = gameObject.GetComponent<Camera>();
	}
	
	void Update ()
	{
		if (Input.GetMouseButton(2))
		{
			transform.Translate(Vector3.right * Time.deltaTime * panSpeed * (Input.mousePosition.x - gameCamera.pixelWidth * 0.5f) / (gameCamera.pixelWidth * 0.5f), Space.World);
			transform.Translate(Vector3.up * Time.deltaTime * panSpeed * (Input.mousePosition.y - gameCamera.pixelHeight * 0.5f) / (gameCamera.pixelHeight * 0.5f), Space.World);
			//transform.Translate(new Vector3(1 * Time.deltaTime * panSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), 0, 0), Space.World);
		}
	}
}
