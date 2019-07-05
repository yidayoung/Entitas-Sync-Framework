using Sources.Networking.Server.StateCapture;

public class ServerStateCaptureFeature : Feature
{
    public ServerStateCaptureFeature(Contexts contexts, Services services)
    {
        Add(new ServerCaptureChangedIdSystem(contexts, services));
        Add(new ServerCaptureRemovedIdSystem(contexts, services));
        Add(new ServerCaptureChangedPositionSystem(contexts, services));
        Add(new ServerCaptureRemovedPositionSystem(contexts, services));
        Add(new ServerCaptureChangedDirectionSystem(contexts, services));
        Add(new ServerCaptureRemovedDirectionSystem(contexts, services));
        Add(new ServerCaptureChangedSpriteSystem(contexts, services));
        Add(new ServerCaptureRemovedSpriteSystem(contexts, services));
        Add(new ServerCaptureChangedMoverSystem(contexts, services));
        Add(new ServerCaptureRemovedMoverSystem(contexts, services));
        Add(new ServerCaptureChangedMoveSystem(contexts, services));
        Add(new ServerCaptureRemovedMoveSystem(contexts, services));
        Add(new ServerCaptureChangedMoverIDSystem(contexts, services));
        Add(new ServerCaptureRemovedMoverIDSystem(contexts, services));
        Add(new ServerCaptureChangedCharacterSystem(contexts, services));
        Add(new ServerCaptureRemovedCharacterSystem(contexts, services));
        Add(new ServerCaptureChangedControlledBySystem(contexts, services));
        Add(new ServerCaptureRemovedControlledBySystem(contexts, services));
        Add(new ServerCaptureChangedConnectionSystem(contexts, services));
        Add(new ServerCaptureRemovedConnectionSystem(contexts, services));
        Add(new ServerCaptureChangedSyncSystem(contexts, services));
        Add(new ServerCaptureRemovedSyncSystem(contexts, services));

	    Add(new ServerCreateWorldStateSystem(contexts));
        Add(new ServerCaptureCreatedEntitiesSystem(contexts, services));
        Add(new ServerCaptureRemovedEntitiesSystem(contexts, services));
	}
}