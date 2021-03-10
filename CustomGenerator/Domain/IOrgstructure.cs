namespace Domain_Namespace
{
	using System;

	public interface IOrgstructure : IOrgstructureKey, IOrgstructureData {}

	public interface IOrgstructureKey 
	{
		int Id {get;}
	}

	public interface IOrgstructureData
	{
		IEmployee Employee {get;}

	}
}
