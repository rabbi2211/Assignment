using Assignment.Data.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Contracts
{
    interface IFileProcessor
    {
        void ReadFile(string path);
        List<STORE_ORDER> ReadFile(StreamReader reader);

    }
}
