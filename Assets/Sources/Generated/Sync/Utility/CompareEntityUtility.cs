using NetStack.Serialization;


public static class CompareEntityUtility
{
    public static bool Equals(GameEntity entityA, GameEntity entityB, BitBuffer bufferA, BitBuffer bufferB)
    {
		void Clear()
	    {
		    bufferA.Clear();
		    bufferB.Clear();
	    }
		Clear();
		if(entityA.hasPosition&&entityB.hasPosition)	
		{
			entityA.position.Serialize(bufferA);
			entityB.position.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasPosition&&!entityA.hasPosition)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.hasDirection&&entityB.hasDirection)	
		{
			entityA.direction.Serialize(bufferA);
			entityB.direction.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasDirection&&!entityA.hasDirection)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.hasSprite&&entityB.hasSprite)	
		{
			entityA.sprite.Serialize(bufferA);
			entityB.sprite.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasSprite&&!entityA.hasSprite)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.isMover != entityB.isMover)	
		{
			return false;	
		}
		Clear();
		if(entityA.hasMove&&entityB.hasMove)	
		{
			entityA.move.Serialize(bufferA);
			entityB.move.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasMove&&!entityA.hasMove)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.hasLastMoveTick&&entityB.hasLastMoveTick)	
		{
			entityA.lastMoveTick.Serialize(bufferA);
			entityB.lastMoveTick.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasLastMoveTick&&!entityA.hasLastMoveTick)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.hasMoverID&&entityB.hasMoverID)	
		{
			entityA.moverID.Serialize(bufferA);
			entityB.moverID.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasMoverID&&!entityA.hasMoverID)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.hasTick&&entityB.hasTick)	
		{
			entityA.tick.Serialize(bufferA);
			entityB.tick.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasTick&&!entityA.hasTick)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.hasIce&&entityB.hasIce)	
		{
			entityA.ice.Serialize(bufferA);
			entityB.ice.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasIce&&!entityA.hasIce)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.isCharacter != entityB.isCharacter)	
		{
			return false;	
		}
		Clear();
		if(entityA.hasControlledBy&&entityB.hasControlledBy)	
		{
			entityA.controlledBy.Serialize(bufferA);
			entityB.controlledBy.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasControlledBy&&!entityA.hasControlledBy)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.hasConnection&&entityB.hasConnection)	
		{
			entityA.connection.Serialize(bufferA);
			entityB.connection.Serialize(bufferB);
			if(!bufferA.Equals(bufferB))
			{
				return false;
			}
		}
		else if(!entityA.hasConnection&&!entityA.hasConnection)
		{
		}
		else
		{
			return false;
		}
		Clear();
		if(entityA.isSync != entityB.isSync)	
		{
			return false;	
		}
		return true;

	}
}
