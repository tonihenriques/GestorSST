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
    public class AspectoBusiness : BaseBusiness<Aspecto>, IAspectoBusiness
    {

        public override void Inserir(Aspecto pAspecto)
        {

            if (Consulta.Any(u => u.IDAspecto.Equals(pAspecto.IDAspecto)))

                throw new InvalidOperationException("Não e possível inserir o Aspecto, pois já existe um aspecto com este ID");
            
            pAspecto.IDAspecto = Guid.NewGuid().ToString();            
            
            base.Inserir(pAspecto);
 
        }

        public override void Alterar(Aspecto pAspecto)
        {

            Aspecto tempAspecto = Consulta.FirstOrDefault(p => p.IDAspecto.Equals(pAspecto.IDAspecto));
            if (tempAspecto == null)
            {
                throw new Exception("Não foi possível encontrar o aspecto através do ID.");
            }
            else
            {
                
                tempAspecto.DescricaoAspecto = pAspecto.DescricaoAspecto;
               
                base.Alterar(tempAspecto);

                
                

            }

        }

    }
}
