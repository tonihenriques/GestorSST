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
    public class AnaliseRiscoBusiness : BaseBusiness<AnaliseRisco>, IAnaliseRiscoBusiness
    {

        public override void Inserir(AnaliseRisco pAnaliseRisco)
        {
            
            
            pAnaliseRisco.IDAnaliseRisco = Guid.NewGuid().ToString();
           // pAtividadeAlocada.Admitido = "Admitido";
            
            base.Inserir(pAnaliseRisco);

           

        }

        public override void Alterar(AnaliseRisco pAnaliseRisco)
        {


            List<AnaliseRisco> lAnaliseRisco = Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.IDAlocacao.Equals(pAnaliseRisco.IDAlocacao)).ToList();
            //&& p.idAtividadesDoEstabelecimento.Equals(pAnaliseRisco.idAtividadesDoEstabelecimento)).ToList();
            if (lAnaliseRisco.Count.Equals(1))
            {
                AnaliseRisco oAnaliseRisco = lAnaliseRisco[0];

                oAnaliseRisco.UsuarioExclusao = pAnaliseRisco.UsuarioExclusao;
                oAnaliseRisco.DataExclusao = pAnaliseRisco.DataExclusao;

                base.Alterar(pAnaliseRisco);
            }








            //AtividadeAlocada tempAtividadeAlocada = Consulta.FirstOrDefault(p => p.IDAtividadeAlocada.Equals(pAtividadeAlocada.IDAtividadeAlocada));
            //if (tempAtividadeAlocada == null)
            //{
            //    throw new Exception("Não foi possível encontrar a Atividade através do ID.");
            //}
            //else
            //{

            //    tempAtividadeAlocada.idAtividadesDoEstabelecimento = pAtividadeAlocada.idAtividadesDoEstabelecimento;
               
                
                

            //    base.Alterar(tempAtividadeAlocada);

                

            //}

        }

    }
}
