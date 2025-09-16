using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DATA_GRID_VIEW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Puedes configurar el DataGridView desde código también si prefieres
            // dgvProductos.Columns.Add("Marca", "Marca");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string descripcion = txtDescripcion.Text;
            string precio = txtPrecio.Text;
            string marca = txtMarca.Text;
            string procedencia = txtProcedencia.Text;
            string cantidad = txtCantidad.Text;

            if (!string.IsNullOrWhiteSpace(codigo) &&
                !string.IsNullOrWhiteSpace(descripcion) &&
                !string.IsNullOrWhiteSpace(precio) &&
                !string.IsNullOrWhiteSpace(marca) &&
                !string.IsNullOrWhiteSpace(procedencia) &&
                !string.IsNullOrWhiteSpace(cantidad))
            {
                dgvProductos.Rows.Add(codigo, descripcion, precio, marca, procedencia, cantidad);

                txtCodigo.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                txtMarca.Clear();
                txtProcedencia.Clear();
                txtCantidad.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar esta fila?",
                                                     "Confirmación de eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    dgvProductos.Rows.RemoveAt(dgvProductos.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                var confirmResult = MessageBox.Show("¿Está seguro de que desea limpiar toda la tabla?",
                                                    "Confirmación de limpieza",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    dgvProductos.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("La tabla ya está vacía.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvProductos.SelectedRows[0];

                string nuevoCodigo = txtCodigo.Text;
                string nuevaDescripcion = txtDescripcion.Text;
                string nuevoPrecio = txtPrecio.Text;
                string nuevaMarca = txtMarca.Text;
                string nuevaProcedencia = txtProcedencia.Text;
                string nuevaCantidad = txtCantidad.Text;

                if (!string.IsNullOrWhiteSpace(nuevoCodigo) &&
                    !string.IsNullOrWhiteSpace(nuevaDescripcion) &&
                    !string.IsNullOrWhiteSpace(nuevoPrecio) &&
                    !string.IsNullOrWhiteSpace(nuevaMarca) &&
                    !string.IsNullOrWhiteSpace(nuevaProcedencia) &&
                    !string.IsNullOrWhiteSpace(nuevaCantidad))
                {
                    var confirmResult = MessageBox.Show("¿Desea modificar esta fila?",
                                                        "Confirmación de modificación",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        filaSeleccionada.Cells[0].Value = nuevoCodigo;
                        filaSeleccionada.Cells[1].Value = nuevaDescripcion;
                        filaSeleccionada.Cells[2].Value = nuevoPrecio;
                        filaSeleccionada.Cells[3].Value = nuevaMarca;
                        filaSeleccionada.Cells[4].Value = nuevaProcedencia;
                        filaSeleccionada.Cells[5].Value = nuevaCantidad;

                        txtCodigo.Clear();
                        txtDescripcion.Clear();
                        txtPrecio.Clear();
                        txtMarca.Clear();
                        txtProcedencia.Clear();
                        txtCantidad.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos para modificar.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Está seguro de que desea salir?",
                                                "Confirmación de salida",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            // Este evento puede usarse si deseas hacer validación en tiempo real
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
