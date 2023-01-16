public class StateMachine 
{
    public State currentState {get; private set;}

    public void Initialize(State startState)
    {
        currentState = startState;

        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }
}
