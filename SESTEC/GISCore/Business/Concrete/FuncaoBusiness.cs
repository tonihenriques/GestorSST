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
    public class FuncaoBusiness : BaseBusiness<Funcao>, IFuncaoBusiness
    {

        public override void Inserir(Funcao pFuncao)
        {

            if (Consulta.Any(u => u.IDFuncao.Equals(pFuncao.IDFuncao)))

                throw new InvalidOperationException("Não é possível inserir A Função, pois já existe uma Função com este ID.");

            pFuncao.IDFuncao = Guid.NewGuid().ToString();

            base.Inserir(pFuncao);

            
        }

        public override void Alterar(Funcao pFuncao)
        {
            Funcao tempFuncao = Consulta.FirstOrDefault(p => p.IDFuncao.Equals(pFuncao.IDFuncao));

            if (tempFuncao == null)
            {
                throw new Exception("não foi possível encontrar esta Função");
            }

            tempFuncao.NomeDaFuncao = pFuncao.NomeDaFuncao;
            

            base.Alterar(tempFuncao);

        }

    }
}
