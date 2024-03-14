using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presale.Data
{
    internal class FileLoader
    {
        public void Load(OpenFileDialog ofd) 
        {
            string[] files = ofd.FileNames;
            foreach (var file in files)
            {

            }
        }
    }
}
