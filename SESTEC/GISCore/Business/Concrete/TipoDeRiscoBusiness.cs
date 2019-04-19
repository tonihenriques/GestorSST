using GISCore.Business.Abstract;
using GISModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Business.Concrete
{
    public class TipoDeRiscoBusiness: BaseBusiness<TipoDeRisco>, ITipoDeRiscoBusiness
    {

        public override void Inserir(TipoDeRisco pTipoDeRisco)
        {     

            //if (Consulta.Any(u => u.DescricaoDoRisco.Equals(pTipoDeRisco.DescricaoDoRisco)))

            //    throw new InvalidOperationException("Não é possível inserir o Risco, pois já existe um Risco com esta descrição.");

            pTipoDeRisco.IDTipoDeRisco = Guid.NewGuid().ToString();

            base.Inserir(pTipoDeRisco);

        }

        public override void Alterar(TipoDeRisco oTipoDeRisco)
        {

            TipoDeRisco tempTipoDeRisco = Consulta.FirstOrDefault(p => p.IDTipoDeRisco.Equals(oTipoDeRisco.IDTipoDeRisco));

            if (tempTipoDeRisco == null)
            {
                throw new Exception("não foi possível encontrar este Tipo de Risco!");
            }
            
            tempTipoDeRisco.idPerigoPotencial = oTipoDeRisco.idPerigoPotencial;
            tempTipoDeRisco.PossiveisDanos = oTipoDeRisco.PossiveisDanos;

            base.Alterar(tempTipoDeRisco);
        }


        public override void Excluir(TipoDeRisco pTipoDeRisco)
        {

            base.Alterar(pTipoDeRisco);

        }



    }
}
