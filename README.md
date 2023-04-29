# UnitTest

This is a C# implementation of a URL normalizer that removes duplicates, normalizes the URLs and groups them by top-level domain.

Prerequisites: To run this program, you'll need:

.NET Core 3.1 or later
Visual Studio 2019 or later

Installation: To install the program, follow these steps:

Clone the repository: git clone https://github.com/UmutCB/UnitTest
Open the solution in Visual Studio
Build the solution

Usage: To use the program, follow these steps:

Create an instance of the TestImplementation class
Call the CountUniqueUrls method to count the unique URLs
Call the CountUniqueUrlsPerTopLevelDomain method to count the unique URLs per top-level domain

Examples: Here's an example of how to use the program:
"
using System;
using System.Collections.Generic;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var implementation = new TestImplementation();
            var urls = new string[]
            {
                "https://example.com",
                "https://example.com/",
                "https://example.com?a=1&b=2",
                "https://example.com?b=2&a=1",
                "http://example.com"
            };

            var count = implementation.CountUniqueUrls(urls);
            Console.WriteLine($"Number of unique URLs: {count}");

            var countPerTld = implementation.CountUniqueUrlsPerTopLevelDomain(urls);
            foreach (var kvp in countPerTld)
            {
                Console.WriteLine($"Top-level domain: {kvp.Key}, Count: {kvp.Value}");
            }
        }
    }
}
"

Tests: The program includes unit tests using Xunit. To run the tests, simply open the Test Explorer in Visual Studio and run all tests. The tests cover the following scenarios:


CountUniqueUrls_Returns_Correct_Count: Tests that the CountUniqueUrls method returns the correct count of unique URLs
CountUniqueUrlsPerTopLevelDomain_Returns_Correct_Count: Tests that the CountUniqueUrlsPerTopLevelDomain method returns the correct count of unique URLs per top-level domain
CountUniqueUrls_Throws_Exception_For_Invalid_Url: Tests that the CountUniqueUrls method throws an exception for an invalid URL

License: This program is licensed under the MIT License. See the LICENSE file for details.
