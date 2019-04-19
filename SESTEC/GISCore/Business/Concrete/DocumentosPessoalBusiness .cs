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
    public class DocumentosPessoalBusiness : BaseBusiness<DocumentosPessoal>, IDocumentosPessoalBusiness
    {

        public override void Inserir(DocumentosPessoal pDocumentosPessoal)
        {
            
            
            pDocumentosPessoal.IDDocumentosEmpregado = Guid.NewGuid().ToString();
           // pAtividadeAlocada.Admitido = "Admitido";
            
            base.Inserir(pDocumentosPessoal);

           

        }

        public override void Alterar(DocumentosPessoal pDocumentosPessoal)
        {


            DocumentosPessoal tempDocumentosPessoal = Consulta.FirstOrDefault(p => p.IDDocumentosEmpregado.Equals(pDocumentosPessoal.IDDocumentosEmpregado));

           
            if (tempDocumentosPessoal == null)
            {
                throw new Exception("Não foi possível encontrar este Documento");
            }

            tempDocumentosPessoal.NomeDocumento = pDocumentosPessoal.NomeDocumento;



            base.Alterar(tempDocumentosPessoal);





        }

    }
}
