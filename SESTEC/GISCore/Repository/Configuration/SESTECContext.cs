﻿using GISModel.Entidades;
using System.Data.Entity;

namespace GISCore.Repository.Configuration
{
    public class SESTECContext : DbContext
    {

        public SESTECContext() : base("SESTECConection")
        {
            Database.SetInitializer<SESTECContext>(null);
        }


        public DbSet<AtividadeFuncaoLiberada> AtividadeFuncaoLiberada { get; set; }

        public DbSet<DocAtividade> DocAtividade { get; set; }

        public DbSet<DocsPorAtividade> DocsPorAtividade { get; set; }

        public DbSet<DocumentosPessoal> DocumentosPessoal { get; set; }

        public DbSet<AnaliseRisco> AnaliseRisco { get; set; }
        
        public DbSet<Rel_AtivEstabTipoRisco> Rel_AtivEstabTipoRisco { get; set; }

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<Estabelecimento> Estabelecimento { get; set; }

        public DbSet<Contrato> Contrato { get; set; }

        public DbSet<AtividadesDoEstabelecimento> AtividadesDoEstabelecimento { get; set; }

        public DbSet<TipoDeRisco> TipoDeRisco { get; set; }

        public DbSet<MedidasDeControleExistentes> MedidasDeControleExistentes { get; set; }

        public DbSet<PossiveisDanos> PossiveisDanos { get; set; }

        public DbSet<EventoPerigoso> EventoPerigoso { get; set; }

        public DbSet<EstabelecimentoAmbiente> EstabelecimentoAmbiente { get; set; }

        public DbSet<Empregado> Empregado { get; set; }

        public DbSet<Admissao> Admissao { get; set; }

        public DbSet<Cargo> Cargo { get; set; }

        public DbSet<Funcao> Funcao { get; set; }

        public DbSet<Atividade> Atividade { get; set; }

        public DbSet<Alocacao> Alocacao { get; set; }

        public DbSet<Equipe> Equipe { get; set; }

        public DbSet<AtividadeAlocada> AtividadeAlocada { get; set; }

        public DbSet<PlanoDeAcao> PlanoDeAcao { get; set; }

        public DbSet<Exposicao> Exposicao { get; set; }

        public DbSet<PerigoPotencial> PerigoPotencial { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Aspecto> Aspecto { get; set; }

        public DbSet<EquipeAspectoResposta> EquipeAspectoResposta { get; set; }

        public DbSet<Pergunta> Pergunta { get; set; }

        public DbSet<AspectoPergunta> AspectoPergunta { get; set; }

    }
}
