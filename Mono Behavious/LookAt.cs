
using UnityEngine;

[ExecuteInEditMode]
public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform lookAt;

    void Update()
    {
        transform.LookAt(lookAt);
    }
}