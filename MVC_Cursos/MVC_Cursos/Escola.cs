using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Escola
    {
        public Curso[] Cursos { get; set; } = new Curso[5];

        public bool AdicionarCurso(Curso curso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] == null)
                {
                    Cursos[i] = curso;
                    return true;
                }
            }
            return false;
        }

        public Curso PesquisarCurso(int idCurso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == idCurso)
                {
                    return Cursos[i];
                }
            }
            return null;
        }

        public bool RemoverCurso(int idCurso)
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == idCurso)
                {
                    bool temDisciplinas = false;
                    for (int j = 0; j < Cursos[i].Disciplinas.Length; j++)
                    {
                        if (Cursos[i].Disciplinas[j] != null)
                        {
                            temDisciplinas = true;
                            break;
                        }
                    }
                    if (!temDisciplinas)
                    {
                        Cursos[i] = null;
                        return true;
                    }
                }
            }
            return false;
        }

        public void PesquisarAluno(string nomeAluno)
        {
            bool alunoEncontrado = false;

            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null)
                {
                    for (int j = 0; j < Cursos[i].Disciplinas.Length; j++)
                    {
                        if (Cursos[i].Disciplinas[j] != null)
                        {
                            for (int k = 0; k < Cursos[i].Disciplinas[j].Alunos.Length; k++)
                            {
                                if (Cursos[i].Disciplinas[j].Alunos[k] != null && Cursos[i].Disciplinas[j].Alunos[k].Nome == nomeAluno)
                                {
                                    Console.WriteLine($"\nAluno {nomeAluno} está matriculado na disciplina {Cursos[i].Disciplinas[j].Descricao}.");
                                    Console.WriteLine("-----------------------------------------");
                                    alunoEncontrado = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!alunoEncontrado)
            {
                Console.WriteLine($"\nAluno {nomeAluno} não encontrado em nenhuma disciplina.");
                Console.WriteLine("-----------------------------------------");
            }
        }
    }
}