using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PruebaMySQL
{
    public partial class Form1 : Form
    {
        //la linea que guarda la ip del sevidor MuSql, el usuario y la pass
        String cadenaConexion;
        MySqlConnection conexion;
        MySqlCommand comando;
        String sentenciaSQL;
        MySqlDataReader resultado;

        public Form1()
        {
            InitializeComponent();
            try
            {
                cadenaConexion = "Server = localhost; Database = liga; Uid = root; Pwd = root; Port=3306";
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Close();
                conexion.Open();
            }
            catch (Exception)
            {

            }
            sentenciaSQL = "Select * from liga.jugadores";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                comboBox1.Items.Add(resultado.GetString("nombre"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Primero obtengo la clave primaria más alta almacenada en la
            // tabla jugadores
            // En id_jugador guardaré el resultado de la Query
            // para saber cuál es el MAX id_jugador en la tabla

            conexion.Close();
            conexion.Open();

            int id_jugador_maximo = 0;
            sentenciaSQL = "SELECT MAX(id_jugador) FROM jugadores";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();
            if (resultado.Read()) 
            {
                id_jugador_maximo = resultado.GetInt32(0);
                id_jugador_maximo++;
               
            }
            

            // Creamos la cadena de inserci´´on que es un string formado
            // Concatenamos las distintas partes que leemos de los textbox

            conexion.Close();
            conexion.Open();

            sentenciaSQL =
            "INSERT INTO jugadores" +
            "(id_jugador, nombre, apellido, puesto, fecha_alta, salario, equipo, altura)"
            + "VALUES ('" 
            + id_jugador_maximo + "','"
            + textBox1.Text + "','"
            + textBox2.Text + "','"
            + textBox3.Text + "','"
            + "2013-04-16" + "','"
            + textBox4.Text + "','"
            + "2', 1.80)";
                             
            label5.Text = sentenciaSQL;
            comando = new MySqlCommand(sentenciaSQL, conexion);
            comando.BeginExecuteNonQuery();

        }
    }
}
