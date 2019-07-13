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
    public class AspectoPerguntaBusiness : BaseBusiness<AspectoPergunta>, IAspectoPerguntaBusiness
    {

        public override void Inserir(AspectoPergunta pAspectoPergunta)
        {
            
           
            pAspectoPergunta.IDAspectoPergunta = Guid.NewGuid().ToString();
            
            base.Inserir(pAspectoPergunta);
            

        }

        public override void Alterar(AspectoPergunta pAspectoPergunta)
        {

            AspectoPergunta tempAspectoPergunta = Consulta.FirstOrDefault(p => p.IDAspectoPergunta.Equals(pAspectoPergunta.IDAspectoPergunta));
            if (tempAspectoPergunta == null)
            {
                throw new Exception("Não foi possível encontrar esta Pergunta");
            }
            else
            {

                tempAspectoPergunta.idAspecto = pAspectoPergunta.idAspecto;
                tempAspectoPergunta.idPergunta= pAspectoPergunta.idPergunta;


                base.Alterar(tempAspectoPergunta);

                

            }

        }

    }
}
