using System.Collections.Generic;
using Importers.Models;

namespace Importers
{
    public interface ILodgingImporter
    {
        IEnumerable<LodgingParserModel> Parse(string filePath);
    }
}