using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using ConsultorioMedERP.UsuarioMicroService.Entity;
using ConsultorioMedERP.UsuarioMicroService.Entity.UnitofWork;

namespace ConsultorioMedERP.UsuarioMicroService.Domain.Service
{

    public class AccountServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : AccountViewModel
                                        where Te : Account
    {
        //DI must be implemented specific service as well beside GenericAsyncService constructor
        public AccountServiceAsync(IUnitOfWork unitOfWork)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
        }

        //add here any custom service method or override genericasync service method
        //...
    }

}
