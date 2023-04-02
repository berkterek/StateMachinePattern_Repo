using UnityEngine;

public class WalkState : IState
{
    readonly EntityController _entityController;
    
    public WalkState(EntityController entityController)
    {
        _entityController = entityController;
    }
    
    public void Enter()
    {
        Debug.Log($"State:{nameof(WalkState)} Method:{nameof(Enter)}");
        
        _entityController.Movement.SetDestination(_entityController.CurrentTarget);
    }

    public void Exit()
    {
        Debug.Log($"State:{nameof(WalkState)} Method:{nameof(Exit)}");
        
        _entityController.Movement.Stop();
    }

    public void Tick()
    {
        Debug.Log($"State:{nameof(WalkState)} Method:{nameof(Tick)}");
    }
}