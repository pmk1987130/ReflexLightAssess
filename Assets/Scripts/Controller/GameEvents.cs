public class GameEvents
{
    public enum CommandEvent
    {
        ToCreateService,
        ToG2C,
        ToG2S,
        ToMainScene,
        ToTrack,
        ToG2SHandPosition,
        ToS2GHandPosition,
        ToFrontView,
        ToSideView,
        ToVerticalView,
        ToBoundary,
    }
    public enum ViewEvent
    {
        ToRobotArmStopGetPos,
        ToSpawnerPosition,
        ToForwardSurface,
        ToForwardSurfaceTrack,
        ToLeftSurface,
        ToLeftSurfaceTrack,
        ToRightSurface,
        ToRightSurfaceTrack,
        ToDownSurface,
        ToDownSurfaceTrack,
        ToUpSurface,
        ToUpSurfaceTrack,
        ToUIRightUpdateTrack,
        ToUIRightData,
        TOUIOver,
    }
}

