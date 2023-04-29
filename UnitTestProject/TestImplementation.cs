namespace UnitTestProject
{
    public class TestImplementation : ITestImplementation
    {
        public int CountUniqueUrls(string[] urls)
        {
            try
            {
                // Remove duplicates and normalize the URLs
                var normalizedUrls = urls.Select(url => NormalizeUrl(url)).Distinct();
                return normalizedUrls.Count();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and log the error
                Console.WriteLine("Error in CountUniqueUrls: " + ex.Message);
                return -1;
            }
        }

        public Dictionary<string, int> CountUniqueUrlsPerTopLevelDomain(string[] urls)
        {
            try
            {
                // Group the URLs by top-level domain and count them
                var groups = urls.GroupBy(url => GetTopLevelDomain(url))
                                 .ToDictionary(group => group.Key, group => group.Count());
                return groups;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and log the error
                Console.WriteLine("Error in CountUniqueUrlsPerTopLevelDomain: " + ex.Message);
                return null;
            }
        }

        // This function normalizes a URL by removing authentication information, trailing slashes,
        // and sorting query parameters
        private string NormalizeUrl(string url)
        {
            // Remove authentication information, trailing slashes, and sort query parameters
            Uri uri = new Uri(url);
            string normalizedUrl = uri.GetLeftPart(UriPartial.Path);
            if (normalizedUrl.EndsWith("/"))
            {
                normalizedUrl = normalizedUrl.Remove(normalizedUrl.Length - 1);
            }
            var parameters = uri.Query.TrimStart('?').Split('&');
            if (parameters.Length > 0)
            {
                normalizedUrl += "?" + string.Join("&", parameters.OrderBy(p => p));
            }
            return normalizedUrl;
        }

        // This function extracts the top-level domain (TLD) from a URL
        private string GetTopLevelDomain(string url)
        {
            // Get the top-level domain (TLD) of the URL
            Uri uri = new Uri(url);
            string[] segments = uri.Host.Split('.');
            if (segments.Length < 2)
            {
                throw new ArgumentException("Invalid URL: " + url);
            }
            return segments[segments.Length - 2] + "." + segments[segments.Length - 1];
        }
    }
}