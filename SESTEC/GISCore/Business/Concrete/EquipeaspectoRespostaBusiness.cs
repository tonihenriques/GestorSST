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
    public class EquipeAspectoRespostaBusiness : BaseBusiness<EquipeAspectoResposta>, IEquipeAspectoRespostaBusiness
    {

        public override void Inserir(EquipeAspectoResposta pEquipeAspectoResposta)
        {

           
            pEquipeAspectoResposta.IDEquipeAspecto = Guid.NewGuid().ToString();
            
            base.Inserir(pEquipeAspectoResposta);

            

        }

        public override void Alterar(EquipeAspectoResposta pEquipeAspectoResposta)
        {

            EquipeAspectoResposta tempEquipeAspectoResposta = Consulta.FirstOrDefault(p => p.IDEquipeAspecto.Equals(pEquipeAspectoResposta.IDEquipeAspecto));
            if (tempEquipeAspectoResposta == null)
            {
                throw new Exception("Não foi possível encontrar este item!");
            }
            else
            {

                tempEquipeAspectoResposta.idEquipe = pEquipeAspectoResposta.idEquipe;
                tempEquipeAspectoResposta.idAspecto = pEquipeAspectoResposta.idAspecto;
                tempEquipeAspectoResposta.idPergunta = pEquipeAspectoResposta.idPergunta;
                tempEquipeAspectoResposta.Sim_Nao = pEquipeAspectoResposta.Sim_Nao;

                base.Alterar(tempEquipeAspectoResposta);


            }

        }

    }
}
