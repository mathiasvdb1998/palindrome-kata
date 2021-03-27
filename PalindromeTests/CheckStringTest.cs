using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;

namespace PalindromeTests
{
	[TestClass]
	public class CheckStringTest
	{

		/// <summary>
		/// Method to read all lines in a file and returns these lines one by one
		/// </summary>
		/// <param name="path">The path to the file</param>
		/// <returns>IEnumerable of all lines</returns>	
		private static IEnumerable<string[]> GetData(string path)
		{
			IEnumerable<string> rows = File.ReadAllLines(path);
			foreach (string row in rows)
			{
				List<string> rowData = new List<string>();
				rowData.Add(row);
				yield return rowData.ToArray();
			}
		}

		/// <summary>
		/// Method to get all valid palindromes
		/// </summary>
		/// <returns>IEnumerable with all valid palindromes</returns>
		private static IEnumerable<string[]> GetValidPalindromes()
		{
			return GetData(@"Data/Palindromes.txt");
		}

		/// <summary>
		/// Method to get all invalid palindromes
		/// </summary>
		/// <returns>IEnumerable with all invalid palindromes</returns>
		private static IEnumerable<string[]> GetInvalidPalindromes()
		{
			return GetData(@"Data/NonPalindromes.txt");
		}

		/// <summary>
		/// DynamicData property with values null and String.Empty
		/// </summary>
		public static IEnumerable<string[]> NullEmptyData
		{
			get
			{
				yield return new string[] { null };
				yield return new string[] { String.Empty };
			}
		}

		/// <summary>
		/// Method to test all valid palindromes
		/// </summary>
		/// <param name="candidate">Candidate string to test</param>
		[DataTestMethod]
		[DynamicData(nameof(GetValidPalindromes), DynamicDataSourceType.Method)]
		public void TestIsPalindrome(string candidate)
		{
			bool result = PalindromeChecker.CheckString(candidate);
			Assert.IsTrue(result, String.Format("Expected for '{0}': true; Actual: {1}", candidate, result));
		}

		/// <summary>
		/// Method to test all invalid palindromes
		/// </summary>
		/// <param name="candidate">Candidate string to test</param>
		[DataTestMethod]
		[DynamicData(nameof(GetInvalidPalindromes), DynamicDataSourceType.Method)]
		public void TestIsNotPalindrome(string candidate)
		{
			bool result = PalindromeChecker.CheckString(candidate);
			Assert.IsFalse(result, String.Format("Expected for '{0}': false; Actual: {1}", candidate, result));
		}

		/// <summary>
		/// Method to test null and an empty string
		/// </summary>
		/// <param name="candidate">Candidate string to test</param>
		[DataTestMethod]
		[DynamicData(nameof(NullEmptyData), DynamicDataSourceType.Property)]
		public void CallWithNullOrEmpty(string candidate)
		{
			bool result = PalindromeChecker.CheckString(candidate);
			Assert.IsFalse(result, String.Format("Expected for '{0}': false; Actual: {1}", candidate == null ? "<null>" : candidate, result));
		}
	}
}
