namespace WinFormsApp1
{
    partial class Form1
    {
        // Contenedor de componentes administrados por el diseñador (usado por Dispose)
        private System.ComponentModel.IContainer components = null;

        // ─── Liberación de recursos ───────────────────────────────────────────
        // Se llama automáticamente cuando el formulario se cierra
        // Libera recursos administrados (components) y no administrados
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();   // Libera controles y componentes del formulario
            base.Dispose(disposing);    // Llama al Dispose de la clase base Form
        }

        #region Windows Form Designer generated code

        // ─── Método principal de inicialización visual ────────────────────────
        // Crea, configura y posiciona todos los controles del formulario
        private void InitializeComponent()
        {
            // ─── Instanciación de controles ───────────────────────────────────
            // Se crean todos los objetos antes de configurarlos
            this.txtDisplay = new System.Windows.Forms.TextBox(); // Pantalla principal
            this.lblOperacion = new System.Windows.Forms.Label();   // Label operación en curso

            // Fila 0: botones de control de la calculadora
            this.btnCE = new System.Windows.Forms.Button(); // Clear Entry (borra entrada actual)
            this.btnC = new System.Windows.Forms.Button(); // Clear (borra todo)
            this.btnBackspace = new System.Windows.Forms.Button(); // Borra último dígito
            this.btnDiv = new System.Windows.Forms.Button(); // División (÷)

            // Fila 1: números 7, 8, 9 y multiplicación
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button(); // Multiplicación (×)

            // Fila 2: números 4, 5, 6 y resta
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btnResta = new System.Windows.Forms.Button(); // Resta (−)

            // Fila 3: números 1, 2, 3 y suma
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnSuma = new System.Windows.Forms.Button(); // Suma (+)

            // Fila 4: negación, 0, decimal e igual
            this.btnNegar = new System.Windows.Forms.Button(); // Cambia signo (+/-)
            this.btn0 = new System.Windows.Forms.Button();
            this.btnDecimal = new System.Windows.Forms.Button(); // Separador decimal (,)
            this.btnIgual = new System.Windows.Forms.Button(); // Igual (=)

            // Fila extra: funciones matemáticas especiales
            this.btnRaiz = new System.Windows.Forms.Button(); // Raíz cuadrada (√)
            this.btnPorcentaje = new System.Windows.Forms.Button(); // Módulo/Porcentaje (%)

            // Suspende el redibujado del formulario mientras se configuran los controles
            // Mejora el rendimiento evitando parpadeos durante la inicialización
            this.SuspendLayout();

            // ─── Configuración del formulario principal ───────────────────────
            this.Text = "Calculadora";                                          // Título de la ventana
            this.Size = new System.Drawing.Size(340, 560);                     // Tamaño fijo
            this.MinimumSize = new System.Drawing.Size(340, 560);                     // No permite reducir
            this.MaximumSize = new System.Drawing.Size(340, 560);                     // No permite agrandar
            this.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);            // Fondo gris muy oscuro
            this.Font = new System.Drawing.Font("Segoe UI", 13F);             // Fuente base del formulario
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;     // Borde fijo, no redimensionable
            this.MaximizeBox = false;                                                  // Desactiva botón maximizar
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;  // Centrado en pantalla al abrir

            // ─── Paleta de colores del tema oscuro ───────────────────────────
            System.Drawing.Color colorFondo = System.Drawing.Color.FromArgb(32, 32, 32);  // Fondo general oscuro
            System.Drawing.Color colorDisplay = System.Drawing.Color.FromArgb(20, 20, 20);  // Display más oscuro que el fondo
            System.Drawing.Color colorNumero = System.Drawing.Color.FromArgb(51, 51, 51);  // Botones numéricos gris medio
            System.Drawing.Color colorOp = System.Drawing.Color.FromArgb(60, 60, 60);  // Botones de operadores gris claro
            System.Drawing.Color colorIgual = System.Drawing.Color.FromArgb(0, 120, 215); // Botón igual azul Windows
            System.Drawing.Color colorEspecial = System.Drawing.Color.FromArgb(45, 45, 48);  // Botones especiales gris azulado
            System.Drawing.Color colorTexto = System.Drawing.Color.White;                 // Texto blanco en todos los botones
            System.Drawing.Color colorHoverNum = System.Drawing.Color.FromArgb(80, 80, 80);  // Color hover (no usado directamente)

            // Dimensiones y margen base para posicionar los botones en cuadrícula
            int btnW = 72, btnH = 56, margen = 10;

            // ─── Label de operación en curso ──────────────────────────────────
            // Muestra el primer número y el operador seleccionado (ej: "25 ×")
            this.lblOperacion.AutoSize = false;                                                    // Tamaño fijo manual
            this.lblOperacion.Size = new System.Drawing.Size(306, 22);                        // Ancho completo, altura pequeña
            this.lblOperacion.Location = new System.Drawing.Point(margen, 10);                    // Arriba del display
            this.lblOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;             // Texto alineado a la derecha
            this.lblOperacion.ForeColor = System.Drawing.Color.Gray;                               // Texto gris (secundario)
            this.lblOperacion.Font = new System.Drawing.Font("Segoe UI", 10F);               // Fuente más pequeña que el display
            this.lblOperacion.BackColor = colorFondo;                                              // Mismo fondo que el formulario

            // ─── Display principal (TextBox) ──────────────────────────────────
            // Muestra el número que se está ingresando o el resultado
            this.txtDisplay.Size = new System.Drawing.Size(306, 60);                        // Ancho casi completo
            this.txtDisplay.Location = new System.Drawing.Point(margen, 34);                    // Debajo del label de operación
            this.txtDisplay.ReadOnly = true;                                                     // Solo lectura (no se escribe directo)
            this.txtDisplay.Text = "0";                                                     // Valor inicial
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;         // Número alineado a la derecha
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI Light", 28F);         // Fuente grande y delgada
            this.txtDisplay.BackColor = colorDisplay;                                            // Fondo muy oscuro
            this.txtDisplay.ForeColor = colorTexto;                                             // Texto blanco
            this.txtDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;                  // Sin borde visible
            this.txtDisplay.Cursor = System.Windows.Forms.Cursors.Default;                   // Cursor normal (no de edición)

            // ─── Helper lambda para configurar botones en cuadrícula ──────────
            // Recibe: botón, texto, columna, fila, color de fondo
            // Calcula automáticamente la posición según columna y fila
            System.Action<System.Windows.Forms.Button, string, int, int, System.Drawing.Color> setupBtn =
                (btn, texto, col, fila, color) =>
                {
                    btn.Text = texto;
                    btn.Size = new System.Drawing.Size(btnW, btnH); // Tamaño uniforme para todos
                    // Posición: margen + (columna × (ancho + separación)), altura base + (fila × (alto + separación))
                    btn.Location = new System.Drawing.Point(margen + col * (btnW + 4), 110 + fila * (btnH + 4));
                    btn.BackColor = color;
                    btn.ForeColor = colorTexto;                                  // Texto siempre blanco
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;        // Sin relieve 3D, estilo plano
                    btn.FlatAppearance.BorderSize = 0;                           // Sin borde en los botones
                    // Color al pasar el mouse: más claro que el color base (+30 en cada canal RGB)
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(
                        Math.Min(color.R + 30, 255),
                        Math.Min(color.G + 30, 255),
                        Math.Min(color.B + 30, 255));
                    // Color al hacer clic: más oscuro que el color base (-20 en cada canal RGB)
                    btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(
                        Math.Max(color.R - 20, 0),
                        Math.Max(color.G - 20, 0),
                        Math.Max(color.B - 20, 0));
                    btn.Cursor = System.Windows.Forms.Cursors.Hand; // Cursor de mano al pasar por encima
                    btn.TabStop = false;                              // No se selecciona con Tab (evita foco visual)
                };

            // ─── Posicionamiento de botones por filas ─────────────────────────

            // Fila 0: funciones de control | col 0=CE, 1=C, 2=⌫, 3=÷
            setupBtn(btnCE, "CE", 0, 0, colorEspecial); // Borra solo la entrada actual
            setupBtn(btnC, "C", 1, 0, colorEspecial); // Borra todo y reinicia
            setupBtn(btnBackspace, "⌫", 2, 0, colorEspecial); // Borra el último dígito
            setupBtn(btnDiv, "÷", 3, 0, colorOp);       // Operador división

            // Fila 1: números 7-9 y multiplicación
            setupBtn(btn7, "7", 0, 1, colorNumero);
            setupBtn(btn8, "8", 1, 1, colorNumero);
            setupBtn(btn9, "9", 2, 1, colorNumero);
            setupBtn(btnMulti, "×", 3, 1, colorOp);            // Operador multiplicación

            // Fila 2: números 4-6 y resta
            setupBtn(btn4, "4", 0, 2, colorNumero);
            setupBtn(btn5, "5", 1, 2, colorNumero);
            setupBtn(btn6, "6", 2, 2, colorNumero);
            setupBtn(btnResta, "−", 3, 2, colorOp);            // Operador resta

            // Fila 3: números 1-3 y suma
            setupBtn(btn1, "1", 0, 3, colorNumero);
            setupBtn(btn2, "2", 1, 3, colorNumero);
            setupBtn(btn3, "3", 2, 3, colorNumero);
            setupBtn(btnSuma, "+", 3, 3, colorOp);             // Operador suma

            // Fila 4: signo, 0, decimal e igual
            setupBtn(btnNegar, "+/-", 0, 4, colorNumero); // Invierte signo del número actual
            setupBtn(btn0, "0", 1, 4, colorNumero);
            setupBtn(btnDecimal, ",", 2, 4, colorNumero); // Separador decimal
            setupBtn(btnIgual, "=", 3, 4, colorIgual);  // Ejecuta la operación (azul destacado)

            // Fila 5: funciones matemáticas especiales
            setupBtn(btnRaiz, "√", 0, 5, colorEspecial); // Raíz cuadrada
            setupBtn(btnPorcentaje, "%", 1, 5, colorEspecial); // Módulo/resto de división

            // ─── Fuente más grande para símbolos de operadores ────────────────
            // Los símbolos matemáticos se ven mejor con fuente 16pt
            System.Drawing.Font fontOp = new System.Drawing.Font("Segoe UI", 16F);
            btnSuma.Font = fontOp;
            btnResta.Font = fontOp;
            btnMulti.Font = fontOp;
            btnDiv.Font = fontOp;
            btnIgual.Font = fontOp;
            btnRaiz.Font = fontOp;
            btnBackspace.Font = fontOp; // El símbolo ⌫ también se ve mejor en 16pt

            // ─── Suscripción a eventos Click ──────────────────────────────────
            // Todos los botones numéricos comparten el mismo manejador
            btn0.Click += btnNumero_Click;
            btn1.Click += btnNumero_Click;
            btn2.Click += btnNumero_Click;
            btn3.Click += btnNumero_Click;
            btn4.Click += btnNumero_Click;
            btn5.Click += btnNumero_Click;
            btn6.Click += btnNumero_Click;
            btn7.Click += btnNumero_Click;
            btn8.Click += btnNumero_Click;
            btn9.Click += btnNumero_Click;

            // Botón decimal tiene su propio manejador (lógica especial del separador)
            btnDecimal.Click += btnDecimal_Click;

            // Operadores comparten manejador (se distinguen por btn.Text dentro del método)
            btnSuma.Click += btnOperacion_Click;
            btnResta.Click += btnOperacion_Click;
            btnMulti.Click += btnOperacion_Click;
            btnDiv.Click += btnOperacion_Click;
            btnPorcentaje.Click += btnOperacion_Click;

            // Botones de acción con manejadores individuales
            btnIgual.Click += btnIgual_Click;
            btnCE.Click += btnCE_Click;
            btnC.Click += btnC_Click;
            btnBackspace.Click += btnBackspace_Click;
            btnNegar.Click += btnNegar_Click;
            btnRaiz.Click += btnRaiz_Click;

            // ─── Agregar todos los controles al formulario ────────────────────
            // Solo los controles agregados aquí serán visibles en el formulario
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblOperacion, txtDisplay,
                btnCE, btnC, btnBackspace, btnDiv,
                btn7, btn8, btn9, btnMulti,
                btn4, btn5, btn6, btnResta,
                btn1, btn2, btn3, btnSuma,
                btnNegar, btn0, btnDecimal, btnIgual,
                btnRaiz, btnPorcentaje
            });

            // Reanuda el redibujado del formulario después de configurar todos los controles
            this.ResumeLayout(false);
        }

        #endregion

        // ─── Declaración de campos de controles ──────────────────────────────
        // Estos campos permiten acceder a los controles desde Form1.cs
        private System.Windows.Forms.TextBox txtDisplay;   // Pantalla de la calculadora
        private System.Windows.Forms.Label lblOperacion; // Label de operación en curso
        private System.Windows.Forms.Button btnCE, btnC, btnBackspace, btnDiv;
        private System.Windows.Forms.Button btn7, btn8, btn9, btnMulti;
        private System.Windows.Forms.Button btn4, btn5, btn6, btnResta;
        private System.Windows.Forms.Button btn1, btn2, btn3, btnSuma;
        private System.Windows.Forms.Button btnNegar, btn0, btnDecimal, btnIgual;
        private System.Windows.Forms.Button btnRaiz, btnPorcentaje;
    }
}