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
                conexion.Open();
            }
            catch (Exception)
            {

            }
            //sentenciaSQL = "Select * from liga.jugadores";
            //comando = new MySqlCommand(sentenciaSQL, conexion);
            //resultado = comando.ExecuteReader();
            //while (resultado.Read())
            //{
            //    comboBox1.Items.Add(resultado.GetString("nombre")); 
            //}
            //conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        sentenciaSQL =  "INSERT INTO jugadores (id_jugador; nombre, apellido, puesto, fecha_alta, salario, equipo, altura)  VALUES (" +
            "50" + ", "+
             textBox1.Text + ", " +
             textBox2.Text + ", " +
             textBox3.Text + ", " +
             "2013-04-16 11:48:14" + ", " +
             textBox4.Text + ", " +
             "'2', '1')";
            comando = new MySqlCommand(sentenciaSQL, conexion);
            comando.BeginExecuteNonQuery();
            // sentenciaSQL = "Select * from liga.jugadores";
            //resultado = comando.ExecuteReader();
            //if (resultado.Read()) 
            //{
            //    label1.Text = resultado.GetString("nombre");
            //}
        }
    }
}
