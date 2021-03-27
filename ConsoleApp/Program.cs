using System;
using Palindrome;

namespace ConsoleApp
{
	/// <summary>
	///	The Program class contains a method to perform the console communication
	/// </summary>
	class Program
	{
		// <summary>
		/// The Main method handles user input and prints the result to the console
		/// </summary>
		static void Main(string[] args)
		{
			Console.WriteLine("Enter a string: ");
			string s = Console.ReadLine();
			bool palindrome = PalindromeChecker.CheckString(s);
			Console.WriteLine();
			Console.WriteLine($"{string.Format("The string '{0}' is {1}a palindrome.", s, palindrome ? null : "not ")}");
			Console.WriteLine();
			Console.Write("Press any key to exit...");
			Console.ReadKey(true);
		}
	}
}
