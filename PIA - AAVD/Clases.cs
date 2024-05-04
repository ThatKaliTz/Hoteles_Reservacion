using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA___MAD
{
    public class Clases
    {
        public class Usuario
        {        
            public string correo_electronico { get; set; }
            public string nombre { get; set; }
            public string contrasenia { get; set; }
            public string domicilio { get; set; }
            public int telefono { get; set; }
            public int num_nomina { get; set; }
            public DateTime fecha_registro { get; set; }
            public DateTime hora_registro { get; set; }
        }

        public class Cliente
        {
            public string rfc { get; set; }
            public string nombre_cliente { get; set; }
            public string domicilio_cliente { get; set; }
            public string referencia { get; set; }
            public int telefono { get; set; }
            public DateTime fechanacim_cliente { get; set; }
            public int id_habitacion { get; set; }
        }

        public class Hotel
        {
            public int id_hotel { get; set; }
            public string nombre_hotel { get; set; }
            public string ubicacion { get; set; }
            public string domicilio { get; set; }
            public int numero_pisos { get; set; }
            public int cantodad_habitaciones { get; set; }
            public string id_usuario { get; set; }
            public DateTime fecha_registro { get; set; }
            public DateTime hora_registro { get; set; }
        }

        public class Habitacion
        {
            public int id_habitacion { get; set; }
            public float precio_noche { get; set; }
            public int cantidad_personas { get; set; }
            public int numero_camas { get; set; }
            public string tipo_camas { get; set; }
            public string nivel_habitacion { get; set; }
            public bool amenidad_piscina { get; set; }
            public bool amenidad_playa { get; set; }
            public bool amenidad_jardin { get; set; }
            public int codigo_reservacion { get; set; }
            public DateTime fecha_registro { get; set; }
            public DateTime hora_registro { get; set; }
            public DateTime fecha_reservacion { get; set; }
            public DateTime hora_reservacion { get; set; }
            public int idhotel_hab { get; set; }
            public int idusuario { get; set; }
        }
    }
}
