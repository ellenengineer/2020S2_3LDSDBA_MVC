using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MVC.Models;

namespace MVC
{
    public partial class INFONEWContext : DbContext
    {
        public INFONEWContext()
        {
        }

        public INFONEWContext(DbContextOptions<INFONEWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bonus> Bonus { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Conjuge> Conjuge { get; set; }
        public virtual DbSet<Credito> Credito { get; set; }
        public virtual DbSet<Dependente> Dependente { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Fone> Fone { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }
        public virtual DbSet<Itens> Itens { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Parcela> Parcela { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Pontuacao> Pontuacao { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<StatusPedido> StatusPedido { get; set; }
        public virtual DbSet<TipoCli> TipoCli { get; set; }
        public virtual DbSet<TipoEnd> TipoEnd { get; set; }
        public virtual DbSet<TipoProd> TipoProd { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=(local);database=INFONEW;integrated security=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bonus>(entity =>
            {
                entity.HasKey(e => e.NumLanc);

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataBonus)
                    .HasColumnName("Data_Bonus")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValBonus)
                    .HasColumnName("Val_Bonus")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Bonus)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bonus");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.CodCid)
                    .HasName("PK_Cid");

                entity.Property(e => e.CodCid)
                    .HasColumnName("Cod_Cid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodEst).HasColumnName("Cod_est");

                entity.Property(e => e.NomeCid)
                    .IsRequired()
                    .HasColumnName("Nome_Cid")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.CodEst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cid");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCli)
                    .HasName("PK_Cli");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.CodTipoCli).HasColumnName("Cod_TipoCli");

                entity.Property(e => e.DataCadCli)
                    .HasColumnName("Data_CadCli")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NomeCli)
                    .IsRequired()
                    .HasColumnName("Nome_Cli")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RendaCli)
                    .HasColumnName("Renda_Cli")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SexoCli)
                    .IsRequired()
                    .HasColumnName("Sexo_Cli")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('F')");

                entity.HasOne(d => d.CodTipoCliNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.CodTipoCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cli");
            });

            modelBuilder.Entity<Conjuge>(entity =>
            {
                entity.HasKey(e => e.CodCli)
                    .HasName("PK_Conj");

                entity.Property(e => e.CodCli)
                    .HasColumnName("Cod_Cli")
                    .ValueGeneratedNever();

                entity.Property(e => e.NomeConj)
                    .IsRequired()
                    .HasColumnName("Nome_Conj")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RendaConj)
                    .HasColumnName("Renda_Conj")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SexoConj)
                    .IsRequired()
                    .HasColumnName("Sexo_Conj")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithOne(p => p.Conjuge)
                    .HasForeignKey<Conjuge>(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conj");
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.HasKey(e => e.NumLanc)
                    .HasName("PK_Cred");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.CredCli)
                    .HasColumnName("Cred_Cli")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DataCredCli)
                    .HasColumnName("Data_CredCli")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Credito)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cred");
            });

            modelBuilder.Entity<Dependente>(entity =>
            {
                entity.HasKey(e => e.CodDep)
                    .HasName("PK_Dep");

                entity.Property(e => e.CodDep).HasColumnName("Cod_Dep");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataNascDep)
                    .HasColumnName("Data_NascDep")
                    .HasColumnType("datetime");

                entity.Property(e => e.NomeDep)
                    .IsRequired()
                    .HasColumnName("Nome_Dep")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SexoDep)
                    .IsRequired()
                    .HasColumnName("Sexo_Dep")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('F')");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Dependente)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dep");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.NumLanc)
                    .HasName("PK_Email");

                entity.ToTable("EMail");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.EmailCli)
                    .IsRequired()
                    .HasColumnName("EMail_Cli")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emails");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.CodEnd)
                    .HasName("PK_End");

                entity.Property(e => e.CodEnd).HasColumnName("Cod_End");

                entity.Property(e => e.CodCid).HasColumnName("Cod_Cid");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.CodTipoEnd).HasColumnName("Cod_TipoEnd");

                entity.Property(e => e.ComplEnd)
                    .HasColumnName("Compl_End")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeBairro)
                    .IsRequired()
                    .HasColumnName("Nome_Bairro")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeRua)
                    .IsRequired()
                    .HasColumnName("Nome_Rua")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodC)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.CodCid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_End2");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_End3");

                entity.HasOne(d => d.CodTipoEndNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.CodTipoEnd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_End1");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.CodEst)
                    .HasName("PK_Est");

                entity.Property(e => e.CodEst).HasColumnName("Cod_Est");

                entity.Property(e => e.CodPais).HasColumnName("Cod_Pais");

                entity.Property(e => e.NomeEst)
                    .IsRequired()
                    .HasColumnName("Nome_Est")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SiglaEst)
                    .IsRequired()
                    .HasColumnName("sigla_est")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CodPaisNavigation)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.CodPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Est1");
            });

            modelBuilder.Entity<Fone>(entity =>
            {
                entity.HasKey(e => e.NumLanc);

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.NumDdd)
                    .IsRequired()
                    .HasColumnName("Num_DDD")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('011')");

                entity.Property(e => e.NumFone)
                    .IsRequired()
                    .HasColumnName("Num_Fone")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Fone)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fone");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.CodFunc)
                    .HasName("PK_Func");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataCadFunc)
                    .HasColumnName("Data_CadFunc")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndFunc)
                    .IsRequired()
                    .HasColumnName("End_Func")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFunc)
                    .IsRequired()
                    .HasColumnName("Nome_Func")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SalFunc)
                    .HasColumnName("Sal_Func")
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.SexoFunc)
                    .IsRequired()
                    .HasColumnName("Sexo_Func")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('F')");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => e.NumLanc)
                    .HasName("PK_Hist");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataHist)
                    .HasColumnName("Data_Hist")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SalAnt)
                    .HasColumnName("Sal_Ant")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalAtual)
                    .HasColumnName("Sal_Atual")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hist");
            });

            modelBuilder.Entity<Itens>(entity =>
            {
                entity.HasKey(e => new { e.NumPed, e.CodProd });

                entity.Property(e => e.NumPed).HasColumnName("Num_Ped");

                entity.Property(e => e.CodProd).HasColumnName("Cod_Prod");

                entity.Property(e => e.QtdVend).HasColumnName("Qtd_Vend");

                entity.Property(e => e.ValVend)
                    .HasColumnName("Val_Vend")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CodProdNavigation)
                    .WithMany(p => p.Itens)
                    .HasForeignKey(d => d.CodProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Itens2");

                entity.HasOne(d => d.NumPedNavigation)
                    .WithMany(p => p.Itens)
                    .HasForeignKey(d => d.NumPed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Itens1");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.Login1)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cod_Cli_FK");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.CodPais)
                    .HasName("PK_pais");

                entity.Property(e => e.CodPais)
                    .HasColumnName("Cod_pais")
                    .ValueGeneratedNever();

                entity.Property(e => e.NomePais)
                    .IsRequired()
                    .HasColumnName("Nome_pais")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parcela>(entity =>
            {
                entity.HasKey(e => new { e.NumPar, e.NumPed });

                entity.Property(e => e.NumPar).HasColumnName("Num_Par");

                entity.Property(e => e.NumPed).HasColumnName("Num_Ped");

                entity.Property(e => e.DataPgto)
                    .HasColumnName("Data_Pgto")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataVenc)
                    .HasColumnName("Data_Venc")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValPgto)
                    .HasColumnName("Val_Pgto")
                    .HasColumnType("numeric(13, 3)")
                    .HasComputedColumnSql("(case when [Data_Pgto]<[Data_Venc] then [Val_Venc]*(0.9) when [Data_Pgto]=[Data_Venc] then [Val_Venc] when [Data_Pgto]>[Data_Venc] then [Val_Venc]*(1.1)  end)");

                entity.Property(e => e.ValVenc)
                    .HasColumnName("Val_Venc")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.NumPedNavigation)
                    .WithMany(p => p.Parcela)
                    .HasForeignKey(d => d.NumPed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parcela");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.NumPed);

                entity.Property(e => e.NumPed).HasColumnName("Num_Ped");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.CodSta).HasColumnName("Cod_Sta");

                entity.Property(e => e.DataPed)
                    .HasColumnName("Data_Ped")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QtdePed).HasColumnName("Qtde_Ped");

                entity.Property(e => e.ValPed)
                    .HasColumnName("Val_Ped")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido1");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido2");

                entity.HasOne(d => d.CodStaNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.CodSta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido3");
            });

            modelBuilder.Entity<Pontuacao>(entity =>
            {
                entity.HasKey(e => e.NumLanc)
                    .HasName("PK_Pto");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataPto)
                    .HasColumnName("Data_Pto")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PtoFunc)
                    .HasColumnName("Pto_Func")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Pontuacao)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pto");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CodProd)
                    .HasName("PK_Prod");

                entity.HasIndex(e => e.NomeProd)
                    .HasName("UQ_Prod")
                    .IsUnique();

                entity.Property(e => e.CodProd).HasColumnName("Cod_Prod");

                entity.Property(e => e.CodTipoProd).HasColumnName("Cod_TipoProd");

                entity.Property(e => e.NomeProd)
                    .IsRequired()
                    .HasColumnName("Nome_Prod")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtdEstqProd).HasColumnName("Qtd_EstqProd");

                entity.Property(e => e.ValTotal)
                    .HasColumnName("Val_Total")
                    .HasColumnType("decimal(21, 2)")
                    .HasComputedColumnSql("([Qtd_EstqProd]*[Val_UnitProd])");

                entity.Property(e => e.ValUnitProd)
                    .HasColumnName("Val_UnitProd")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CodTipoProdNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.CodTipoProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prod");
            });

            modelBuilder.Entity<StatusPedido>(entity =>
            {
                entity.HasKey(e => e.CodSta)
                    .HasName("PK_StatusPed");

                entity.HasIndex(e => e.StaPed)
                    .HasName("UQ_StatusPed")
                    .IsUnique();

                entity.Property(e => e.CodSta).HasColumnName("Cod_Sta");

                entity.Property(e => e.StaPed)
                    .IsRequired()
                    .HasColumnName("Sta_Ped")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCli>(entity =>
            {
                entity.HasKey(e => e.CodTipoCli);

                entity.HasIndex(e => e.NomeTipoCli)
                    .HasName("UQ_TipoCli")
                    .IsUnique();

                entity.Property(e => e.CodTipoCli).HasColumnName("Cod_TipoCli");

                entity.Property(e => e.NomeTipoCli)
                    .IsRequired()
                    .HasColumnName("Nome_TipoCli")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEnd>(entity =>
            {
                entity.HasKey(e => e.CodTipoEnd);

                entity.HasIndex(e => e.NomeTipoEnd)
                    .HasName("UQ_TipoEnd")
                    .IsUnique();

                entity.Property(e => e.CodTipoEnd).HasColumnName("Cod_TipoEnd");

                entity.Property(e => e.NomeTipoEnd)
                    .IsRequired()
                    .HasColumnName("Nome_TipoEnd")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProd>(entity =>
            {
                entity.HasKey(e => e.CodTipoProd);

                entity.HasIndex(e => e.NomeTipoProd)
                    .HasName("UQ_TipoProd")
                    .IsUnique();

                entity.Property(e => e.CodTipoProd).HasColumnName("Cod_TipoProd");

                entity.Property(e => e.NomeTipoProd)
                    .IsRequired()
                    .HasColumnName("Nome_TipoProd")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
