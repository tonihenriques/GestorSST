using GISCore.Business.Abstract;
using GISModel.DTO.Departamento;
using GISModel.Entidades;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Business.Concrete
{
    public class DepartamentoBusiness : BaseBusiness<Departamento>, IDepartamentoBusiness
    {

        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        [Inject]
        public IEmpresaBusiness ContratoBusiness { get; set; }

        public override void Inserir(Departamento pDepartamento)
        {

            //pDepartamento.Status = GISModel.Enums.Situacao.Ativo;

            //if (!EmpresaBusiness.Consulta.Any(p => p.IDEmpresa.Equals(pDepartamento.IDEmpresa)))
            //    throw new Exception("Não foi possível localizar a empresa informada.");
            
            //if (Consulta.Any(u => u.Codigo.Equals(pDepartamento.Codigo.Trim()) && u.IDEmpresa.Equals(pDepartamento.IDEmpresa)))
            //    throw new InvalidOperationException("Não é possível inserir o departamento, pois já existe um departamento com este código para esta empresa.");

            //if (Consulta.Any(u => u.Sigla.ToUpper().Equals(pDepartamento.Sigla.Trim().ToUpper()) && u.IDEmpresa.Equals(pDepartamento.IDEmpresa)))
            //    throw new InvalidOperationException("Não é possível inserir o departamento, pois já existe um departamento com esta sigla para esta empresa.");

            pDepartamento.IDDepartamento = Guid.NewGuid().ToString();

            base.Inserir(pDepartamento);

        }
        public override void Alterar(Departamento pDepartamento)
        {
            
            //if (Consulta.Any(u => u.Sigla.ToUpper().Equals(pDepartamento.Sigla.Trim().ToUpper()) && !u.IDDepartamento.Equals(pDepartamento.IDDepartamento)))
            //    throw new InvalidOperationException("Não é possível atualizar este Departamento.");

            Departamento tempDepartamento = Consulta.FirstOrDefault(p => p.IDDepartamento.Equals(pDepartamento.IDDepartamento));
            if (tempDepartamento == null)
            {
                throw new Exception("Não foi possível encontrar o departamento através do ID.");
            }
            else
            {
                
                //tempDepartamento.Codigo = pDepartamento.Codigo;
                //tempDepartamento.Sigla = pDepartamento.Sigla;
                //tempDepartamento.Descricao = pDepartamento.Descricao;
                

                base.Alterar(tempDepartamento);

                

            }

        }

        public override void Excluir(Departamento pDepartamento)
        {
                                    
            base.Alterar(pDepartamento);

        }

    }


}
