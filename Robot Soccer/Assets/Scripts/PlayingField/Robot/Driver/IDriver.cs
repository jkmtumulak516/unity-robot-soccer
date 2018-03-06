
namespace Assets.Scripts.PlayingField.Robot.Driver
{
    public interface IDriver
    {
        void Process(float destX, float destY);
        
        float RightTorque { get; }
        float LeftTorque { get; }
    }
}
