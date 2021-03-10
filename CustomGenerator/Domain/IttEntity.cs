namespace Domain_Namespace
{
	using System;

	public interface IttEntity : IttEntityKey, IttEntityData {}

	public interface IttEntityKey 
	{
		int Id {get;}
	}

	public interface IttEntityData
	{
		string Name {get;}
bool IsExists {get;}

	}
}
