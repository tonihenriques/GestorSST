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
    public class PerguntaBusiness : BaseBusiness<Pergunta>, IPerguntaBusiness
    {

        public override void Inserir(Pergunta pPergunta)
        {
            
           
            pPergunta.IDPergunta = Guid.NewGuid().ToString();
            
            base.Inserir(pPergunta);
            

        }

        public override void Alterar(Pergunta pPergunta)
        {

            Pergunta tempPergunta = Consulta.FirstOrDefault(p => p.IDPergunta.Equals(pPergunta.IDPergunta));
            if (tempPergunta == null)
            {
                throw new Exception("Não foi possível encontrar esta Pergunta");
            }
            else
            {
                
                tempPergunta.Descricao = pPergunta.Descricao;
                

                base.Alterar(tempPergunta);

                

            }

        }

    }
}
