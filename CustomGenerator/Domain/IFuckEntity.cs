namespace Domain_Namespace
{
	using System;

	public interface IFuckEntity : IFuckEntityKey, IFuckEntityData {}

	public interface IFuckEntityKey 
	{
		int Id {get;}
	}

	public interface IFuckEntityData
	{
		string FirstName {get;}
string LastName {get;}
int SomethingValue {get;}

	}
}
