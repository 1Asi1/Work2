namespace Assets.Architecture.Scripts.CustomBehaviour
{
    public interface IBehaviour
    {
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}
