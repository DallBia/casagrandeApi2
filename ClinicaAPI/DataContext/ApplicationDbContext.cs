using ClinicaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AgendaModel> Agendas { get; set; }
        public DbSet<DonoSalaModel> DonoSalas { get; set; }
        public DbSet<EscolaModel> Escolas { get; set; }
        public DbSet<FormacaoModel> Formacaos { get; set; }
        public DbSet<PerfilModel> Perfils { get; set; }
        public DbSet<DocumentoModel> Documentos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProntuarioModel> Prontuarios { get; set; }
    }
}
