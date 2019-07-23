





using NetStack.Compression;

public static class CommandCompressors
{

	public static readonly BoundedRange ClientCreateBeePositionXCompressor;
	
	public static readonly BoundedRange ClientCreateBeePositionYCompressor;
	
	public static readonly BoundedRange ClientCreateBeePositionZCompressor;
	
	public static readonly BoundedRange ClientCreateBeeDirectionCompressor;
	
	public static readonly BoundedRange ClientTestValueXCompressor;
	
	public static readonly BoundedRange ClientTestValueYCompressor;
	
	public static readonly BoundedRange ClientTestValueZCompressor;
	
	public static readonly BoundedRange ServerTestValueXCompressor;
	
	public static readonly BoundedRange ServerTestValueYCompressor;
	
	public static readonly BoundedRange ServerTestValueZCompressor;
	
    
    static CommandCompressors()
    {

	    ClientCreateBeePositionXCompressor = new BoundedRange(-100, 100, 0.0001f);
	
	    ClientCreateBeePositionYCompressor = new BoundedRange(-100, 100, 0.0001f);
	
	    ClientCreateBeePositionZCompressor = new BoundedRange(-100, 100, 0.0001f);
	
	    ClientCreateBeeDirectionCompressor = new BoundedRange(0, 360, 1f);
	
	    ClientTestValueXCompressor = new BoundedRange(-1, 1, 0.01f);
	
	    ClientTestValueYCompressor = new BoundedRange(-1, 1, 0.01f);
	
	    ClientTestValueZCompressor = new BoundedRange(-1, -1, 0.01f);
	
	    ServerTestValueXCompressor = new BoundedRange(-1, 1, 0.01f);
	
	    ServerTestValueYCompressor = new BoundedRange(-1, 1, 0.01f);
	
	    ServerTestValueZCompressor = new BoundedRange(-1, -1, 0.01f);
	
    }
}