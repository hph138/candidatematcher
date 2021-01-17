using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateMatcher.Content
{
    public class Matcher : IMatcher
    {
        public int CountMatches(string source, string target)
        {
            IEnumerable<string> src = GetDistinctList(source);
            IEnumerable<string> tar = GetDistinctList(target);
            return src.Count(w => tar.Contains(w));
        }

        private static IEnumerable<string> GetDistinctList(string source)
        {
            return source.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Where(s => s != string.Empty).Distinct();
        }
    }
}
