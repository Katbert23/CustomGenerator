namespace Domain_Namespace
{
	using System;

	public interface IEmployee : IEmployeeKey, IEmployeeData {}

	public interface IEmployeeKey 
	{
		int Id {get;}
	}

	public interface IEmployeeData
	{
		string FirstName {get;}
string LastName {get;}
string SecondName {get;}
int SomethingValue {get;}

	}
}
