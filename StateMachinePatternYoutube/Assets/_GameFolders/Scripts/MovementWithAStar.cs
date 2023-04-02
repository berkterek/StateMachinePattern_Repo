using Pathfinding;
using UnityEngine;

public class MovementWithAStar : IMover
{
    readonly AIDestinationSetter _destinationSetter;
    readonly AILerp _aiLerp;

    public MovementWithAStar(EntityController entityController)
    {
        _destinationSetter = entityController.GetComponent<AIDestinationSetter>();
        _aiLerp = entityController.GetComponent<AILerp>();
    }

    public void SetDestination(Transform transform)
    {
        _aiLerp.isStopped = false;
        _destinationSetter.target = transform;
    }

    public void Stop()
    {
        _destinationSetter.target = null;
        _aiLerp.isStopped = true;
    }
}