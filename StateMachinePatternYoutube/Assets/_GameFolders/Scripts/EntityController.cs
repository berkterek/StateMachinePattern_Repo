using UnityEngine;

public class EntityController : MonoBehaviour
{
    public IMover Movement { get; private set; }

    void Awake()
    {
        Movement = new MovementWithAStar(this);
    }

    public void SetTargetType(TargetType targetType)
    {
        
    }
}