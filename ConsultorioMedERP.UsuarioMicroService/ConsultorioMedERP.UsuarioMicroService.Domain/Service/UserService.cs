using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using ConsultorioMedERP.UsuarioMicroService.Entity;
using ConsultorioMedERP.UsuarioMicroService.Entity.UnitofWork;

namespace ConsultorioMedERP.UsuarioMicroService.Domain.Service
{

    public class UserService<Tv, Te> : GenericService<Tv, Te>
                                                where Tv : UserViewModel
                                                where Te : User
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public UserService(IUnitOfWork unitOfWork)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
        }

        //add here any custom service method or override generic service method
        public bool DoNothing()
        {
            return true;
        }
    }

}
