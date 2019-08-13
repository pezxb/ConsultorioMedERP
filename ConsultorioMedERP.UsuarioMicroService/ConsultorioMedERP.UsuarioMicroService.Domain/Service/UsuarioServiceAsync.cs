using AutoMapper;
using ConsultorioMedERP.UsuarioMicroService.Entity.EstructuraOrganizacional;
using ConsultorioMedERP.UsuarioMicroService.Entity.UnitofWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuarioMicroService.Domain.Service
{
    public class UsuarioServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : UsuarioViewModel
                                        where Te : Usuario
    {
        ////DI must be implemented in specific service as well beside GenericService constructor
        public UsuarioServiceAsync(IUnitOfWork unitOfWork)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
        }

        public override async Task<IEnumerable<Tv>> GetAll()
        {
            var entities = await _unitOfWork.GetRepositoryAsync<Te>().
            return Mapper.Map<IEnumerable<Tv>>(source: entities);
        }

        ////add here any custom service method or override generic service method
        public bool DoNothing()
        {
            return true;
        }
    }
}
