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
    public class AtividadeBusiness : BaseBusiness<Atividade>, IAtividadeBusiness
    {

        public override void Inserir(Atividade pAtividadeDeRisco)
        {

            if (Consulta.Any(u => u.IDAtividade.Equals(pAtividadeDeRisco.IDAtividade)))

                throw new InvalidOperationException("Não é possível inserir a Atividade, pois já existe uma Atividade com este ID.");

            pAtividadeDeRisco.IDAtividade = Guid.NewGuid().ToString();

            base.Inserir(pAtividadeDeRisco);

            
        }

        public override void Alterar(Atividade pAtividadeDeRisco)
        {
            Atividade tempAtividadeDeRisco = Consulta.FirstOrDefault(p => p.IDAtividade.Equals(pAtividadeDeRisco.IDAtividade));

            if (tempAtividadeDeRisco == null)
            {
                throw new Exception("Não foi possível encontrar esta Atividade");
            }

            tempAtividadeDeRisco.Descricao = pAtividadeDeRisco.Descricao;
            

            base.Alterar(tempAtividadeDeRisco);

        }

    }
}
