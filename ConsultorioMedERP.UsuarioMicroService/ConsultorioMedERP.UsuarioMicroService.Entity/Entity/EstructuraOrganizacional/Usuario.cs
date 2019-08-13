using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedERP.UsuarioMicroService.Entity.EstructuraOrganizacional
{
    [Table("USUARIO")]
    public class Usuario: BaseEntity
    {
        
        public string NOMBRE { get; set; }
        //public string ApellidoPaterno { get; set; }
        //public string ApellidoMaterno { get; set; }
        //private int _oficinaId;
        //public int OficinaId { get; set; }//{ get { return _oficinaId; }  set { _oficinaId = value; } }
        //private int _rolId;
        //public int RolId { get; set; }
        //{ get { return _rolId; } set { _rolId = value; } }
        //public void AgregarOFicina(int oficinaId)
        //{
        //    _oficinaId = oficinaId;
        //}
        //public void AgregarRol (int rolId)
        //{
        //    _rolId = rolId;
        //}
        //public string NombreCompleto 
        //{
        //    get
        //    {
        //        return string.Format("{0} {1} {2}", Nombre, ApellidoPaterno, ApellidoMaterno);
        //    }
        //}

        //public bool Validar()
        //{
        //    var esValido = true;
        //    if (string.IsNullOrWhiteSpace(Nombre)) esValido = false;
        //    if (string.IsNullOrWhiteSpace(ApellidoPaterno)) esValido = false;
        //    if (OficinaId == 0) esValido = false;
        //    if (RolId == 0) esValido = false;
        //    return esValido;
        //}
    }
}
