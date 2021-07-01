using System.Collections.Generic;
using System.IO;

namespace ProjetoInstaDev.Models
{
    public class Instadev_Base
    {
        public void CriarPastaEArquivo(string _caminho)
        {
            string folder = _caminho.Split("/")[0];
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }
        }

        public List<string> LerTodasAsLinhas(string CAMINHO)
        {

            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(CAMINHO))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        public void ReescrevaCSV(string CAMINHO, List<string> linhas)
        {
            using (StreamWriter output = new StreamWriter(CAMINHO))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
        public int GerarId(int id)
        {
            return id++;
        }
    }
}