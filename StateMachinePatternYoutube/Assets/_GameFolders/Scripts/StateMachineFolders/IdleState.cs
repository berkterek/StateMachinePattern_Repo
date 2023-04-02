using UnityEngine;

public class IdleState : IState
{
    readonly EntityController _entityController;
    readonly float _maxTime = 5f; 
    float _currentTime = 0f;
    
    public IdleState(EntityController entityController)
    {
        _entityController = entityController;
    }
    
    public void Enter()
    {
        Debug.Log($"State:{nameof(IdleState)} Method:{nameof(Enter)}");
        
        _entityController.Animator.SetBool("isIdle",true);
    }

    public void Exit()
    {
        Debug.Log($"State:{nameof(IdleState)} Method:{nameof(Exit)}");
        _currentTime = 0f;
        _entityController.Animator.SetBool("isIdle",false);
    }

    public void Tick()
    {
        Debug.Log($"State:{nameof(IdleState)} Method:{nameof(Tick)}");

        _currentTime += Time.deltaTime;
        
        if (_currentTime > _maxTime)
        {
            _entityController.ChangeState();
        }
    }
}