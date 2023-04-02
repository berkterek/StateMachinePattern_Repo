using UnityEngine;

public class WorkState : IState
{
    readonly EntityController _entityController;
    readonly float _maxTime = 5f; 
    float _currentTime = 0f;
    
    public WorkState(EntityController entityController)
    {
        _entityController = entityController;
    }
    
    public void Enter()
    {
        Debug.Log($"State:{nameof(WorkState)} Method:{nameof(Enter)}");
        _entityController.Animator.SetBool("isWorking",true);
    }

    public void Exit()
    {
        Debug.Log($"State:{nameof(WorkState)} Method:{nameof(Exit)}");
        _currentTime = 0f;
        _entityController.Animator.SetBool("isWorking",false);
    }

    public void Tick()
    {
        Debug.Log($"State:{nameof(WorkState)} Method:{nameof(Tick)}");
        
        _currentTime += Time.deltaTime;
        
        if (_currentTime > _maxTime)
        {
            _entityController.ChangeState();
        }
    }
}