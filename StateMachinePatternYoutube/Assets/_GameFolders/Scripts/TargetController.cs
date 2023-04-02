using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] TargetType _targetType;
    [SerializeField] Transform _nextTarget;
    [SerializeField] TargetType _nextTargetType;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out EntityController entityController)) return;

        entityController.SetTargetType(new TargetEntityModel
        {
            CurrentTarget = this.transform,
            TargetType = _targetType,
            NextTarget = _nextTarget,
            NextTargetType = _nextTargetType
        });
    }
}

public struct TargetEntityModel
{
    public TargetType TargetType { get; set; }
    public Transform CurrentTarget { get; set; }
    public Transform NextTarget { get; set; }
    public TargetType NextTargetType { get; set; }
}