using UnityEngine;

//[ExecuteInEditMode]
public class RotateAround : MonoBehaviour
{
	[SerializeField] public Spherical sphericalPosition;
	[SerializeField] private Vector3 speed = new Vector3(0, 0, 1);


	void Update()
	{
		sphericalPosition += speed * Time.deltaTime;
		transform.position = sphericalPosition.ToCartesian();
	}
}