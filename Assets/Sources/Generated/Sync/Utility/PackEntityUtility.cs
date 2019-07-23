using NetStack.Serialization;

public static class PackEntityUtility
{
    public static void Pack(GameEntity e, BitBuffer buffer)
    {
		ushort counter = 0;

		var hasId = false;
        if(e.hasId)
		{
			hasId = true;
			counter++;
		}

			var hasPosition = false;
        if(e.hasPosition)
		{
			hasPosition = true;
			counter++;
		}

			var hasDirection = false;
        if(e.hasDirection)
		{
			hasDirection = true;
			counter++;
		}

			var hasSprite = false;
        if(e.hasSprite)
		{
			hasSprite = true;
			counter++;
		}

			var hasMover = false;
        if(e.isMover)
		{
			hasMover = true;
			counter++;
		}

			var hasMove = false;
        if(e.hasMove)
		{
			hasMove = true;
			counter++;
		}

			var hasLastMoveTick = false;
        if(e.hasLastMoveTick)
		{
			hasLastMoveTick = true;
			counter++;
		}

			var hasMoverID = false;
        if(e.hasMoverID)
		{
			hasMoverID = true;
			counter++;
		}

			var hasTick = false;
        if(e.hasTick)
		{
			hasTick = true;
			counter++;
		}

			var hasIce = false;
        if(e.hasIce)
		{
			hasIce = true;
			counter++;
		}

			var hasCharacter = false;
        if(e.isCharacter)
		{
			hasCharacter = true;
			counter++;
		}

			var hasControlledBy = false;
        if(e.hasControlledBy)
		{
			hasControlledBy = true;
			counter++;
		}

			var hasConnection = false;
        if(e.hasConnection)
		{
			hasConnection = true;
			counter++;
		}

			var hasSync = false;
        if(e.isSync)
		{
			hasSync = true;
			counter++;
		}

	
		buffer.AddUShort(counter);

        if (hasId)
        {
            e.id.Serialize(buffer);
        }

	        if (hasPosition)
        {
            e.position.Serialize(buffer);
        }

	        if (hasDirection)
        {
            e.direction.Serialize(buffer);
        }

	        if (hasSprite)
        {
            e.sprite.Serialize(buffer);
        }

	        if (hasMover)
        {
            buffer.AddUShort(4);
        }

	        if (hasMove)
        {
            e.move.Serialize(buffer);
        }

	        if (hasLastMoveTick)
        {
            e.lastMoveTick.Serialize(buffer);
        }

	        if (hasMoverID)
        {
            e.moverID.Serialize(buffer);
        }

	        if (hasTick)
        {
            e.tick.Serialize(buffer);
        }

	        if (hasIce)
        {
            e.ice.Serialize(buffer);
        }

	        if (hasCharacter)
        {
            buffer.AddUShort(10);
        }

	        if (hasControlledBy)
        {
            e.controlledBy.Serialize(buffer);
        }

	        if (hasConnection)
        {
            e.connection.Serialize(buffer);
        }

	        if (hasSync)
        {
            buffer.AddUShort(13);
        }

		}
}
