using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Proyecto_Eventos.Models;

namespace Proyecto_Eventos.Controllers
{

    public class Usuario_LoginController : Controller
    {


        //Vamos a realizar la conexion a la base de datos
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        //Vamos a hacer la variable que nos leerá la información de la base
        SqlDataReader lector;

        //Damos el string connection
        void connectionString()
        {
            conexion.ConnectionString = "data source=DESKTOP-LLA3PTJ; database=BD_Proyecto_Eventos; integrated security = SSPI;";
        }


        public ActionResult Login()
        { 
            return View();
        }


            [HttpPost]
        public ActionResult Login(Usuario_Login usu)
        {

            //Llamamos al string de conexion y abrimos la conexion
            connectionString();

            comando.CommandText = "[dbo].[spConfirmacionLogin]";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Connection = conexion;

            //Agregamos los parametros de entrada para el procedimiento almacenado
            comando.Parameters.Add("@pUsuario", System.Data.SqlDbType.VarChar, 50).Value = usu.nombre_Usuario;
            comando.Parameters.Add("@pClave", System.Data.SqlDbType.VarChar, 50).Value = usu.contrasena;


            //Abrimos la conexion
            conexion.Open();

            //Ejecutamos lo anterior como un query en sql
            lector = comando.ExecuteReader();

            if (lector.Read()) //Si se inició correctamente la sesión
            {
                //Se guarda el nombre de usuario en Session para que se compartir la variable en el mvc
                Session["UsuLog"] = usu.nombre_Usuario;
                //Response.Cookies.Append
                //Response.Cookies.Append("usu", "Bienvenido " + usu.nombre_Usuario); //Con esto puedo mantener la sesion activa por medio de cookies

                //Cerramos la conexion
                conexion.Close();

                return RedirectToAction("Index", "Administrador");
            }
            else
            {
                //Se muestra el View del login nuevamente porque no hubo un buen inicio de sesion

                //Cerramos la conexion
                conexion.Close();

                ViewBag.Mensaje = "Usuario o contraseña incorrecto";

                return RedirectToAction("Login", "Usuario_Login");
            }
        }

        public ActionResult LogOut()
        {
            //Response.Cookies.Delete("usu"); Con esto cerramos la sesion en las cookies
            return View();
        }

    }
}














