using UnityEngine;

public class AttackState : IState
{
    readonly EntityController _entityController;
    readonly float _maxTime = 5f; 
    float _currentTime = 0f;

    public AttackState(EntityController entityController)
    {
        _entityController = entityController;
    }
    
    public void Enter()
    {
        Debug.Log($"State:{nameof(AttackState)} Method:{nameof(Enter)}");
        _entityController.Animator.SetBool("isAttacking",true);
        _entityController.AttackObject.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log($"State:{nameof(AttackState)} Method:{nameof(Exit)}");
        _currentTime = 0f;
        _entityController.Animator.SetBool("isAttacking",false);
        _entityController.AttackObject.SetActive(false);
    }

    public void Tick()
    {
        Debug.Log($"State:{nameof(AttackState)} Method:{nameof(Tick)}");
        
        _currentTime += Time.deltaTime;
        
        if (_currentTime > _maxTime)
        {
            _entityController.ChangeState();
        }
    }
}