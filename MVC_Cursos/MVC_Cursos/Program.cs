using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Escola escola = new Escola();
            int opcao;

            do
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso");
                Console.WriteLine("3. Remover curso");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina");
                Console.WriteLine("6. Remover disciplina do curso");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno da disciplina");
                Console.WriteLine("9. Pesquisar aluno");
                Console.WriteLine("-----------------------------------------");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarCurso(escola);
                        break;
                    case 2:
                        PesquisarCurso(escola);
                        break;
                    case 3:
                        RemoverCurso(escola);
                        break;
                    case 4:
                        AdicionarDisciplina(escola);
                        break;
                    case 5:
                        PesquisarDisciplina(escola);
                        break;
                    case 6:
                        RemoverDisciplina(escola);
                        break;
                    case 7:
                        MatricularAluno(escola);
                        break;
                    case 8:
                        RemoverAluno(escola);
                        break;
                    case 9:
                        PesquisarAluno(escola);
                        break;
                }

            } while (opcao != 0);
        }

        static void AdicionarCurso(Escola escola)
        {
            Curso curso = new Curso();
            Console.Write("\nDigite o ID do curso: ");
            curso.Id = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição do curso: ");
            curso.Descricao = Console.ReadLine();
            if (escola.AdicionarCurso(curso))
            {
                Console.WriteLine("\nCurso adicionado com sucesso! \n");
                Console.WriteLine("-----------------------------------------");

            }
            else
            {
                Console.WriteLine("\nErro ao adicionar curso. Limite de cursos atingido. \n");
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void PesquisarCurso(Escola escola)
        {
            Console.Write("\nDigite o ID do curso a ser pesquisado: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = escola.PesquisarCurso(idCurso);
            if (curso != null)
            {
                Console.WriteLine($"\nCurso encontrado: {curso.Descricao}");
                Console.WriteLine("Disciplinas:");
                foreach (var disciplina in curso.Disciplinas)
                {
                    if (disciplina != null)
                    {
                        Console.WriteLine($"- {disciplina.Descricao}");
                        Console.WriteLine("-----------------------------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nCurso não encontrado.\n");
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void RemoverCurso(Escola escola)
        {
            Console.Write("\nDigite o ID do curso a ser removido: ");
            int idCurso = int.Parse(Console.ReadLine());
            if (escola.RemoverCurso(idCurso))
            {
                Console.WriteLine("\nCurso removido com sucesso!\n");
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("\nErro ao remover curso. Verifique se há disciplinas associadas.\n");
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void AdicionarDisciplina(Escola escola)
        {
            Console.Write("\nDigite o ID do curso para adicionar a disciplina: ");
            int idCurso = int.Parse(Console.ReadLine());
            Curso curso = escola.PesquisarCurso(idCurso);
            if (curso != null)
            {
                Disciplina disciplina = new Disciplina();
                Console.Write("Digite o ID da disciplina: ");
                disciplina.Id = int.Parse(Console.ReadLine());
                Console.Write("Digite a descrição da disciplina: ");
                disciplina.Descricao = Console.ReadLine();
                if (curso.AdicionarDisciplina(disciplina))
                {
                    Console.WriteLine("\nDisciplina adicionada com sucesso!\n");
                    Console.WriteLine("-----------------------------------------");
                }
                else
                {
                    Console.WriteLine("\nErro ao adicionar disciplina. Limite de disciplinas atingido.\n");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("\nCurso não encontrado.\n");
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void PesquisarDisciplina(Escola escola)
        {
            Console.Write("\nDigite o ID da disciplina a ser pesquisada: ");
            int idDisciplina = int.Parse(Console.ReadLine());
            foreach (var curso in escola.Cursos)
            {
                if (curso != null)
                {
                    Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
                    if (disciplina != null)
                    {
                        Console.WriteLine($"\nDisciplina encontrada: {disciplina.Descricao}");
                        Console.WriteLine("Alunos matriculados:");
                        foreach (var aluno in disciplina.Alunos)
                        {
                            if (aluno != null)
                            {
                                Console.WriteLine($"- {aluno.Nome}");
                                Console.WriteLine("\n-----------------------------------------");
                            }
                        }
                        return;
                    }
                }
            }
            Console.WriteLine("\nDisciplina não encontrada.\n");
            Console.WriteLine("-----------------------------------------");
        }

        static void RemoverDisciplina(Escola escola)
        {
            Console.Write("\nDigite o ID da disciplina a ser removida: ");
            int idDisciplina = int.Parse(Console.ReadLine());
            foreach (var curso in escola.Cursos)
            {
                if (curso != null)
                {
                    if (curso.RemoverDisciplina(idDisciplina))
                    {
                        Console.WriteLine("Disciplina removida com sucesso!");
                        Console.WriteLine("-----------------------------------------");
                        return;
                    }
                }
            }
            Console.WriteLine("\nErro ao remover disciplina. Verifique se há alunos matriculados.");
            Console.WriteLine("-----------------------------------------");
        }

        static void MatricularAluno(Escola escola)
        {
            Console.Write("\nDigite o ID da disciplina para matricular o aluno: ");
            int idDisciplina = int.Parse(Console.ReadLine());
            foreach (var curso in escola.Cursos)
            {
                if (curso != null)
                {
                    Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
                    if (disciplina != null)
                    {
                        Aluno aluno = new Aluno();
                        Console.Write("Digite o ID do aluno: ");
                        aluno.Id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome do aluno: ");
                        aluno.Nome = Console.ReadLine();
                        if (disciplina.MatricularAluno(aluno))
                        {
                            Console.WriteLine("\nAluno matriculado com sucesso!\n");
                            Console.WriteLine("-----------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("\nErro ao matricular aluno. Verifique se ele já está matriculado em 6 disciplinas ou se a disciplina já está cheia.");
                            Console.WriteLine("-----------------------------------------");
                        }
                        return;
                    }
                }
            }
            Console.WriteLine("\nDisciplina não encontrada.");
            Console.WriteLine("-----------------------------------------");
        }

        static void RemoverAluno(Escola escola)
        {
            Console.Write("\nDigite o ID da disciplina para remover o aluno: ");
            int idDisciplina = int.Parse(Console.ReadLine());
            foreach (var curso in escola.Cursos)
            {
                if (curso != null)
                {
                    Disciplina disciplina = curso.PesquisarDisciplina(idDisciplina);
                    if (disciplina != null)
                    {
                        Console.Write("Digite o ID do aluno a ser removido: ");
                        int idAluno = int.Parse(Console.ReadLine());
                        Aluno aluno = new Aluno { Id = idAluno };
                        if (disciplina.DesmatricularAluno(aluno))
                        {
                            Console.WriteLine("\nAluno removido com sucesso!");
                            Console.WriteLine("-----------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("\nErro ao remover aluno. Aluno não encontrado na disciplina.");
                            Console.WriteLine("-----------------------------------------");
                        }
                        return;
                    }
                }
            }
            Console.WriteLine("\nDisciplina não encontrada.");
            Console.WriteLine("-----------------------------------------");
        }

        static void PesquisarAluno(Escola escola)
        {
            Console.Write("\nDigite o nome do aluno a ser pesquisado: ");
            string nomeAluno = Console.ReadLine();
            escola.PesquisarAluno(nomeAluno);
        }

    }
}