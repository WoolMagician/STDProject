/// <summary>
/// 
/// </summary>
public abstract class DroneState : BaseState
{
    /// <summary>
    /// 
    /// </summary>
    protected Drone drone;

    /// <summary>
    /// 
    /// </summary>
    public override abstract void EnterState();

    /// <summary>
    /// 
    /// </summary>
    public override abstract void ExitState();

    /// <summary>
    /// 
    /// </summary>
    public override abstract void UpdateState();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="drone"></param>
    public void SetReferenceDrone(Drone drone)
    {
        this.drone = drone;
    }
}