using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace loteria
{
    // Definición de la ventana principal. Hereda de 'Form' para ser un formulario de Windows.
    public partial class Form1 : Form
    {
        // Declaración de los controles de la interfaz (botones, etiquetas y tabla)
        Button btnJugar = null!;
        Button btnVer = null!;
        Label lblN1 = null!;
        Label lblN2 = null!;
        Label lblN3 = null!;
        Label lblFecha = null!;
        DataGridView dgvJugadas = null!;

        // Lista dinámica para almacenar cada jugada realizada durante la sesión
        List<Jugada> historial = new List<Jugada>();

        public Form1()
        {
            // Inicializa los componentes básicos del diseñador
            InitializeComponent();
            // Llama al método que dibuja y configura nuestros botones y etiquetas
            CrearControles();
        }

        // Método para construir la interfaz de usuario mediante código
        void CrearControles()
        {
            // Configuración básica de la ventana (Título, Tamaño y Posición)
            this.Text = "Sistema de Lotería";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configuración del botón 'Jugar'
            btnJugar = new Button { Text = "Jugar", Location = new Point(50, 30), Size = new Size(80, 30) };
            btnJugar.Click += BtnJugar_Click; // Vincula el evento clic con su función
            this.Controls.Add(btnJugar);

            // Configuración del botón 'Ver Jugadas'
            btnVer = new Button { Text = "Ver Jugadas", Location = new Point(150, 30), Size = new Size(100, 30) };
            btnVer.Click += BtnVer_Click;
            this.Controls.Add(btnVer);

            // Configuración de las etiquetas que mostrarán los 3 números ganadores
            lblN1 = new Label { Text = "0", Location = new Point(50, 80), Font = new Font("Arial", 16), AutoSize = true };
            lblN2 = new Label { Text = "0", Location = new Point(100, 80), Font = new Font("Arial", 16), AutoSize = true };
            lblN3 = new Label { Text = "0", Location = new Point(150, 80), Font = new Font("Arial", 16), AutoSize = true };
            this.Controls.AddRange(new Control[] { lblN1, lblN2, lblN3 });

            // Etiqueta para mostrar la fecha y hora de la última jugada
            lblFecha = new Label { Text = "Esperando...", Location = new Point(50, 120), AutoSize = true };
            this.Controls.Add(lblFecha);

            // Configuración de la tabla (Grid) para mostrar el historial de jugadas
            dgvJugadas = new DataGridView { Location = new Point(50, 160), Size = new Size(580, 250), ReadOnly = true };
            this.Controls.Add(dgvJugadas);
        }

        // Evento que se ejecuta al presionar el botón "Jugar"
        private void BtnJugar_Click(object? sender, EventArgs e)
        {
            // Crea un generador de números aleatorios
            Random rnd = new Random();

            // Genera 3 números entre 1 y 100
            int n1 = rnd.Next(1, 101);
            int n2 = rnd.Next(1, 101);
            int n3 = rnd.Next(1, 101);
            DateTime ahora = DateTime.Now; // Captura el momento exacto de la jugada

            // Actualiza las etiquetas de la interfaz con los números generados
            lblN1.Text = n1.ToString();
            lblN2.Text = n2.ToString();
            lblN3.Text = n3.ToString();
            lblFecha.Text = "Jugado: " + ahora.ToString();

            // Crea un nuevo objeto 'Jugada' y lo añade a la lista del historial
            historial.Add(new Jugada
            {
                Id = historial.Count + 1,
                Numero1 = n1,
                Numero2 = n2,
                Numero3 = n3,
                FechaHora = ahora
            });
        }

        // Evento que se ejecuta al presionar el botón "Ver Jugadas"
        private void BtnVer_Click(object? sender, EventArgs e)
        {
            // Refresca la tabla asignándole la lista de jugadas almacenadas
            dgvJugadas.DataSource = null;
            dgvJugadas.DataSource = new List<Jugada>(historial);
        }
    }

    // Clase que define qué datos guardamos de cada jugada (Modelo de datos)
    public class Jugada
    {
        public int Id { get; set; }             // Número de jugada
        public int Numero1 { get; set; }        // Primer número ganador
        public int Numero2 { get; set; }        // Segundo número ganador
        public int Numero3 { get; set; }        // Tercer número ganador
        public DateTime FechaHora { get; set; } // Fecha y hora del sorteo
    }
}