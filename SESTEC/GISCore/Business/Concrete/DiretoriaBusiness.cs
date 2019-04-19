using GISCore.Business.Abstract;
using GISModel.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Business.Concrete
{
    public class DiretoriaBusiness : BaseBusiness<Diretoria>, IDiretoriaBusiness
    {

        public override void Inserir(Diretoria pDiretoria)
        {

            if (Consulta.Any(u => u.IDDiretoria.Equals(pDiretoria.IDDiretoria)))

                throw new InvalidOperationException("Não é possível inserir a Diretoria, pois já existe uma Diretoria com este ID.");

            pDiretoria.IDDiretoria = Guid.NewGuid().ToString();

            base.Inserir(pDiretoria);

            
        }

        public override void Alterar(Diretoria pDiretoria)
        {
            Diretoria tempDiretoria = Consulta.FirstOrDefault(p => p.IDDiretoria.Equals(pDiretoria.IDDiretoria));

            if (tempDiretoria == null)
            {
                throw new Exception("não foi possível encontrar esta Diretoria");
            }

            tempDiretoria.Sigla = pDiretoria.Sigla;
            tempDiretoria.Descricao = pDiretoria.Descricao;


            base.Alterar(tempDiretoria);

        }

    }
}
