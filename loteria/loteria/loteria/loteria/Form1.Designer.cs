namespace loteria
{
    // Clase parcial que contiene la configuración automática del diseño del formulario
    partial class Form1
    {
        // Contenedor para los componentes que requieren limpieza de memoria (como timers o menús)
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Método para liberar los recursos que el programa ya no está utilizando.
        /// </summary>
        /// <param name="disposing">True si los recursos administrados deben eliminarse; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            // Si se está cerrando el formulario y hay componentes activos, se eliminan de la memoria
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            // Llama a la limpieza de la clase base (Form)
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método obligatorio para admitir el Diseñador. 
        /// No se debe modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            // Detiene temporalmente la lógica de diseño mientras se configuran los controles
            this.SuspendLayout();

            // Configuración del escalado automático basado en la fuente del sistema
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Define el tamaño inicial de la ventana (Ancho: 684, Alto: 461)
            this.ClientSize = new System.Drawing.Size(684, 461);

            // Nombre interno del objeto formulario
            this.Name = "Form1";

            // Texto que aparece en la barra de título de la ventana
            this.Text = "Form1";

            // Reanuda la lógica de diseño y dibuja los controles en pantalla
            this.ResumeLayout(false);
        }
    }
}