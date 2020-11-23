using System.Collections;
using System.Collections.Generic;

namespace ApplicationCoreInterface.Services
{
    public interface IImporterService
    {
        IEnumerable<string> GetNames();
        void Import(string importer, string filePath);
    }
}