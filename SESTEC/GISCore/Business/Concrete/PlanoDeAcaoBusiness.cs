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
    public class PlanoDeAcaoBusiness : BaseBusiness<PlanoDeAcao>, IPlanoDeAcaoBusiness
    {

        public override void Inserir(PlanoDeAcao pPlanoDeAcao)
        {

            if (Consulta.Any(u => u.Identificador.Equals(pPlanoDeAcao.Identificador)))
                throw new InvalidOperationException("Não é possível inserir este Plano de Ação, pois já existe um em andamento.");

            //if ((Consulta.Any(u => u.IdAdmissao.Equals(oAlocacao.IdAdmissao) && u.Ativado == "true")))

            //    throw new InvalidCastException("Existe uma Alaocação ativa, favor desativá-la antes! ");

            pPlanoDeAcao.IDPlanoDeAcao = Guid.NewGuid().ToString();
            //pPlanoDeAcao.Entregue = "";
            
            base.Inserir(pPlanoDeAcao);

            

        }

        public override void Alterar(PlanoDeAcao pPlanoDeAcao)
        {

            PlanoDeAcao tempPlanoDeAcao = Consulta.FirstOrDefault(p => p.IDPlanoDeAcao.Equals(pPlanoDeAcao.IDPlanoDeAcao));
            if (tempPlanoDeAcao == null)
            {
                throw new Exception("Não foi possível encontrar o Plano de Ação através do ID.");
            }

            
            else
            {    

                tempPlanoDeAcao.DescricaoDoPlanoDeAcao = pPlanoDeAcao.DescricaoDoPlanoDeAcao;
                tempPlanoDeAcao.Responsavel= pPlanoDeAcao.Responsavel;
                tempPlanoDeAcao.TipoDoPlanoDeAcao = pPlanoDeAcao.TipoDoPlanoDeAcao;
                tempPlanoDeAcao.ResponsavelPelaEntrega= pPlanoDeAcao.ResponsavelPelaEntrega;
                tempPlanoDeAcao.Entregue = pPlanoDeAcao.Entregue;
                
                

                base.Alterar(tempPlanoDeAcao);

                
            }

        }

    }
}
