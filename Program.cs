using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefOutExample
{
	class Program
	{
		public static void GetValue(string word)
		{
			word = "Rocky Road";
			Console.WriteLine($"Inside the GetValue method the word is: {word}");
		}

		public static void PassByReference(ref string wordRef)
		{
			wordRef = "Cookie Dough";
			Console.WriteLine($"Inside the PassByReference method the word is: {wordRef}");
			/*
				What is the 'ref' keyword? When a ref parameter is passed, it is passed by reference, not by value.
				This means you can assign the actual value of the parameter is changed at the calling site.
			*/
		}

		public static void AssignOutValue(out string wordOut)
		{
			//When using 'out' the argument passed in MUST be initialized inside the method.
			wordOut = "Mississipi Mud";
			Console.WriteLine($"Inside the AssignOutValue() method, the value of wordOut is: {wordOut}");

			/*
				 As defined by https://www.dotnetperls.com/out  
				 Out: This C# keyword signifies a reference parameter. Sometimes methods must return more than one value and not store class state.
				 Out, a keyword, fills these requirements. With it we pass parameters whose changes are realized in their calling methods. In a method, an out argument must be assigned.
			*/
		}

		public static void AddListItems(List<int> numbers)
		{
			for (int i = 0; i < 3; i++)
			{
				numbers.Add(i);
			}
		}

		static void Main(string[] args)
		{
			//The thing about passing primitive types as arguments is, you're passing a copy, not the actual value.
			string word = "Vanilla";
			Console.WriteLine($"Before calling the GetValue method, the word is: {word}");
			GetValue(word);
			Console.WriteLine($"After GetValue is called, the word is: {word}");
			Console.WriteLine();

			//To change the default behavior, and change the original values with a method call, 
			//use 'ref' and 'out' keywords in the method signatures and when passing the argument

			//Noteworthy note: When using 'ref', the variable MUST be initialized before passing as an argument.
			string wordRef = "Strawberry";
			Console.WriteLine($"Before calling PassByReference() the wordRef value is: {wordRef}");
			PassByReference(ref wordRef);
			Console.WriteLine($"After calling PassByReference() the wordRef value is: {wordRef}");
			Console.WriteLine();

			//Noteworthy note: When using 'out': the variable does not need to be initialized before being passed as an argument.
			string wordOut = string.Empty;
			Console.WriteLine($"Before calling AssignOutValue(), the wordOut value is: {wordOut}");
			AssignOutValue(out wordOut);
			Console.WriteLine($"After calling AssignOutValue(), the wordOut value is: {wordOut}");
			Console.WriteLine();

			//Since a List<T> is not a primitive type in C#, it's default behavior is to be passed as a reference.
			List<int> myIntList = new List<int>();
			Console.WriteLine($"The number of list items before calling AddListItems() is: {myIntList.Count}");
			AddListItems(myIntList);
			Console.WriteLine($"The number of list items after calling AddListItems() is: {myIntList.Count}");

			Console.ReadKey();

			
		}
	}
}
