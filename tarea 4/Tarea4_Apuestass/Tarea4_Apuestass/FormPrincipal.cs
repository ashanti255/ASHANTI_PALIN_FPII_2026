using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tarea4_Apuestas
{
    public class Apostador
    {
        public string Nombre { get; set; } = "";
        public int Numero { get; set; }
        public double Monto { get; set; }
        public int? Posicion { get; set; }
        public double Premio { get; set; }
    }

    public class Jugada
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public List<Apostador> Apostadores { get; set; } = new List<Apostador>();
        public int? NumeroSorteado { get; set; }
    }

    public partial class FormPrincipal : Form
    {
        private List<Jugada> todasLasJugadas = new List<Jugada>();
        private Jugada jugadaActual = null;

        private Label lblJugadaActual;
        private Label lblResultado;
        private TextBox txtNombre;
        private NumericUpDown nudNumero;
        private NumericUpDown nudMonto;
        private Button btnNuevaJugada;
        private Button btnAgregarApostador;
        private Button btnJugar;
        private Button btnHistorial;
        private DataGridView dgvApostadores;
        private DataGridView dgvGanadores;

        public FormPrincipal()
        {
            this.Text = "Sistema de Apuestas";
            this.Size = new Size(960, 640);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 46);
            this.Font = new Font("Segoe UI", 9f);

            CrearUI();
        }

        private void CrearUI()
        {
            // === PANEL SUPERIOR ===
            Panel top = new Panel();
            top.Dock = DockStyle.Top;
            top.Height = 55;
            top.BackColor = Color.FromArgb(49, 50, 68);

            Label lblTitulo = new Label();
            lblTitulo.Text = "SISTEMA DE APUESTAS";
            lblTitulo.Font = new Font("Segoe UI", 15f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(203, 166, 247);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(14, 12);

            lblJugadaActual = new Label();
            lblJugadaActual.Text = "Sin jugada activa";
            lblJugadaActual.Font = new Font("Segoe UI", 9f, FontStyle.Italic);
            lblJugadaActual.ForeColor = Color.FromArgb(166, 227, 161);
            lblJugadaActual.AutoSize = true;
            lblJugadaActual.Location = new Point(370, 18);

            btnNuevaJugada = new Button();
            btnNuevaJugada.Text = "Nueva Jugada";
            btnNuevaJugada.Location = new Point(610, 11);
            btnNuevaJugada.Size = new Size(150, 34);
            btnNuevaJugada.FlatStyle = FlatStyle.Flat;
            btnNuevaJugada.BackColor = Color.FromArgb(49, 50, 68);
            btnNuevaJugada.ForeColor = Color.FromArgb(137, 180, 250);
            btnNuevaJugada.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnNuevaJugada.Click += new EventHandler(BtnNuevaJugada_Click);

            btnHistorial = new Button();
            btnHistorial.Text = "Historial";
            btnHistorial.Location = new Point(770, 11);
            btnHistorial.Size = new Size(130, 34);
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.BackColor = Color.FromArgb(49, 50, 68);
            btnHistorial.ForeColor = Color.FromArgb(249, 226, 175);
            btnHistorial.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnHistorial.Click += new EventHandler(BtnHistorial_Click);

            top.Controls.Add(lblTitulo);
            top.Controls.Add(lblJugadaActual);
            top.Controls.Add(btnNuevaJugada);
            top.Controls.Add(btnHistorial);

            // === PANEL IZQUIERDO ===
            Panel left = new Panel();
            left.Dock = DockStyle.Left;
            left.Width = 420;
            left.BackColor = Color.FromArgb(30, 30, 46);

            GroupBox grp = new GroupBox();
            grp.Text = "Agregar Apostador";
            grp.ForeColor = Color.FromArgb(137, 180, 250);
            grp.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            grp.Location = new Point(12, 8);
            grp.Size = new Size(394, 188);
            grp.BackColor = Color.FromArgb(30, 30, 46);

            Label lNombre = new Label();
            lNombre.Text = "Nombre:";
            lNombre.Location = new Point(12, 30);
            lNombre.ForeColor = Color.FromArgb(166, 173, 200);
            lNombre.AutoSize = true;

            txtNombre = new TextBox();
            txtNombre.Location = new Point(90, 27);
            txtNombre.Width = 285;
            txtNombre.BackColor = Color.FromArgb(49, 50, 68);
            txtNombre.ForeColor = Color.White;

            Label lNumero = new Label();
            lNumero.Text = "Numero:";
            lNumero.Location = new Point(12, 68);
            lNumero.ForeColor = Color.FromArgb(166, 173, 200);
            lNumero.AutoSize = true;

            nudNumero = new NumericUpDown();
            nudNumero.Location = new Point(90, 65);
            nudNumero.Width = 120;
            nudNumero.Minimum = 0;
            nudNumero.Maximum = 999999;
            nudNumero.BackColor = Color.FromArgb(49, 50, 68);
            nudNumero.ForeColor = Color.White;

            Label lMonto = new Label();
            lMonto.Text = "Monto ($):";
            lMonto.Location = new Point(12, 106);
            lMonto.ForeColor = Color.FromArgb(166, 173, 200);
            lMonto.AutoSize = true;

            nudMonto = new NumericUpDown();
            nudMonto.Location = new Point(90, 103);
            nudMonto.Width = 120;
            nudMonto.Minimum = 1;
            nudMonto.Maximum = 9999999;
            nudMonto.DecimalPlaces = 2;
            nudMonto.Value = 1;
            nudMonto.BackColor = Color.FromArgb(49, 50, 68);
            nudMonto.ForeColor = Color.White;

            btnAgregarApostador = new Button();
            btnAgregarApostador.Text = "Agregar Apostador";
            btnAgregarApostador.Location = new Point(180, 145);
            btnAgregarApostador.Size = new Size(200, 32);
            btnAgregarApostador.FlatStyle = FlatStyle.Flat;
            btnAgregarApostador.BackColor = Color.FromArgb(49, 50, 68);
            btnAgregarApostador.ForeColor = Color.FromArgb(166, 227, 161);
            btnAgregarApostador.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnAgregarApostador.Enabled = false;
            btnAgregarApostador.Click += new EventHandler(BtnAgregar_Click);

            grp.Controls.Add(lNombre);
            grp.Controls.Add(txtNombre);
            grp.Controls.Add(lNumero);
            grp.Controls.Add(nudNumero);
            grp.Controls.Add(lMonto);
            grp.Controls.Add(nudMonto);
            grp.Controls.Add(btnAgregarApostador);

            Label lblLista = new Label();
            lblLista.Text = "Apostadores en jugada actual:";
            lblLista.ForeColor = Color.FromArgb(137, 180, 250);
            lblLista.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lblLista.AutoSize = true;
            lblLista.Location = new Point(12, 205);

            dgvApostadores = CrearGrid(Color.FromArgb(30, 30, 46), Color.FromArgb(203, 166, 247));
            dgvApostadores.Location = new Point(12, 228);
            dgvApostadores.Size = new Size(394, 295);

            btnJugar = new Button();
            btnJugar.Text = "REALIZAR JUGADA";
            btnJugar.Location = new Point(12, 535);
            btnJugar.Size = new Size(394, 42);
            btnJugar.FlatStyle = FlatStyle.Flat;
            btnJugar.BackColor = Color.FromArgb(49, 50, 68);
            btnJugar.ForeColor = Color.FromArgb(243, 139, 168);
            btnJugar.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btnJugar.Enabled = false;
            btnJugar.Click += new EventHandler(BtnJugar_Click);

            left.Controls.Add(grp);
            left.Controls.Add(lblLista);
            left.Controls.Add(dgvApostadores);
            left.Controls.Add(btnJugar);

            // === PANEL DERECHO ===
            Panel right = new Panel();
            right.Dock = DockStyle.Fill;
            right.BackColor = Color.FromArgb(24, 24, 37);
            right.Padding = new Padding(12);

            GroupBox grpR = new GroupBox();
            grpR.Text = "Ganadores";
            grpR.ForeColor = Color.FromArgb(249, 226, 175);
            grpR.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            grpR.Dock = DockStyle.Fill;
            grpR.BackColor = Color.FromArgb(24, 24, 37);

            lblResultado = new Label();
            lblResultado.Text = "Crea una jugada y agrega apostadores para comenzar.";
            lblResultado.ForeColor = Color.FromArgb(166, 173, 200);
            lblResultado.Font = new Font("Segoe UI", 9.5f, FontStyle.Italic);
            lblResultado.Dock = DockStyle.Top;
            lblResultado.Height = 44;
            lblResultado.TextAlign = ContentAlignment.MiddleCenter;

            dgvGanadores = CrearGrid(Color.FromArgb(24, 24, 37), Color.FromArgb(249, 226, 175));
            dgvGanadores.Dock = DockStyle.Fill;

            grpR.Controls.Add(dgvGanadores);
            grpR.Controls.Add(lblResultado);
            right.Controls.Add(grpR);

            // === ENSAMBLAR ===
            this.Controls.Add(right);
            this.Controls.Add(left);
            this.Controls.Add(top);
        }

        private void BtnNuevaJugada_Click(object sender, EventArgs e)
        {
            jugadaActual = new Jugada
            {
                Id = todasLasJugadas.Count + 1,
                Fecha = DateTime.Now
            };
            todasLasJugadas.Add(jugadaActual);

            lblJugadaActual.Text = "Jugada activa: #" + jugadaActual.Id;
            btnJugar.Enabled = true;
            btnAgregarApostador.Enabled = true;
            dgvGanadores.DataSource = null;
            lblResultado.Text = "Agrega apostadores y presiona REALIZAR JUGADA.";
            RefrescarApostadores();
            MessageBox.Show("Jugada #" + jugadaActual.Id + " creada.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (nombre == "")
            {
                MessageBox.Show("Ingresa el nombre.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            jugadaActual.Apostadores.Add(new Apostador
            {
                Nombre = nombre,
                Numero = (int)nudNumero.Value,
                Monto = (double)nudMonto.Value
            });

            txtNombre.Clear();
            nudNumero.Value = 0;
            nudMonto.Value = 1;
            RefrescarApostadores();
            txtNombre.Focus();
        }

        private void BtnJugar_Click(object sender, EventArgs e)
        {
            if (jugadaActual.Apostadores.Count == 0)
            {
                MessageBox.Show("Agrega al menos un apostador.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int max = jugadaActual.Apostadores.Max(a => a.Numero);
            int num = new Random().Next(0, max + 1);
            jugadaActual.NumeroSorteado = num;

            foreach (var a in jugadaActual.Apostadores)
            {
                a.Posicion = null;
                a.Premio = 0;
            }

            var grupos = jugadaActual.Apostadores
                .GroupBy(a => a.Numero)
                .OrderBy(g => Math.Abs(g.Key - num))
                .Take(3)
                .ToList();

            int pos = 1;
            foreach (var g in grupos)
            {
                double mult = pos == 1 ? 1000 : pos == 2 ? 100 : 2;
                foreach (var ap in g)
                {
                    ap.Posicion = pos;
                    ap.Premio = ap.Monto * mult;
                }
                pos++;
            }

            var resultado = jugadaActual.Apostadores
                .Where(a => a.Posicion.HasValue)
                .OrderBy(a => a.Posicion)
                .Select(a => new
                {
                    Apostador = a.Nombre,
                    Numero = a.Numero,
                    Apostado = a.Monto.ToString("N2"),
                    Posicion = a.Posicion,
                    Premio = a.Premio.ToString("N2")
                }).ToList();

            dgvGanadores.DataSource = resultado;
            lblResultado.Text = "Numero sorteado: " + num +
                "   |   1 puesto x1000   |   2 puesto x100   |   3 puesto x2";
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial fh = new FormHistorial(todasLasJugadas);
            fh.ShowDialog(this);
        }

        private void RefrescarApostadores()
        {
            if (jugadaActual == null) { dgvApostadores.DataSource = null; return; }
            dgvApostadores.DataSource = jugadaActual.Apostadores
                .Select(a => new
                {
                    Nombre = a.Nombre,
                    Numero = a.Numero,
                    Monto = a.Monto.ToString("N2")
                }).ToList();
        }

        public static DataGridView CrearGrid(Color bg, Color colorHeader)
        {
            DataGridView d = new DataGridView();
            d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            d.ReadOnly = true;
            d.AllowUserToAddRows = false;
            d.AllowUserToDeleteRows = false;
            d.RowHeadersVisible = false;
            d.BackgroundColor = bg;
            d.GridColor = Color.FromArgb(69, 71, 90);
            d.BorderStyle = BorderStyle.None;
            d.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            d.DefaultCellStyle.BackColor = bg;
            d.DefaultCellStyle.ForeColor = Color.FromArgb(205, 214, 244);
            d.DefaultCellStyle.SelectionBackColor = Color.FromArgb(69, 71, 90);
            d.DefaultCellStyle.SelectionForeColor = Color.White;
            d.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 50, 68);
            d.ColumnHeadersDefaultCellStyle.ForeColor = colorHeader;
            d.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            d.EnableHeadersVisualStyles = false;
            d.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            return d;
        }
    }

    public class FormHistorial : Form
    {
        public FormHistorial(List<Jugada> jugadas)
        {
            this.Text = "Historial";
            this.Size = new Size(820, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 46);
            this.Font = new Font("Segoe UI", 9f);

            Label l1 = new Label();
            l1.Text = "Jugadas";
            l1.ForeColor = Color.FromArgb(137, 180, 250);
            l1.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            l1.AutoSize = true;
            l1.Location = new Point(12, 8);

            DataGridView dgvJ = FormPrincipal.CrearGrid(
                Color.FromArgb(30, 30, 46), Color.FromArgb(137, 180, 250));
            dgvJ.Location = new Point(12, 30);
            dgvJ.Size = new Size(370, 440);
            dgvJ.DataSource = jugadas.Select(j => new
            {
                Id = j.Id,
                Fecha = j.Fecha.ToString("dd/MM/yyyy HH:mm"),
                Apostadores = j.Apostadores.Count,
                Sorteado = j.NumeroSorteado.HasValue ?
                              j.NumeroSorteado.Value.ToString() : "-"
            }).ToList();

            Label l2 = new Label();
            l2.Text = "Ganadores";
            l2.ForeColor = Color.FromArgb(249, 226, 175);
            l2.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            l2.AutoSize = true;
            l2.Location = new Point(395, 8);

            DataGridView dgvD = FormPrincipal.CrearGrid(
                Color.FromArgb(30, 30, 46), Color.FromArgb(249, 226, 175));
            dgvD.Location = new Point(395, 30);
            dgvD.Size = new Size(400, 440);

            dgvJ.SelectionChanged += (s, e) =>
            {
                if (dgvJ.CurrentRow == null) return;
                int id = Convert.ToInt32(dgvJ.CurrentRow.Cells["Id"].Value);
                var jug = jugadas.FirstOrDefault(j => j.Id == id);
                if (jug == null) return;
                dgvD.DataSource = jug.Apostadores
                    .Where(a => a.Posicion.HasValue)
                    .OrderBy(a => a.Posicion)
                    .Select(a => new
                    {
                        Apostador = a.Nombre,
                        Numero = a.Numero,
                        Apostado = a.Monto.ToString("N2"),
                        Posicion = a.Posicion,
                        Premio = a.Premio.ToString("N2")
                    }).ToList();
            };

            this.Controls.Add(l1);
            this.Controls.Add(dgvJ);
            this.Controls.Add(l2);
            this.Controls.Add(dgvD);
        }
    }
}