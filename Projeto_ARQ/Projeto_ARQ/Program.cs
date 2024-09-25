using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Projeto_ARQ
{
    internal class Program
    {

        static void SalvarPeriodosEmCsv(List<Periodo> bancoPeriodos, string caminho)
        {
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

        static List<Periodo> CarregarPeriodosDoCsv(string caminho)
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

        static void SalvarCursosEmCsv(List<Curso> bancoCursos, string caminho)
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

        static List<Curso> CarregarCursosDoCsv(string caminho)
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

        static void SalvarDisciplinasEmCsv(List<Disciplina> bancoDisciplinas, string caminho)
        {
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

        static List<Disciplina> CarregarDisciplinasDoCsv(string caminho)
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


        static void Main(string[] args)
        {
            int opcao = 0;
            int subopcao = 0;
            string sigla;

            List<Periodo> bancoPeriodos = new List<Periodo>();
            List<Curso> bancoCursos = new List<Curso>();
            List<Disciplina> bancoDisciplinas = new List<Disciplina>();

            string caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            string nomeBancoPeriodos = ConfigurationManager.AppSettings["nomeBancoPeriodos"];
            string nomeBancoDisciplinas = ConfigurationManager.AppSettings["nomeBancoDisciplinas"];
            string nomeBancoCursos = ConfigurationManager.AppSettings["nomeBancoCursos"];

            bancoPeriodos = CarregarPeriodosDoCsv(caminhoBanco + nomeBancoPeriodos);
            bancoDisciplinas = CarregarDisciplinasDoCsv(caminhoBanco + nomeBancoDisciplinas);
            bancoCursos = CarregarCursosDoCsv(caminhoBanco + nomeBancoCursos);


            while (opcao != 9)
            {
                Console.WriteLine("Sistema: Escolas e Faculdades");
                Console.WriteLine("1. Periodos");
                Console.WriteLine("2. Cursos");
                Console.WriteLine("3. Disciplinas");
                Console.WriteLine("9. Sair");
                Console.Write("Digite a opcao: ");
                opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    subopcao = 0;

                    while (subopcao != 19)
                    {
                        Console.WriteLine("10. Inserir");
                        Console.WriteLine("11. Alterar");
                        Console.WriteLine("12. Excluir");
                        Console.WriteLine("13. Pesquisar");
                        Console.WriteLine("14. Exibir");
                        Console.WriteLine("15. Salvar banco");
                        Console.WriteLine("19. Sair");
                        Console.Write("Digite a subopcao: ");
                        subopcao = int.Parse(Console.ReadLine());

                        if (subopcao == 10)
                        {

                            Periodo periodo = new Periodo();
                            periodo.perid = int.Parse(Console.ReadLine());
                            periodo.pernome = Console.ReadLine();
                            periodo.persigla = Console.ReadLine();

                            bancoPeriodos.Add(periodo);

                            break;
                        }

                        if (subopcao == 11)
                        {

                            sigla = Console.ReadLine();

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

                        if (subopcao == 12)
                        {

                            sigla = Console.ReadLine();

                            foreach (var item in bancoPeriodos)
                            {
                                if (item.persigla == sigla.ToString().Trim())
                                {
                                    bancoPeriodos.Remove(item);
                                    break;
                                }
                            }

                            break;

                        }

                        if (subopcao == 13)
                        {

                            sigla = Console.ReadLine();

                            foreach (var item in bancoPeriodos)
                            {
                                if (item.persigla == sigla.ToString().Trim())
                                {
                                    Console.WriteLine(item.perid.ToString()
                                        + " - " + item.pernome.ToString()
                                        + " - " + (item.persigla.ToString()));
                                }
                            }

                            break;
                        }

                        if (subopcao == 14)
                        {

                            foreach (var item in bancoPeriodos)
                            {
                                Console.WriteLine(item.perid.ToString()
                                    + " - " + item.pernome.ToString()
                                    + " - " + (item.persigla.ToString()));
                            }

                            break;
                        }

                        if (subopcao == 15)
                        {
                            SalvarPeriodosEmCsv(bancoPeriodos, caminhoBanco + nomeBancoPeriodos);

                            break;
                        }
                    }
                }

                if (opcao == 2)
                {
                    subopcao = 0;

                    while (subopcao != 29)
                    {
                        Console.WriteLine("20. Inserir");
                        Console.WriteLine("21. Alterar");
                        Console.WriteLine("22. Excluir");
                        Console.WriteLine("23. Pesquisar");
                        Console.WriteLine("24. Exibir");
                        Console.WriteLine("25. Salvar em Banco");
                        Console.WriteLine("29. Sair");
                        Console.Write("Digite a subopcao: ");
                        subopcao = int.Parse(Console.ReadLine());

                        if (subopcao == 20)
                        {
                            Curso curso = new Curso();
                            curso.cursoid = int.Parse(Console.ReadLine());
                            curso.cursonome = Console.ReadLine();
                            curso.cursosig = Console.ReadLine();
                            curso.cursoobs = Console.ReadLine();

                            bancoCursos.Add(curso);

                            break;
                        }

                        if (subopcao == 21)
                        {

                            sigla = Console.ReadLine();

                            foreach (var item in bancoCursos)
                            {
                                if (item.cursosig == sigla.ToString().Trim())
                                {
                                    item.cursosig = Console.ReadLine();
                                    item.cursonome = Console.ReadLine();
                                    item.cursoobs = Console.ReadLine();
                                    break;
                                }
                            }
                        }

                        if (subopcao == 22)
                        {
                            sigla = Console.ReadLine();

                            foreach (var item in bancoCursos)
                            {
                                if (item.cursosig == sigla.ToString().Trim())
                                {
                                    bancoCursos.Remove(item);
                                    break;
                                }
                            }

                            break;
                        }

                        if (subopcao == 23)
                        {
                            sigla = Console.ReadLine();

                            foreach (var item in bancoCursos)
                            {
                                if (item.cursosig == sigla.ToString().Trim())
                                {
                                    Console.WriteLine(item.cursoid.ToString()
                                        + " - " + item.cursonome.ToString()
                                        + " - " + (item.cursosig.ToString()
                                        + " - " + (item.cursoobs.ToString())));
                                }
                            }

                            break;
                        }

                        if (subopcao == 24)
                        {

                            foreach (var item in bancoCursos)
                            {
                                Console.WriteLine(item.cursoid.ToString()
                                    + " - " + item.cursonome.ToString()
                                    + " - " + (item.cursosig.ToString()
                                    + " - " + (item.cursoobs.ToString())));
                            }

                            break;

                        }

                        if (subopcao == 25)
                        {
                            SalvarCursosEmCsv(bancoCursos, caminhoBanco + nomeBancoCursos);
                            break;
                        }
                    }
                }

                if (opcao == 3)
                {
                    subopcao = 0;

                    while (subopcao != 39)
                    {
                        Console.WriteLine("30. Inserir");
                        Console.WriteLine("31. Alterar");
                        Console.WriteLine("32. Excluir");
                        Console.WriteLine("33. Pesquisar");
                        Console.WriteLine("34. Exibir");
                        Console.WriteLine("35. Salvar banco");
                        Console.WriteLine("39. Sair");
                        Console.Write("Digite a subopcao: ");
                        subopcao = int.Parse(Console.ReadLine());

                        if (subopcao == 30)
                        {
                            Disciplina disciplina = new Disciplina();
                            disciplina.disid = int.Parse(Console.ReadLine());
                            disciplina.disnome = Console.ReadLine();
                            disciplina.dissig = Console.ReadLine();
                            disciplina.disobs = Console.ReadLine();

                            bancoDisciplinas.Add(disciplina);

                            break;
                        }

                        if (subopcao == 31)
                        {
                            sigla = Console.ReadLine();

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

                        if (subopcao == 32)
                        {
                            sigla = Console.ReadLine();

                            foreach (var item in bancoDisciplinas)
                            {
                                if (item.dissig == sigla.ToString().Trim())
                                {
                                    bancoDisciplinas.Remove(item);
                                    break;
                                }
                            }
                        }

                        if (subopcao == 33)
                        {
                            sigla = Console.ReadLine();

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

                            break;
                        }

                        if (subopcao == 34)
                        {
                            foreach (var item in bancoDisciplinas)
                            {
                                Console.WriteLine(item.disid.ToString()
                                    + " - " + item.disnome.ToString()
                                    + " - " + (item.dissig.ToString()
                                    + " - " + (item.disobs.ToString())));
                            }

                            break;
                        }

                        if (subopcao == 35)
                        {
                            SalvarDisciplinasEmCsv(bancoDisciplinas, caminhoBanco + nomeBancoDisciplinas);
                            break;
                        }

                    }

                }
            }
        }
    }
}
