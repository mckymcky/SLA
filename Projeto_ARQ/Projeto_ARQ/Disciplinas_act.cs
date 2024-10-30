using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ARQ
{
    internal class Disciplinas_act
    {
        public void SalvarDisciplinasEmCsv()
        {
            string caminho = caminhoBanco + nomeBancoDisciplinas;

            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("disid,disnome,dissig,disobs");

                    foreach (var item in bancoDisciplinas)
                    {
                        writer.WriteLine(
                            $"{item.disid},{item.disnome},{item.dissig},{item.disobs}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro" + ex.Message);
            }
        }

        private List<Disciplina> CarregarDisciplinasDoCsv(string caminho)
        {
            var disciplinas = new List<Disciplina>();

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
                                int disid = int.Parse(partes[0]);
                                string disnome = partes[1];
                                string dissig = partes[2];
                                string disobs = partes[3];
                                disciplinas.Add(new Disciplina
                                {
                                    disid = disid,
                                    disnome = disnome,
                                    dissig = dissig,
                                    disobs = disobs
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
            return disciplinas;
        }

        private List<Disciplina> bancoDisciplinas = new List<Disciplina>();
        private Disciplina itemDisciplina;

        private string caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
        private string nomeBancoDisciplinas = ConfigurationManager.AppSettings["nomeBancoDisciplinas"];

        public Disciplinas_act()
        {

            bancoDisciplinas = CarregarDisciplinasDoCsv(caminhoBanco + nomeBancoDisciplinas);

        }

        public void inserir(Disciplina disciplina)
        {
            itemDisciplina = new Disciplina();
            itemDisciplina.disid = disciplina.disid;
            itemDisciplina.disnome = disciplina.disnome;
            itemDisciplina.dissig = disciplina.dissig;
            itemDisciplina.disobs = disciplina.disobs;

            bancoDisciplinas.Add(disciplina);
        }

        public void alterar(string sigla, Disciplina disciplina)
        {
            foreach (var item in bancoDisciplinas)
            {
                if (item.dissig == sigla.ToString().Trim())
                {
                    item.dissig = Console.ReadLine();
                    item.disnome = Console.ReadLine();
                    item.disobs = Console.ReadLine();
                    break;
                }
            }
        }

        public void excluir(string sigla)
        {
            foreach (var item in bancoDisciplinas)
            {
                if (item.dissig == sigla.ToString().Trim())
                {
                    bancoDisciplinas.Remove(item);
                    break;
                }
            }
        }

        public void pesquisar(string sigla)
        {

            foreach (var item in bancoDisciplinas)
            {
                if (item.dissig == sigla.ToString().Trim())
                {
                    Console.WriteLine(item.disid.ToString()
                        + " - " + item.disnome.ToString()
                        + " - " + (item.dissig.ToString()
                        + " - " + (item.disobs.ToString())));
                }
            }
        }

        public void exibirTodos()
        {
            foreach (var item in bancoDisciplinas)
            {
                Console.WriteLine(item.disid.ToString()
                    + " - " + item.disnome.ToString()
                    + " - " + (item.dissig.ToString()
                    + " - " + (item.disobs.ToString())));
            }
        }
    }
}
