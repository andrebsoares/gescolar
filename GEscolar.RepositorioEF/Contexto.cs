using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GEscolar.Dominio;

namespace GEscolar.RepositorioEF
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("GEscolarConfig")
        {

        }

        public DbSet<gesc_aluno> gesc_aluno { get; set; }

        public DbSet<gesc_curso> gesc_curso { get; set; }

        public DbSet<gesc_disciplina> gesc_disciplina { get; set; }

        public DbSet<gesc_professor> gesc_professor { get; set; }

        public DbSet<gesc_turma> gesc_turma { get; set; }

        public DbSet<gesc_alunoturma> gesc_alunoturma { get; set; }

        public DbSet<gesc_disciplinaturma> gesc_disciplinaturma { get; set; }

        public DbSet<gesc_falta> gesc_falta { get; set; }                

        public DbSet<gesc_nota> gesc_nota { get; set; }             
                        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            //gesc_aluno = Campos da tabela de aluno
            modelBuilder.Entity<gesc_aluno>().ToTable("gesc_aluno");
            modelBuilder.Entity<gesc_aluno>().HasKey(x => x.ALU_IN_CODIGO);
            modelBuilder.Entity<gesc_aluno>().Property(x => x.ALU_ST_NOME).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<gesc_aluno>().Property(x => x.ALU_ST_CPF).IsRequired().HasColumnType("varchar").HasMaxLength(11);
            modelBuilder.Entity<gesc_aluno>().Property(x => x.ALU_ST_SENHA).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            modelBuilder.Entity<gesc_aluno>().Property(x => x.ALU_CH_STATUS).IsRequired().HasColumnType("char").HasMaxLength(1);

            //gesc_curso = Campos da tabela de curso
            modelBuilder.Entity<gesc_curso>().ToTable("gesc_curso");
            modelBuilder.Entity<gesc_curso>().HasKey(x => x.CUR_IN_CODIGO);
            modelBuilder.Entity<gesc_curso>().Property(x => x.CUR_ST_DESCRICAO).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<gesc_curso>().Property(x => x.CUR_IN_DURACAO).IsRequired().HasColumnType("int");
            modelBuilder.Entity<gesc_curso>().Property(x => x.CUR_CH_TIPO).IsRequired().HasColumnType("char").HasMaxLength(1);

            //ges_disciplina = Campos da tabela disciplina
            modelBuilder.Entity<gesc_disciplina>().ToTable("gesc_disciplina");
            modelBuilder.Entity<gesc_disciplina>().HasKey(x => x.DIS_IN_CODIGO);
            modelBuilder.Entity<gesc_disciplina>().Property(x => x.DIS_ST_DESCRICAO).IsRequired().HasColumnType("varchar").HasMaxLength(50);

            //ges_usuario = Campos da tabela usuário
            modelBuilder.Entity<gesc_professor>().ToTable("gesc_professor");
            modelBuilder.Entity<gesc_professor>().HasKey(x => x.PRO_IN_CODIGO);
            modelBuilder.Entity<gesc_professor>().Property(x => x.PRO_ST_NOME).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<gesc_professor>().Property(x => x.PRO_ST_CPF).IsRequired().HasColumnType("varchar").HasMaxLength(14);
            modelBuilder.Entity<gesc_professor>().Property(x => x.PRO_ST_SENHA).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            modelBuilder.Entity<gesc_professor>().Property(x => x.PRO_CH_TIPO).IsRequired().HasColumnType("char").HasMaxLength(1);
            modelBuilder.Entity<gesc_professor>().Property(x => x.PRO_ST_EMAIL).IsRequired().HasColumnType("varchar").HasMaxLength(50);

            //gesc_professor = Campos da tabela turma ( FK- CUR_IN_CODIGO - Tabela Curso ( gesc_curso ) )
            modelBuilder.Entity<gesc_turma>().ToTable("gesc_turma");
            modelBuilder.Entity<gesc_turma>().HasKey(x => x.TUR_IN_CODIGO);
            modelBuilder.Entity<gesc_turma>().Property(x => x.TUR_ST_DESCRICAO).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<gesc_turma>().Property(x => x.TUR_CH_PERIODO).IsRequired().HasColumnType("char").HasMaxLength(1);
            modelBuilder.Entity<gesc_turma>().HasRequired(x => x.Cursos).WithMany(d => d.Turmas).HasForeignKey(p => p.CUR_IN_CODIGO).WillCascadeOnDelete(false);

            //gesc_alunoturma = Campos da tabela aluno turma (FK - ALU_IN_CODIGO - Tabela Aluno ( gesc_aluno ) e TUR_IN_CODIGO - Tabela Turma ( gesc_tuma )
            modelBuilder.Entity<gesc_alunoturma>().ToTable("gesc_alunoturma");
            modelBuilder.Entity<gesc_alunoturma>().HasKey(x => x.ALT_IN_CODIGO);
            modelBuilder.Entity<gesc_alunoturma>().Property(x => x.ALU_IN_CODIGO).IsRequired().HasColumnType("int");
            modelBuilder.Entity<gesc_alunoturma>().Property(x => x.TUR_IN_CODIGO).IsRequired().HasColumnType("int");
            modelBuilder.Entity<gesc_alunoturma>().Property(x => x.ALT_CH_STATUS).IsRequired().HasColumnType("char").HasMaxLength(1);
            modelBuilder.Entity<gesc_alunoturma>().HasRequired(x => x.Alunos).WithMany(d => d.AlunosTurma).HasForeignKey(p => p.ALU_IN_CODIGO).WillCascadeOnDelete(false);
            modelBuilder.Entity<gesc_alunoturma>().HasRequired(x => x.Turmas).WithMany(d => d.AlunosTurmas).HasForeignKey(p => p.TUR_IN_CODIGO).WillCascadeOnDelete(false);
            
            //gesc_disciplinaturma = Campos da tabela disciplina turma (FK- Tabela Turmas, Disciplinas e Professores)
            modelBuilder.Entity<gesc_disciplinaturma>().ToTable("gesc_disciplinaturma");
            modelBuilder.Entity<gesc_disciplinaturma>().HasKey(x => x.DTU_IN_CODIGO);
            modelBuilder.Entity<gesc_disciplinaturma>().HasRequired(x => x.Turmas).WithMany(d => d.DisciplinasTurmas).HasForeignKey(p => p.TUR_IN_CODIGO).WillCascadeOnDelete(false);
            modelBuilder.Entity<gesc_disciplinaturma>().HasRequired(x => x.Disciplinas).WithMany(d => d.DisciplinasTurmas).HasForeignKey(p => p.DIS_IN_CODIGO).WillCascadeOnDelete(false);
            modelBuilder.Entity<gesc_disciplinaturma>().HasRequired(x => x.Professores).WithMany(d => d.DisciplinasTurmas).HasForeignKey(p => p.PRO_IN_CODIGO).WillCascadeOnDelete(false);

            //gesc_falta = Campos da tabela falta (FK - Tabela Aluno Turma, Disciplina Turma)
            modelBuilder.Entity<gesc_falta>().ToTable("gesc_falta");
            modelBuilder.Entity<gesc_falta>().HasKey(x => x.FAL_IN_CODIGO);
            modelBuilder.Entity<gesc_falta>().Property(x => x.FAL_IN_QTDE).IsRequired().HasColumnType("int");
            modelBuilder.Entity<gesc_falta>().Property(x => x.FAL_DT_DIA).IsRequired().HasColumnType("DateTime");
            modelBuilder.Entity<gesc_falta>().HasRequired(x => x.AlunoTurmas).WithMany(d => d.Faltas).HasForeignKey(p => p.ALT_IN_CODIGO).WillCascadeOnDelete(false);
            modelBuilder.Entity<gesc_falta>().HasRequired(x => x.DisciplinasTurmas).WithMany(d => d.Faltas).HasForeignKey(p => p.DTU_IN_CODIGO).WillCascadeOnDelete(false);

            //gesc_nota = Campos da tabela (FK - Tabela 
            modelBuilder.Entity<gesc_nota>().ToTable("gesc_nota");
            modelBuilder.Entity<gesc_nota>().HasKey(x => x.NOT_IN_CODIGO);
            modelBuilder.Entity<gesc_nota>().Property(x => x.NOT_DE_NOTA).IsRequired().HasColumnType("decimal");
            modelBuilder.Entity<gesc_nota>().HasRequired(x => x.DisciplinasTurmas).WithMany(d => d.Notas).HasForeignKey(p => p.DTU_IN_CODIGO).WillCascadeOnDelete(false);
            modelBuilder.Entity<gesc_nota>().HasRequired(x => x.ALunosTurmas).WithMany(d => d.Notas).HasForeignKey(p => p.ALT_IN_CODIGO).WillCascadeOnDelete(false);

        }
    }
}
