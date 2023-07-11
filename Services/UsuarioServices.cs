﻿using ProyectoFinal23AM.Context;
using ProyectoFinal23AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23AM.Services
{
    public class UsuarioServices
    {
		//CREACION DEL CRUD
        public void AddUser(Usuario request)
        {
			try
			{
				if (request != null)
				{
					using (var _context = new ApplicationDbContext())
					//LOS CORCHETES REPRESENTAN EL ABRIR Y CERRAR LA BASE DE DATOS
					{
						Usuario res = new Usuario();
						res.Nombre = request.Nombre;
						res.UserName = request.UserName;
						res.Password = request.Password;
						//res.FkRol = request.FkRol;
						_context.Usuarios.Add(res);
						_context.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{

				throw new Exception("ERROR: " + ex.Message);
			}
        }
    }
}
