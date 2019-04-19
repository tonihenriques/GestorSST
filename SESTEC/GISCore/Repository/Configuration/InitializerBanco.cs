using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GISModel.Entidades;

namespace GISCore.Repository.Configuration
{
    public class InitializerBanco : DropCreateDatabaseIfModelChanges<SESTECContext>
    {
        protected override void Seed(SESTECContext context)
        {
            //criar alguns dados no banco

            new List<Empregado>
            {
                new Empregado
                {
                    IDEmpregado = "14d57737-5611-4216-8f1d-cc120b16dbc3",
                    CPF ="24547551812",
                    Nome ="Antonio Heriques Pereira",
                    DataNascimento = DateTime.Now,



                },
                 new Empregado
                {
                    IDEmpregado = "d0dc096d-2929-4a85-88ff-993779d91745",
                    CPF ="24547551812",
                    Nome ="Gabriel Henriques Pereira",
                    DataNascimento = DateTime.Now,
                }

            }.ForEach(p => context.Empregado.Add(p));



            base.Seed(context);
        }
    }
}
