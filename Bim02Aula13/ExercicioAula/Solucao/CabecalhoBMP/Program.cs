using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace CabecalhoBMP
{
    class Program
    {
        static int converteBinDec(String _s)
        {
            BitArray original = new BitArray(Encoding.Default.GetBytes(_s));
            String binario = "";

            for (int i = original.Count - 1; i >= 0; i--) binario += Convert.ToInt32(original[i]);
            return Convert.ToInt32(binario,2);
        }
        static void Main(string[] args)
        {
            FileStream infile;
            String cabecarq = "";

            infile = new System.IO.FileStream("imagem.bmp",FileMode.Open,FileAccess.Read);

            for (int i = 0; i < 14; ++i) cabecarq +=(char)infile.ReadByte();

            CabecalhoArquivo.tipo = cabecarq.Substring(0, 2);
            CabecalhoArquivo.tamarquivo = converteBinDec(cabecarq.Substring(2, 4));
            CabecalhoArquivo.reservado1 = cabecarq.Substring(6, 2);
            CabecalhoArquivo.reservado2 = cabecarq.Substring(8, 2);
            CabecalhoArquivo.tamcabec = converteBinDec(cabecarq.Substring(10, 4));

            Console.WriteLine("Tipo = " + CabecalhoArquivo.tipo);
            Console.WriteLine("Tamanho Arquivo = " + CabecalhoArquivo.tamarquivo + " bytes ou " + (float)CabecalhoArquivo.tamarquivo / 1024 + " KB.");
            Console.WriteLine("Reservado1 = " + CabecalhoArquivo.reservado1);
            Console.WriteLine("Reservado2 = " + CabecalhoArquivo.reservado2);
            Console.WriteLine("Tamanho Cabeçalho = " + CabecalhoArquivo.tamcabec + " bytes.");
            Console.WriteLine("Tamanho da Imagem = " + (CabecalhoArquivo.tamarquivo - CabecalhoArquivo.tamcabec) + " bytes.");

            cabecarq = "";
            for(int i = 0; i < 40; i++) cabecarq +=(char)infile.ReadByte();

            CabecalhoDoisArquivo.tamanhocab = converteBinDec(cabecarq.Substring(0, 4));
            CabecalhoDoisArquivo.larguraimg = converteBinDec(cabecarq.Substring(4, 4));
            CabecalhoDoisArquivo.alturaimg = converteBinDec(cabecarq.Substring(8, 4));
            CabecalhoDoisArquivo.numplanos = converteBinDec(cabecarq.Substring(12, 2));
            CabecalhoDoisArquivo.qtdbitspixel = converteBinDec(cabecarq.Substring(14, 2));
            CabecalhoDoisArquivo.bitscompress = converteBinDec(cabecarq.Substring(16, 4));
            CabecalhoDoisArquivo.tamanhoimg = converteBinDec(cabecarq.Substring(20, 4));
            CabecalhoDoisArquivo.resolhoriz = converteBinDec(cabecarq.Substring(24, 4));
            CabecalhoDoisArquivo.resolverti = converteBinDec(cabecarq.Substring(28, 4));
            CabecalhoDoisArquivo.numcores = converteBinDec(cabecarq.Substring(32, 4));
            CabecalhoDoisArquivo.numcoresimp = converteBinDec(cabecarq.Substring(36, 4));

            Console.WriteLine("Tamanho Cabecalho = " + CabecalhoDoisArquivo.tamanhocab);
            Console.WriteLine("Largura Imagem = " + CabecalhoDoisArquivo.larguraimg);
            Console.WriteLine("Altura Imagem = " + CabecalhoDoisArquivo.alturaimg);
            Console.WriteLine("Numero de Planos = " + CabecalhoDoisArquivo.numplanos);
            Console.WriteLine("Quantidade de Bits por Pixel = " + CabecalhoDoisArquivo.qtdbitspixel);
            Console.WriteLine("Compressão de Bits = " + CabecalhoDoisArquivo.bitscompress);
            Console.WriteLine("Tamanho da Imagem = " + CabecalhoDoisArquivo.tamanhoimg);
            Console.WriteLine("Resolução Horizontal = " + CabecalhoDoisArquivo.resolhoriz);
            Console.WriteLine("Resolução Vertical = " + CabecalhoDoisArquivo.resolverti);
            Console.WriteLine("Numero de Cores = " + CabecalhoDoisArquivo.numcores);
            Console.WriteLine("Numero de Cores Importantes = " + CabecalhoDoisArquivo.numcoresimp);

            infile.Close();
            Console.ReadKey();
        }
    }
}
