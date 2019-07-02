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
    public class ContratoBusiness : BaseBusiness<Contrato>, IContratoBusiness
    {
        public override void Inserir(Contrato pContrato)
        {


            pContrato.IDContrato = Guid.NewGuid().ToString();

            base.Inserir(pContrato);



        }

        public override void Alterar(Contrato pContrato)
        {

            Contrato tempContrato = Consulta.FirstOrDefault(p => p.IDContrato.Equals(pContrato.IDContrato));
            if (tempContrato == null)
            {
                throw new Exception("Não foi possível encontrar o Contrato através do ID.");
            }
            else
            {
                tempContrato.DescricaoContrato = pContrato.DescricaoContrato;

                base.Alterar(tempContrato);



            }

        }

    }

}
        

