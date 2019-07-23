using System.Text;
using NetStack.Serialization;
using Sources.Tools;

public static class UnpackEntityUtility
{
    public static void CreateEntities(GameContext game, BitBuffer buffer, ushort entityCount)
    {
        for (int i = 0; i < entityCount; i++)
        {
            var e = game.CreateEntity();
            MakeEntity(e, buffer);
        }
    }
    public static void MakeEntity(GameEntity e, BitBuffer buffer)
    {
        var addedComponents = new StringBuilder(128);
        var componentsCount = buffer.ReadUShort();

            for (int j = 0; j < componentsCount; j++)
            {
                var componentId = buffer.ReadUShort();

                switch (componentId)
                {
                    case 0:
					{
					    addedComponents.Append(" Id ");
                        var lookup = GameComponentsLookup.Id;
						var comp = e.CreateComponent<IdComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 1:
					{
					    addedComponents.Append(" Position ");
                        var lookup = GameComponentsLookup.Position;
						var comp = e.CreateComponent<PositionComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 2:
					{
					    addedComponents.Append(" Direction ");
                        var lookup = GameComponentsLookup.Direction;
						var comp = e.CreateComponent<DirectionComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 3:
					{
					    addedComponents.Append(" Sprite ");
                        var lookup = GameComponentsLookup.Sprite;
						var comp = e.CreateComponent<SpriteComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 4:
					{
					    addedComponents.Append(" Mover ");
                        e.isMover = true;
					}
					    break;
                    case 5:
					{
					    addedComponents.Append(" Move ");
                        var lookup = GameComponentsLookup.Move;
						var comp = e.CreateComponent<MoveComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 6:
					{
					    addedComponents.Append(" LastMoveTick ");
                        var lookup = GameComponentsLookup.LastMoveTick;
						var comp = e.CreateComponent<LastMoveTickComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 7:
					{
					    addedComponents.Append(" MoverID ");
                        var lookup = GameComponentsLookup.MoverID;
						var comp = e.CreateComponent<MoverIDComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 8:
					{
					    addedComponents.Append(" Tick ");
                        var lookup = GameComponentsLookup.Tick;
						var comp = e.CreateComponent<TickComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 9:
					{
					    addedComponents.Append(" Ice ");
                        var lookup = GameComponentsLookup.Ice;
						var comp = e.CreateComponent<IceComponent>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 10:
					{
					    addedComponents.Append(" Character ");
                        e.isCharacter = true;
					}
					    break;
                    case 11:
					{
					    addedComponents.Append(" ControlledBy ");
                        var lookup = GameComponentsLookup.ControlledBy;
						var comp = e.CreateComponent<ControlledBy>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 12:
					{
					    addedComponents.Append(" Connection ");
                        var lookup = GameComponentsLookup.Connection;
						var comp = e.CreateComponent<Connection>(lookup);
						comp.Deserialize(buffer);
						e.AddComponent(lookup, comp);
					}
					    break;
                    case 13:
					{
					    addedComponents.Append(" Sync ");
                        e.isSync = true;
					}
					    break;
                }
            }
    }
	
	public static void ChangeComponents(GameContext game, BitBuffer buffer, ushort componentCount)
	{
		for (int i = 0; i < componentCount; i++)
		{
			var entityId    = buffer.ReadUShort();
			var componentId = buffer.ReadUShort();
			var e           = game.GetEntityWithId(entityId);

			switch (componentId)
			{
                    case 0:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Id component");
                        var lookup = GameComponentsLookup.Id;
						var comp = e.CreateComponent<IdComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 1:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Position component");
                        var lookup = GameComponentsLookup.Position;
						var comp = e.CreateComponent<PositionComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 2:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Direction component");
                        var lookup = GameComponentsLookup.Direction;
						var comp = e.CreateComponent<DirectionComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 3:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Sprite component");
                        var lookup = GameComponentsLookup.Sprite;
						var comp = e.CreateComponent<SpriteComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 4:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Mover component");
                        e.isMover = true;
					}
					    break;
                    case 5:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Move component");
                        var lookup = GameComponentsLookup.Move;
						var comp = e.CreateComponent<MoveComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 6:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed LastMoveTick component");
                        var lookup = GameComponentsLookup.LastMoveTick;
						var comp = e.CreateComponent<LastMoveTickComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 7:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed MoverID component");
                        var lookup = GameComponentsLookup.MoverID;
						var comp = e.CreateComponent<MoverIDComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 8:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Tick component");
                        var lookup = GameComponentsLookup.Tick;
						var comp = e.CreateComponent<TickComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 9:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Ice component");
                        var lookup = GameComponentsLookup.Ice;
						var comp = e.CreateComponent<IceComponent>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 10:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Character component");
                        e.isCharacter = true;
					}
					    break;
                    case 11:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed ControlledBy component");
                        var lookup = GameComponentsLookup.ControlledBy;
						var comp = e.CreateComponent<ControlledBy>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 12:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Connection component");
                        var lookup = GameComponentsLookup.Connection;
						var comp = e.CreateComponent<Connection>(lookup);
				        comp.Deserialize(buffer);
				        e.ReplaceComponent(lookup, comp);
					}
					    break;
                    case 13:
					{
						Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Changed Sync component");
                        e.isSync = true;
					}
					    break;
			}
		}
	}
	
	public static void RemoveComponents(GameContext game, BitBuffer buffer, ushort componentCount)
	{
		for (int i = 0; i < componentCount; i++)
		{
			var entityId = buffer.ReadUShort();
			var componentId = buffer.ReadUShort();
			var e = game.GetEntityWithId(entityId);

			switch (componentId)
			{
                    case 0:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Id component");
                        e.RemoveId();
					}
					    break;
                    case 1:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Position component");
                        e.RemovePosition();
					}
					    break;
                    case 2:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Direction component");
                        e.RemoveDirection();
					}
					    break;
                    case 3:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Sprite component");
                        e.RemoveSprite();
					}
					    break;
                    case 4:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Mover component");
                        e.isMover = false;
					}
					    break;
                    case 5:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Move component");
                        e.RemoveMove();
					}
					    break;
                    case 6:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed LastMoveTick component");
                        e.RemoveLastMoveTick();
					}
					    break;
                    case 7:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed MoverID component");
                        e.RemoveMoverID();
					}
					    break;
                    case 8:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Tick component");
                        e.RemoveTick();
					}
					    break;
                    case 9:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Ice component");
                        e.RemoveIce();
					}
					    break;
                    case 10:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Character component");
                        e.isCharacter = false;
					}
					    break;
                    case 11:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed ControlledBy component");
                        e.RemoveControlledBy();
					}
					    break;
                    case 12:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Connection component");
                        e.RemoveConnection();
					}
					    break;
                    case 13:
					{
					    Logger.I.Log("UnpackEntityUtility", $" Entity-{entityId}: Removed Sync component");
                        e.isSync = false;
					}
					    break;
			}
		}
	}
	
	public static void RemoveEntities(GameContext game, BitBuffer buffer, ushort entityCount)
	{
		for (int i = 0; i < entityCount; i++)
		{
			var id = buffer.ReadUShort();
			var e = game.GetEntityWithId(id);
            e.isDestroyed = true;
			Logger.I.Log("UnpackEntityUtility", $" Entity-{id}: is removed");
		}
	}
}