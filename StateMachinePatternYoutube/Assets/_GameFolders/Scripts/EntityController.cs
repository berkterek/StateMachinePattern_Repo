using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] TargetType _currentTargetType;
    [SerializeField] TargetType _nextTargetType;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _attackObject;
    [SerializeField] Transform _currentTarget;
    [SerializeField] Transform _nextTarget;

    StateMachine _stateMachine;

    public IMover Movement { get; private set; }
    public Animator Animator => _animator;
    public GameObject AttackObject => _attackObject;

    public Transform CurrentTarget
    {
        get => _currentTarget;
        set => _currentTarget = value;
    }

    void Awake()
    {
        _stateMachine = new StateMachine();
        Movement = new MovementWithAStar(this);
    }

    void Start()
    {
        IState idleState = new IdleState(this);
        IState walkState = new WalkState(this);
        IState attackState = new AttackState(this);
        IState workState = new WorkState(this);
        IState dyingState = new DyingState(this);

        _stateMachine.SetNormalStates(walkState, idleState,
            () => _currentTargetType == TargetType.Idle &&
                  Vector2.Distance(transform.position, _currentTarget.position) < 1f);
        
        _stateMachine.SetNormalStates(walkState, attackState,
            () => _currentTargetType == TargetType.Attack &&
                  Vector2.Distance(transform.position, _currentTarget.position) < 1f);
        
        _stateMachine.SetNormalStates(walkState, workState,
            () => _currentTargetType == TargetType.Work &&
                  Vector2.Distance(transform.position, _currentTarget.position) < 1f);
        
        _stateMachine.SetNormalStates(walkState,dyingState,
            () => _currentTargetType == TargetType.Dying &&
                  Vector2.Distance(transform.position, _currentTarget.position) < 1f);
        
        _stateMachine.SetAnyStates(walkState, () => Vector2.Distance(_currentTarget.position, transform.position) > 1f);

        _stateMachine.SetState(idleState);
    }

    public void SetTargetType(TargetEntityModel targetEntityModel)
    {
        _currentTargetType = targetEntityModel.TargetType;
        _currentTarget = targetEntityModel.CurrentTarget;
        _nextTarget = targetEntityModel.NextTarget;
        _nextTargetType = targetEntityModel.NextTargetType;
    }

    void Update()
    {
        _stateMachine.Tick();
    }

    public void ChangeState()
    {
        _currentTargetType = _nextTargetType;
        _currentTarget = _nextTarget;
    }
}