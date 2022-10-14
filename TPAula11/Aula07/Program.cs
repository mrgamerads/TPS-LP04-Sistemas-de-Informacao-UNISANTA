using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Aula07
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("abril2017.txt");
            String linha;
            OcorrenciaPonto umaocorrencia = new OcorrenciaPonto();
            List<OcorrenciaPonto> ocorrencias = new List<OcorrenciaPonto>();
            int i = 0;

            while ((linha = file.ReadLine()) != null)
            {
                ocorrencias.Add(new OcorrenciaPonto());
                ocorrencias[i].prontuario = linha.Substring(0,15);
                ocorrencias[i].data = linha.Substring(15,6);
                ocorrencias[i].hora = linha.Substring(21,4);
                ocorrencias[i].filler = linha.Substring(25);
                ++i;
            }
            file.Close();

            TextWriter outfile = new StreamWriter("Abril2017.xml");
            XmlSerializer objs = new XmlSerializer(ocorrencias.GetType());
            objs.Serialize(outfile, ocorrencias);
            outfile.Close();
        }
    }
}
