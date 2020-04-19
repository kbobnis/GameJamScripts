using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// This is based on https://github.com/jiankaiwang/FirstPersonController
/// </summary>
public class MouseMovesHead : MonoBehaviour
{
	[SerializeField] private float sensitivity = 5.0f;
	[SerializeField] private float smoothing = 2.0f;
	[SerializeField] private bool lookOnRightClick;

	private GameObject character;

	private Vector2 mouseLook = new Vector2(-90, 0);

	// smooth the mouse moving
	private Vector2 smoothV;

	void Awake()
	{
		character = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		bool willmove = !lookOnRightClick || Input.GetMouseButton(1);

		if (willmove)
		{
			Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
			mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
			// the interpolated float result between the two float values
			smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
			smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
			mouseLook += smoothV;

			transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
			character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
		}
	}
}