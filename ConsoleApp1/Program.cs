using CustomGenerator;
using System;
using System.IO;
using System.Resources;
using System.Xml;

namespace ConsoleApp1
{
	public class Program
	{
		static void Main(string[] args)
		{
			var gen = new Generator();

			gen.GenerateCustom();

			Console.ReadKey();
		}
	}
}
