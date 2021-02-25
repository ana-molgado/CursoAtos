using cadeMedicoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cadeMedicoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<MedicoModel> Medicos{get; set;}
        public DbSet<CidadeModel> Cidades{get; set;}
        public DbSet<EspecialidadeModel> Especialidade{get; set;}
        public DbSet<UsuarioModel> Usuarios{get; set;}
        
        public DbSet<PrivilegioModel> PrivilegioModels{get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<MedicoModel>().HasData(new List<MedicoModel>(){
                new MedicoModel(1, "Ana Paula", "000000", "33330000"),
                new MedicoModel(2, "Juliana", "111111", "33331111"),
                new MedicoModel(3, "Paulo", "222222", "33332222"),
                new MedicoModel(4, "João", "333333", "33333333"),
                new MedicoModel(5, "Marcio", "444444", "33334444"),
                new MedicoModel(6, "Camila", "666666", "33335555")
            });

            builder.Entity<CidadeModel>().HasData(new List<CidadeModel>(){
                new CidadeModel(1, "Londrina", "PR"),
                new CidadeModel(2, "Cambé", "PR"),
                new CidadeModel(3, "Apucarana", "PR"),
                new CidadeModel(4, "São Paulo", "SP"),
                new CidadeModel(5, "Rolandia", "PR"),
                new CidadeModel(6, "Maringa", "PR")
            });

            builder.Entity<EspecialidadeModel>().HasData(new List<EspecialidadeModel>(){
                new EspecialidadeModel(1, "Cardiologista"),
                new EspecialidadeModel(2, "Clinico Geral"),
                new EspecialidadeModel(3, "Podologista"),
                new EspecialidadeModel(4, "Neurologista"),
                new EspecialidadeModel(5, "Pediatra"),
                new EspecialidadeModel(6, "Psiquiatra")
            });

            builder.Entity<UsuarioModel>().HasData(new List<UsuarioModel>(){
                new UsuarioModel(1, "Ana Paula", "user_ana", "123",1),
                new UsuarioModel(2, "Juliana", "user_juliana", "123", 2),
                new UsuarioModel(3, "Paulo", "user_paulo", "123", 2),
                new UsuarioModel(4, "João", "user_joao", "123", 2),
                new UsuarioModel(5, "Marcio", "user_marcio", "123", 3),
                new UsuarioModel(6, "Camila", "user_camila", "123", 3)
            });

            builder.Entity<PrivilegioModel>().HasData(new List<PrivilegioModel>(){
                new PrivilegioModel(1, "Master"),
                new PrivilegioModel(2, "Admin"),
                new PrivilegioModel(3, "User")
            });

            builder.Entity<MedicoCidade>().HasKey(MC => new{MC.MedicoId, MC.CidadeId});

            builder.Entity<MedicoCidade>().HasData(new List<MedicoCidade>(){
                new MedicoCidade() {MedicoId = 1, CidadeId = 1},
                new MedicoCidade() {MedicoId = 2, CidadeId = 4},
                new MedicoCidade() {MedicoId = 3, CidadeId = 3},
                new MedicoCidade() {MedicoId = 4, CidadeId = 3},
                new MedicoCidade() {MedicoId = 5, CidadeId = 2},
                new MedicoCidade() {MedicoId = 6, CidadeId = 1},
                new MedicoCidade() {MedicoId = 2, CidadeId = 1},
                new MedicoCidade() {MedicoId = 5, CidadeId = 5},
                new MedicoCidade() {MedicoId = 6, CidadeId = 6},
                new MedicoCidade() {MedicoId = 4, CidadeId = 2},
                new MedicoCidade() {MedicoId = 3, CidadeId = 4},
                new MedicoCidade() {MedicoId = 1, CidadeId = 5},

            });

            builder.Entity<MedicoEspecialidade>().HasKey(MC => new{MC.MedicoId, MC.EspecialidadeId});

            builder.Entity<MedicoEspecialidade>().HasData(new List<MedicoEspecialidade>(){
                new MedicoEspecialidade() {MedicoId = 1, EspecialidadeId = 1},
                new MedicoEspecialidade() {MedicoId = 2, EspecialidadeId = 4},
                new MedicoEspecialidade() {MedicoId = 3, EspecialidadeId = 3},
                new MedicoEspecialidade() {MedicoId = 4, EspecialidadeId = 3},
                new MedicoEspecialidade() {MedicoId = 5, EspecialidadeId = 2},
                new MedicoEspecialidade() {MedicoId = 6, EspecialidadeId = 1},
                new MedicoEspecialidade() {MedicoId = 2, EspecialidadeId = 1}
            });
        }
    }
}