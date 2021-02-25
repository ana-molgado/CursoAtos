using System.Threading.Tasks;
using cadeMedicoApi.Models;

namespace cadeMedicoApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // medico

        Task<MedicoModel[]> GetAllMedicoModelAsync(bool includeMedico);

        Task<MedicoModel[]> GetMedicoModelByEspecialidadeId(int especialidadeId, bool includeEspecialidade);

        Task<MedicoModel> GetMedicoModelById(int medicoId,bool includeCidade);

        //cidade 

        Task<CidadeModel[]> GetAllCidadeModelAsync(bool includeMedico);
        Task<CidadeModel> GetCidadeModelById(int cidadeId, bool includeMedico);

        //Usuario
        Task<UsuarioModel[]> GetAllUsuarioModelAsync();
        Task<UsuarioModel> GetUsuarioModelById(int usuarioId);
    }
}