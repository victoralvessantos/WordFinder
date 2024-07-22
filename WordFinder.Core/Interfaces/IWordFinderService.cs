using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Core.Interfaces
{
    public interface IWordFinderService
    {
        IEnumerable<string> Find(
            IEnumerable<string> matrix,
            IEnumerable<string> wordStream);
    }
}
