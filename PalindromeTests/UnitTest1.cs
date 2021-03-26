using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;

namespace PalindromeTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestIsPalindrome()
		{
			string line;

			System.IO.StreamReader file = new System.IO.StreamReader(@"D:\Development\palindrome-kata\PalindromeTests\Palindromes.txt");
			while ((line = file.ReadLine()) != null)
			{
				bool result = PalindromeChecker.CheckString(line);
				Assert.IsTrue(result, string.Format("Expected for '{0}': true; Actual: {1}", line, result));
			}
			file.Close();
		}

		[TestMethod]
		public void TestIsNotPalindrome()
		{
			string line;

			System.IO.StreamReader file = new System.IO.StreamReader(@"D:\Development\palindrome-kata\PalindromeTests\NonPalindromes.txt");
			while ((line = file.ReadLine()) != null)
			{
				bool result = PalindromeChecker.CheckString(line);
				Assert.IsFalse(result, string.Format("Expected for '{0}': false; Actual: {1}", line, result));
			}
			file.Close();
		}

		[TestMethod]
		public void CallWithNullOrEmpty()
		{
			string[] words = { string.Empty, null };
			foreach (var word in words)
			{
				bool result = PalindromeChecker.CheckString(word);
				Assert.IsFalse(result, string.Format("Expected for '{0}': false; Actual: {1}", word == null ? "<null>" : word, result));
			}
		}
	}
}
