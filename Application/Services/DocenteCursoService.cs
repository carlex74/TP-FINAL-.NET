

using ApplicationClean.Interfaces.Repositories;
using ApplicationClean.Interfaces.Services;

namespace ApplicationClean.Services
{
    public class DocenteCursoService: IDocenteCursoService
    {
        private readonly IDocenteCursoRepository _repository;

        public DocenteCursoService(IDocenteCursoRepository repository)
        {
            _repository = repository;
        }




    }
}
