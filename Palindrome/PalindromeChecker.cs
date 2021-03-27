using System;
using System.Text.RegularExpressions;

namespace Palindrome
{
	/// <summary>
	///	The PalindromeChecker class contains methods to check if a sentence or a word is a palindrome
	/// </summary>
	public class PalindromeChecker
	{
		/// <summary>
		/// The CheckString method checks whether the string is a palindrome
		/// </summary>
		/// <param name="s">A string representing the sentence or word to check</param>
		/// <returns>True if s is a palindrome or false if it's not</returns>
		public static bool CheckString(string s)
		{
			if (!string.IsNullOrEmpty(s))
			{
				s = Clean(s);
				string reverse = Reverse(s);
				if (reverse == s) return true;
			};
			return false;
		}

		/// <summary>
		/// The Clean method converts a string to lowercase and removes all non-word characters
		/// </summary>
		/// <param name="s">The string to clean up</param>
		/// <returns>Lowercase string without non-word characters</returns>
		static string Clean(string s)
		{
			s = s.ToLower();
			s = Regex.Replace(s, @"[^\w]", ""); // Remove everything that's not a word character
			return s;
		}

		/// <summary>
		/// The Reverse method inverts the given string
		/// </summary>
		/// <param name="s">The string to invert</param>
		/// <returns>The reversed string</returns>
		static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
