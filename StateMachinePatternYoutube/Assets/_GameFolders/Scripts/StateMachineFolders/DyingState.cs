using UnityEngine;

public class DyingState : IState
{
    readonly EntityController _entityController;
    readonly float _maxTime = 5f; 
    float _currentTime = 0f;
    
    public DyingState(EntityController entityController)
    {
        _entityController = entityController;
    }
    
    public void Enter()
    {
        Debug.Log($"State:{nameof(DyingState)} Method:{nameof(Enter)}");
        _entityController.Animator.SetBool("isDying",true);
    }

    public void Exit()
    {
        Debug.Log($"State:{nameof(DyingState)} Method:{nameof(Exit)}");
        _currentTime = 0;
        _entityController.Animator.SetBool("isDying",false);
    }

    public void Tick()
    {
        Debug.Log($"State:{nameof(DyingState)} Method:{nameof(Tick)}");
        
        _currentTime += Time.deltaTime;
        
        if (_currentTime > _maxTime)
        {
            _entityController.ChangeState();
        }
    }
}