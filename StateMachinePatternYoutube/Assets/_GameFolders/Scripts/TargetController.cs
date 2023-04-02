using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] TargetType _targetType;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out EntityController entityController)) return;

        entityController.SetTargetType(_targetType);
    }
}
