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
    public class DocsPorAtividadeBusiness : BaseBusiness<DocsPorAtividade>, IDocsPorAtividadeBusiness
    {

        public override void Inserir(DocsPorAtividade pDocsPorAtividade)
        {
            
            
            pDocsPorAtividade.IDDocAtividade = Guid.NewGuid().ToString();
           // pAtividadeAlocada.Admitido = "Admitido";
            
            base.Inserir(pDocsPorAtividade);

           

        }

        public override void Alterar(DocsPorAtividade pDocsPorAtividade)
        {


            DocsPorAtividade tempDocsPorAtividade = Consulta.FirstOrDefault(p => p.IDDocAtividade.Equals(pDocsPorAtividade.IDDocAtividade));

           
            if (tempDocsPorAtividade == null)
            {
                throw new Exception("Não foi possível encontrar este Documento");
            }

            tempDocsPorAtividade.idAtividade = pDocsPorAtividade.idAtividade;
            tempDocsPorAtividade.idDocumentosEmpregado = pDocsPorAtividade.idDocumentosEmpregado;


            base.Alterar(tempDocsPorAtividade);





        }

    }
}
