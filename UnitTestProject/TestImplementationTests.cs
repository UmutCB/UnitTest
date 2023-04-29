using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestProject
{
    public class TestImplementationTests
    {
        // Test for CountUniqueUrls method
        [Fact]
        public void CountUniqueUrls_Returns_Correct_Count()
        {
            // Arrange
            var implementation = new TestImplementation();
            var urls = new string[]
            {
                "https://example.com",
                "https://example.com/",
                "https://example.com?a=1&b=2",
                "https://example.com?b=2&a=1",
                "http://example.com"
            };

            // Act
            var count = implementation.CountUniqueUrls(urls);

            // Assert
            Assert.Equal(2, count);
        }

        // Test for CountUniqueUrlsPerTopLevelDomain method
        [Fact]
        public void CountUniqueUrlsPerTopLevelDomain_Returns_Correct_Count()
        {
            // Arrange
            var implementation = new TestImplementation();
            var urls = new string[]
            {
                "https://example.com",
                "https://example.com/",
                "https://subdomain.example.com",
                "https://test.example.com",
                "https://test.test.com"
            };

            // Act
            var countPerTld = implementation.CountUniqueUrlsPerTopLevelDomain(urls);

            // Assert
            Assert.Equal(2, countPerTld["example.com"]);
            Assert.Equal(1, countPerTld["test.com"]);
        }

        // Test for invalid URL input
        [Fact]
        public void CountUniqueUrls_Throws_Exception_For_Invalid_Url()
        {
            // Arrange
            var implementation = new TestImplementation();
            var urls = new string[]
            {
                "https://example.com",
                "https://invalid_url"
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                try
                {
                    // Invoke the method that may throw exception
                    implementation.CountUniqueUrls(urls);
                }
                catch (Exception e)
                {
                    // Ensure the correct exception type is thrown
                    Assert.IsType<ArgumentException>(e);
                    throw;
                }
            });
        }
    }
}