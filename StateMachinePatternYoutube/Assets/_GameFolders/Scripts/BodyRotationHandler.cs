using UnityEngine;

public class BodyRotationHandler : MonoBehaviour
{
    [SerializeField] Transform _parent;
    [SerializeField] Transform _child;

    void Update()
    {
        _child.transform.localEulerAngles = new Vector3(0f, 0f, -_parent.rotation.eulerAngles.z);
    }
}