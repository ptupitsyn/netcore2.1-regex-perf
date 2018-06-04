using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace regex_test
{
    public static class PackageProcessor
    {
        public static IList<string> GetPackageInfos(
            IEnumerable<string> packages,
            ICollection<Func<string, bool>> categories)
        {
            packages = packages ?? throw new ArgumentNullException(nameof(packages));
            categories = categories ?? throw new ArgumentNullException(nameof(categories));

            return packages.Select(package =>
            {
                var cats = categories.Where(c => c(package)).ToArray();

                if (cats.Any())
                {
                    return package;
                }

                return null;
            }).ToArray();
        }

        public static IList<Func<string, bool>> GetPackageCategories(IEnumerable<string> packageFilters)
        {
            packageFilters = packageFilters ?? throw new ArgumentNullException(nameof(packageFilters));

            return packageFilters.Select(GetPackageCategory).ToArray();
        }

        private static Func<string, bool> GetPackageCategory(string setting, int index)
        {
            return GetMatcher(setting);
        }

        private static Func<string, bool> GetMatcher(string packageNames)
        {
            var matchers = packageNames
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => GetSingleMatcher(x.Trim()))
                .ToArray();

            return s => matchers.Any(m => m(s));
        }

        private static Func<string, bool> GetSingleMatcher(string packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName))
            {
                return _ => false;
            }

            var placeholder = Regex.Escape("[VERSION]");
            var pattern = Regex.Escape(packageName).Replace(placeholder, @"[\d\.-]*");
            var regex = new Regex($"^{pattern}$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

            return s => regex.IsMatch(s);
        }
    }
}
