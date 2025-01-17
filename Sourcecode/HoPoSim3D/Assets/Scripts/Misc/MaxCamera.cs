﻿//
//Filename: maxCamera.cs
//
// original: http://www.unifycommunity.com/wiki/index.php?title=MouseOrbitZoom
//
// --01-18-2010 - create temporary target, if none supplied at start

using UnityEngine;


[AddComponentMenu("Camera-Control/3dsMax Camera Style")]
public class MaxCamera : MonoBehaviour
{
	public Transform target;
	public GameObject targetObject;
	public Vector3 targetOffset;
	public float distance = 5.0f;
	public float maxDistance = 100;
	public float minDistance = .1f;
	public float xSpeed = 200.0f;
	public float ySpeed = 200.0f;
	public int yMinLimit = -80;
	public int yMaxLimit = 80;
	public int zoomRate = 5;
	public float panSpeed = 0.3f;
	public float zoomDampening = 5f;

	private float xDeg = 0.0f;
	private float yDeg = 0.0f;
	private float currentDistance;
	private float desiredDistance;
	private Quaternion currentRotation;
	private Quaternion desiredRotation;
	private Quaternion rotation;
	private Vector3 position;
	private Vector3 lastPosition;

	void Start() { Init(); }
	void OnEnable() { Init(); }

	public void Init()
	{
		// create a temporary target at 'distance' from the cameras current viewpoint
	
		GameObject cameraTarget = GetCamTarget();
		distance = Vector3.Distance(transform.position, targetObject.transform.position);
		cameraTarget.transform.position = transform.position + (transform.forward * distance);
		target = cameraTarget.transform;

		distance = Vector3.Distance(transform.position, target.position);
		currentDistance = distance;
		desiredDistance = distance;

		//be sure to grab the current rotations as starting points.
		position = transform.position;
		rotation = transform.rotation;
		currentRotation = transform.rotation;

		xDeg = Vector3.Angle(Vector3.right, transform.right);
		yDeg = Vector3.Angle(Vector3.up, transform.up);
	}


	private void SetPosition()
	{
		// calculate position based on the new currentDistance 
		position = target.position - (rotation * Vector3.forward * currentDistance + targetOffset);
		transform.position = position;
		lastPosition = position;
	}

	/*
     * Camera logic on LateUpdate to only update after all character movement logic has been handled. 
     */
	void LateUpdate()
	{
		if (lastPosition != transform.position)
			Init();

		var leftButtonDown = Input.GetMouseButton(0);

		// If Control and Alt and Middle button? ZOOM!
		if (leftButtonDown && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl))
		{
			Zoom();
			OrbitPosition();
		}
		// If middle mouse and left alt are selected? ORBIT
		else if (leftButtonDown && Input.GetKey(KeyCode.LeftAlt))
		{
			OrbitAngle();
			OrbitPosition();
		}
		// otherwise if middle mouse is selected, we pan by way of transforming the target in screenspace
		else if (leftButtonDown)
		{
			Pan();
			OrbitPosition();
		}
		else if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			OrbitPosition();
		}
	}

	private void Pan()
	{
		//grab the rotation of the camera so we can move in a psuedo local XY space
		target.rotation = transform.rotation;
		target.Translate(Vector3.right * -Input.GetAxis("Mouse X") * panSpeed);
		target.Translate(transform.up * -Input.GetAxis("Mouse Y") * panSpeed, Space.World);
	}

	private void OrbitAngle()
	{
		xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
		yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

		////////OrbitAngle

		//Clamp the vertical axis for the orbit
		yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
		// set camera rotation 
		desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
		currentRotation = transform.rotation;

		rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
		transform.rotation = rotation;
	}

	private void Zoom()
	{
		desiredDistance -= Input.GetAxis("Mouse Y") * Time.deltaTime * zoomRate * 0.125f * Mathf.Abs(desiredDistance);
	}

	private void OrbitPosition()
	{
		////////Orbit Position
		// affect the desired Zoom distance if we roll the scrollwheel
		desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
		//clamp the zoom min/max
		desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
		// For smoothing of the zoom, lerp distance
		currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);

		// calculate position based on the new currentDistance 
		SetPosition();
	}

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);
	}

	private GameObject GetCamTarget()
	{
		if (camTarget == null)
			camTarget = new GameObject("Cam Target");
		return camTarget;

	}
	GameObject camTarget;
}