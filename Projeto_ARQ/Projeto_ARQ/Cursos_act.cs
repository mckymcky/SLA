using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ARQ
{
    internal class Cursos_act
    {
        public void SalvarCursosEmCsv()
        {
            string caminho = caminhoBanco + nomeBancoCursos;
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

        private List<Curso> CarregarCursosDoCsv(string caminho)
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
        private Curso itemCurso;

        private string caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
        private string nomeBancoCursos = ConfigurationManager.AppSettings["nomeBancoCursos"];

        public Cursos_act() {

            bancoCursos = CarregarCursosDoCsv(caminhoBanco + nomeBancoCursos);

        }

        public void inserir(Curso curso)
        {
            itemCurso = new Curso();
            itemCurso.cursoid = curso.cursoid;
            itemCurso.cursonome = curso.cursonome;
            itemCurso.cursosig = curso.cursosig;
            itemCurso.cursoobs = curso.cursoobs;

            bancoCursos.Add(curso);
        }

        public void alterar(string sigla, Curso curso)
        {

            foreach (var item in bancoCursos)
            {
                if (item.cursosig == sigla.ToString().Trim())
                {
                    item.cursosig = curso.cursosig;
                    item.cursonome = curso.cursonome;
                    item.cursoobs = curso.cursoobs;
                    break;
                }
            }
        }

        public void excluir(string sigla)
        {
            foreach (var item in bancoCursos)
            {
                if (item.cursosig == sigla.ToString().Trim())
                {
                    bancoCursos.Remove(item);
                    break;
                }
            }
        }

        public void pesquisar(string sigla)
        {
            foreach (var item in bancoCursos)
            {
                if (item.cursosig == sigla.ToString().Trim())
                {
                    Console.WriteLine(item.cursoid.ToString()
                        + " - " + item.cursonome.ToString()
                        + " - " + (item.cursosig.ToString()
                        + " - " + (item.cursoobs.ToString())));
                    break;
                }
            }
        }

        public void exibirTodos()
        {
            foreach (var item in bancoCursos)
            {
                Console.WriteLine(item.cursoid.ToString()
                    + " - " + item.cursonome.ToString()
                    + " - " + (item.cursosig.ToString()
                    + " - " + (item.cursoobs.ToString())));
            }
        }


    }
}
