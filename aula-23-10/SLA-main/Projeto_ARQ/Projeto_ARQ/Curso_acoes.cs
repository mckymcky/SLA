using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ARQ
{
    internal class Curso_acoes
    {
        private static void SalvarCursosEmCsv(List<Curso> bancoCursos, string caminho)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("cursoid,cursonome,cursosig,cursoobs");

                    foreach (var item in bancoCursos)
                    {
                        writer.WriteLine(
                            $"{item.cursoid},{item.cursonome},{item.cursosig},{item.cursoobs}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro" + ex.Message);
            }
        }

        private static List<Curso> CarregarCursosDoCsv(string caminho)
        {
            var cursos = new List<Curso>();

            try
            {
                if (File.Exists(caminho) == true)
                {
                    using (StreamReader reader = new StreamReader(caminho))
                    {
                        string linha = reader.ReadLine();
                        while ((linha = reader.ReadLine()) != null)
                        {
                            var partes = linha.Split(',');
                            if (partes.Length == 4)
                            {
                                int cursoid = int.Parse(partes[0]);
                                string cursonome = partes[1];
                                string cursosig = partes[2];
                                string cursoobs = partes[3];
                                cursos.Add(new Curso
                                {
                                    cursoid = cursoid,
                                    cursonome = cursonome,
                                    cursosig = cursosig,
                                    cursoobs = cursoobs
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro" + ex.Message); throw;
            }
            return cursos;
        }

        private List<Curso> bancoCursos = new List<Curso>();
        private Curso curso;
        private string caminhoBanco;
        private string nomeBancoCursos;
        private string caminhoDoArquivo;

        public Cursos_acoes() {

            caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            nomeBancoCursos = ConfigurationManager.AppSettings["nomeBancoCursos"];
            caminhoDoArquivo = caminhoBanco + nomeBancoCursos;

            bancoCursos = CarregarCursosDoCsv(caminhoBanco + nomeBancoCursos);

        }

        public void inserir(Curso curso)
        { 
        
        }

        public void alterar(string sigla, Curso curso)
        {

        }

        public void excluir(string sigla)
        {

        }


    }
}
