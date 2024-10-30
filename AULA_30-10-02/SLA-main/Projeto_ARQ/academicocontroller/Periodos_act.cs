using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace academicocontroller
{
    internal class Periodos_act
    {
        public void SalvarPeriodosEmCsv()
        {
            string caminho = caminhoBanco + nomeBancoPeriodos;

            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("perid,pernome,persigla");

                    foreach (var item in bancoPeriodos)
                    {
                        writer.WriteLine(
                            $"{item.perid},{item.pernome},{item.persigla}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro" + ex.Message);
            }
        }

        private List<Periodo> CarregarPeriodosDoCsv(string caminho)
        {
            var periodos = new List<Periodo>();

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
                            if (partes.Length == 3)
                            {
                                int perid = int.Parse(partes[0]);
                                string pernome = partes[1];
                                string persigla = partes[2];
                                periodos.Add(new Periodo
                                {
                                    perid = perid,
                                    pernome = pernome,
                                    persigla = persigla
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
            return periodos;
        }

        private List<Periodo> bancoPeriodos = new List<Periodo>();
        private Periodo itemPeriodo;

        private string caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
        private string nomeBancoPeriodos = ConfigurationManager.AppSettings["nomeBancoPeriodos"];

        public Periodos_act()
        {

            bancoPeriodos = CarregarPeriodosDoCsv(caminhoBanco + nomeBancoPeriodos);

        }

        public void inserir(Periodo periodo)
        {
            itemPeriodo = new Periodo();
            itemPeriodo.perid = periodo.perid;
            itemPeriodo.pernome = periodo.pernome;
            itemPeriodo.persigla = periodo.persigla;

            bancoPeriodos.Add(periodo);
        }

        public void alterar(string sigla, Periodo periodo)
        { 
            foreach (var item in bancoPeriodos)
            {
                if (item.persigla == sigla.ToString().Trim())
                {
                    item.persigla = Console.ReadLine();
                    item.pernome = Console.ReadLine();
                    break;
                }
            }
        }

        public void excluir(string sigla)
        {
            foreach (var item in bancoPeriodos)
            {
                if (item.persigla == sigla.ToString().Trim())
                {
                    bancoPeriodos.Remove(item);
                    break;
                }
            }      
        }

        public void pesquisar(string sigla)
        {
            foreach (var item in bancoPeriodos)
            {
                if (item.persigla == sigla.ToString().Trim())
                {
                    Console.WriteLine(item.perid.ToString()
                        + " - " + item.pernome.ToString()
                        + " - " + (item.persigla.ToString()));
                }
            }
        }

        public void exibirTodos()
        {
            foreach (var item in bancoPeriodos)
            {
                Console.WriteLine(item.perid.ToString()
                    + " - " + item.pernome.ToString()
                    + " - " + (item.persigla.ToString()));
            }
        }

    }
}
