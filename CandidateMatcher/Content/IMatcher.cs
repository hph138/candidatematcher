using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateMatcher.Content
{
     public interface IMatcher
    {
         int CountMatches(string source, string target);
    }
}
