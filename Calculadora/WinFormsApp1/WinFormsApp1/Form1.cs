using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private double _primerNumero = 0;
        private double _segundoNumero = 0;
        private string _operacion = "";
        private bool _nuevaEntrada = false;
        private bool _operacionPendiente = false;

        public Form1()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            InitializeComponent();
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string valor = btn.Text;
            string sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (_nuevaEntrada) { txtDisplay.Text = "0"; _nuevaEntrada = false; }

            if (txtDisplay.Text == "0" && valor != sep)
                txtDisplay.Text = valor;
            else
                txtDisplay.Text += valor;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            string sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (_nuevaEntrada) { txtDisplay.Text = "0"; _nuevaEntrada = false; }
            if (!txtDisplay.Text.Contains(sep))
                txtDisplay.Text += sep;
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_operacionPendiente) Calcular();
            _primerNumero = double.Parse(txtDisplay.Text, CultureInfo.CurrentCulture);
            _operacion = btn.Text;
            _nuevaEntrada = true;
            _operacionPendiente = true;
            lblOperacion.Text = $"{_primerNumero.ToString(CultureInfo.CurrentCulture)} {_operacion}";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (!_operacionPendiente) return;
            Calcular();
            _operacionPendiente = false;
            lblOperacion.Text = "";
        }

        private void Calcular()
        {
            _segundoNumero = double.Parse(txtDisplay.Text, CultureInfo.CurrentCulture);
            double resultado = 0;

            switch (_operacion)
            {
                case "+": resultado = _primerNumero + _segundoNumero; break;
                case "−": resultado = _primerNumero - _segundoNumero; break;
                case "×": resultado = _primerNumero * _segundoNumero; break;
                case "÷":
                    if (_segundoNumero == 0) { txtDisplay.Text = "Error"; _nuevaEntrada = true; return; }
                    resultado = _primerNumero / _segundoNumero;
                    break;
                case "%": resultado = _primerNumero % _segundoNumero; break;
            }

            txtDisplay.Text = resultado == Math.Truncate(resultado)
                ? resultado.ToString("0", CultureInfo.CurrentCulture)
                : resultado.ToString("G15", CultureInfo.CurrentCulture);

            _primerNumero = resultado;
            _nuevaEntrada = true;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            _primerNumero = 0;
            _segundoNumero = 0;
            _operacion = "";
            _nuevaEntrada = false;
            _operacionPendiente = false;
            lblOperacion.Text = "";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            else
                txtDisplay.Text = "0";
        }

        private void btnNegar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out double val) && val != 0)
                txtDisplay.Text = (val * -1).ToString(CultureInfo.CurrentCulture);
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out double val))
            {
                txtDisplay.Text = val < 0 ? "Error" : Math.Sqrt(val).ToString("G15", CultureInfo.CurrentCulture);
                _nuevaEntrada = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D0: case Keys.NumPad0: btn0.PerformClick(); return true;
                case Keys.D1: case Keys.NumPad1: btn1.PerformClick(); return true;
                case Keys.D2: case Keys.NumPad2: btn2.PerformClick(); return true;
                case Keys.D3: case Keys.NumPad3: btn3.PerformClick(); return true;
                case Keys.D4: case Keys.NumPad4: btn4.PerformClick(); return true;
                case Keys.D5: case Keys.NumPad5: btn5.PerformClick(); return true;
                case Keys.D6: case Keys.NumPad6: btn6.PerformClick(); return true;
                case Keys.D7: case Keys.NumPad7: btn7.PerformClick(); return true;
                case Keys.D8: case Keys.NumPad8: btn8.PerformClick(); return true;
                case Keys.D9: case Keys.NumPad9: btn9.PerformClick(); return true;
                case Keys.Add: btnSuma.PerformClick(); return true;
                case Keys.Subtract: btnResta.PerformClick(); return true;
                case Keys.Multiply: btnMulti.PerformClick(); return true;
                case Keys.Divide: btnDiv.PerformClick(); return true;
                case Keys.Enter: btnIgual.PerformClick(); return true;
                case Keys.Escape: btnC.PerformClick(); return true;
                case Keys.Back: btnBackspace.PerformClick(); return true;
                case Keys.Decimal: btnDecimal.PerformClick(); return true;
                case Keys.Oemcomma: btnDecimal.PerformClick(); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}