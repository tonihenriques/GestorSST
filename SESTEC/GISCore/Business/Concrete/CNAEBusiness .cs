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
    public class CNAEBusiness : BaseBusiness<CNAE>, ICNAEBusiness
    {

        public override void Inserir(CNAE pCNAE)
        {

            
            
           
            pCNAE.IDCNAE = Guid.NewGuid().ToString();

            base.Inserir(pCNAE);

            

        }

        
    }
}
