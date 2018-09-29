using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace zuzeTransalor
{
    class Read
    {           
        private string ReadText(string file)
        {
            StreamReader reader = new StreamReader(file);
            string data = reader.ReadToEnd();
            reader.Close();

            return data;
        }
    }
}
