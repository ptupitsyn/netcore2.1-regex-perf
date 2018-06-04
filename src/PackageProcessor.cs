using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace regex_test
{
    public static class PackageProcessor
    {
        public static IEnumerable<(TimeSpan, Regex, int)> GetPackageInfos(
            ICollection<string> packages,
            ICollection<Regex> categories)
        {
            packages = packages ?? throw new ArgumentNullException(nameof(packages));
            categories = categories ?? throw new ArgumentNullException(nameof(categories));

            var sw = Stopwatch.StartNew();
            foreach (var category in categories)
            {
                var count = 0;
                sw.Restart();

                foreach (var package in packages)
                {
                    if (category.IsMatch(package))
                    {
                        count++;
                    }
                }

                yield return (sw.Elapsed, category, count);
            }
        }

        public static int GetPackageInfos2(
            ICollection<string> packages,
            ICollection<Regex> categories)
        {
            var count = 0;

            // Reordering these loops makes a huge difference.
            foreach (var package in packages)
            {
                foreach (var category in categories)
                {
                    if (category.IsMatch(package))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static IList<Regex> GetPackageCategories(IEnumerable<string> packageFilters)
        {
            return packageFilters.Select(GetRegex).ToArray();
        }

        private static Regex GetRegex(string packageName)
        {
            var placeholder = Regex.Escape("[VERSION]");
            var pattern = Regex.Escape(packageName).Replace(placeholder, @"[\d\.-]*");
            var regex = new Regex($"^{pattern}$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

            return regex;
        }
    }
}
