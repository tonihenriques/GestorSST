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
    public class EquipeBusiness : BaseBusiness<Equipe>, IEquipeBusiness
    {

        public override void Inserir(Equipe pEquipe)
        {
            
           
            pEquipe.IDEquipe = Guid.NewGuid().ToString();
            
            base.Inserir(pEquipe);
            

        }

        public override void Alterar(Equipe pEquipe)
        {

            Equipe tempEquipe = Consulta.FirstOrDefault(p => p.IDEquipe.Equals(pEquipe.IDEquipe));
            if (tempEquipe == null)
            {
                throw new Exception("Não foi possível encontrar esta Equipe");
            }
            else
            {
                
                tempEquipe.NomeDaEquipe = pEquipe.NomeDaEquipe;
                tempEquipe.ResumoAtividade = pEquipe.ResumoAtividade;


                base.Alterar(tempEquipe);

                

            }

        }

    }
}
