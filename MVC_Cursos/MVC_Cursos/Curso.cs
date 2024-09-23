using MVC_Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Disciplina[] Disciplinas { get; set; } = new Disciplina[12];

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] == null)
                {
                    Disciplinas[i] = disciplina;
                    return true;
                }
            }
            return false;
        }

        public Disciplina PesquisarDisciplina(int idDisciplina)
        {
            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == idDisciplina)
                {
                    return Disciplinas[i];
                }
            }
            return null;
        }

        public bool RemoverDisciplina(int idDisciplina)
        {
            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == idDisciplina)
                {
                    if (Disciplinas[i].Alunos[0] == null)
                    {
                        Disciplinas[i] = null;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}