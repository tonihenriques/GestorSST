using GISCore.Business.Abstract;
using GISModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Business.Concrete
{
    public class AlocacaoBusiness: BaseBusiness<Alocacao>, IAlocacaoBusiness
    {

        public override void Inserir(Alocacao oAlocacao)
        {

            if (Consulta.Any(u => u.IDAlocacao.Equals(oAlocacao.IDAlocacao)))
                throw new InvalidOperationException("Não é possível inserir esta alocação, pois já existe uma Alocação com este ID.");

            if ((Consulta.Any(u =>u.IdAdmissao.Equals(oAlocacao.IdAdmissao) && u.Ativado == "true"  )))
            
               throw new InvalidCastException("Existe uma Alaocação ativa, favor desativá-la antes! ");

            oAlocacao.IDAlocacao = Guid.NewGuid().ToString();
            oAlocacao.Ativado = "true";
            
            base.Inserir(oAlocacao);



        }
        public override void Alterar(Alocacao oAlocacao)
        {
            Alocacao tempAlocacao = Consulta.FirstOrDefault(p => p.IDAlocacao.Equals(oAlocacao.IDAlocacao));

            if (tempAlocacao == null)
            {
                throw new Exception("não foi possível encontrar esta Alocação");
            }

            tempAlocacao.Ativado = "false";


            base.Alterar(tempAlocacao);

        }







    }
}
