﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using ConsultorioMedERP.UsuarioMicroService.Entity;
using ConsultorioMedERP.UsuarioMicroService.Entity.UnitofWork;

namespace ConsultorioMedERP.UsuarioMicroService.Domain.Service
{

    public class UserServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                                where Tv : UserViewModel
                                                where Te : User
    {
        //DI must be implemented specific service as well beside GenericAsyncService constructor
        public UserServiceAsync(IUnitOfWork unitOfWork)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
        }

        //add here any custom service method or override genericasync service method
        //...
    }

}
