using MVC_Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public bool PodeMatricular(Curso curso)
        {
            int disciplinasMatriculadas = 0;

            foreach (var disciplina in curso.Disciplinas)
            {
                bool alunoMatriculadoNaDisciplina = false;

                for (int i = 0; i < disciplina.Alunos.Length; i++)
                {
                    if (disciplina.Alunos[i] != null)
                    {
                        if (disciplina.Alunos[i].Id == this.Id)
                        {
                            alunoMatriculadoNaDisciplina = true;
                            break;
                        }
                    }
                }
                if (alunoMatriculadoNaDisciplina)
                {
                    disciplinasMatriculadas++;
                }
            }
            return disciplinasMatriculadas < 6;
        }

    }
}