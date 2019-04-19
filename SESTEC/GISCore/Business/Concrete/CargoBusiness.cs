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
    public class CargoBusiness : BaseBusiness<Cargo>, ICargoBusiness
    {

        public override void Inserir(Cargo pCargo)
        {

            if (Consulta.Any(u => u.IDCargo.Equals(pCargo.IDCargo)))

                throw new InvalidOperationException("Não é possível inserir o Cargo, pois já existe um Cargo com este ID.");

            pCargo.IDCargo = Guid.NewGuid().ToString();

            base.Inserir(pCargo);

            
        }

        public override void Alterar(Cargo pCargo)
        {
            Cargo tempCargo = Consulta.FirstOrDefault(p => p.IDCargo.Equals(pCargo.IDCargo));

            if (tempCargo == null)
            {
                throw new Exception("não foi possível encontrar este Cargo");
            }

            tempCargo.NomeDoCargo = pCargo.NomeDoCargo;
            

            base.Alterar(tempCargo);

        }

    }
}
