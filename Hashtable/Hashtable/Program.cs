// See https://aka.ms/new-console-template for more information
using Hashtable;
using HashtableTester;
using System.Diagnostics.CodeAnalysis;


var Test = new HashDictionary<int, int>();

// Kör testerna med din hashtabellinstans
HashtableTester.TestDriver.Instance.Run(Test, 10000);