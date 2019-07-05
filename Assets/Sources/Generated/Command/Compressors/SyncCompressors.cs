using NetStack.Compression;

public static class CommandCompressors
{
	public static readonly BoundedRange ClientTestValueXCompressor;
		public static readonly BoundedRange ClientTestValueYCompressor;
		public static readonly BoundedRange ClientTestValueZCompressor;
		public static readonly BoundedRange ServerTestValueXCompressor;
		public static readonly BoundedRange ServerTestValueYCompressor;
		public static readonly BoundedRange ServerTestValueZCompressor;
	    
    static CommandCompressors()
    {
	    ClientTestValueXCompressor = new BoundedRange(-1, 1, 0.01f);
		    ClientTestValueYCompressor = new BoundedRange(-1, 1, 0.01f);
		    ClientTestValueZCompressor = new BoundedRange(-1, -1, 0.01f);
		    ServerTestValueXCompressor = new BoundedRange(-1, 1, 0.01f);
		    ServerTestValueYCompressor = new BoundedRange(-1, 1, 0.01f);
		    ServerTestValueZCompressor = new BoundedRange(-1, -1, 0.01f);
	    }
}