using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministracionTiempos
{
    public partial class Tiempos : Form
    {
        public Tiempos()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                String Num = textBoxNum.Text;
                int pruebaNum = int.Parse(Num);
                if ((pruebaNum > 0) && (pruebaNum < 99))
                {
                    int Apostar = int.Parse(txtApuesta.Text);
                    //dataGridTiempos.Rows.Add(Num, Apostar);
                    AgregarTiempos(Num, Apostar);
                    int total = int.Parse(TotalTiempos.Text);
                    total = total + Apostar;
                    TotalTiempos.Text = total.ToString();
                    textBoxNum.Text = "";
                    txtApuesta.Text = "";
                }
                else
                {
                    MessageBox.Show("Los valores válidos se encuentran entre el rango de [00...99]", "Vefifique los datos ingresados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtApuesta.Text = "";
                    textBoxNum.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Verifique los datos ingresados ", "Datos Inválidos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApuesta.Text = "";
                textBoxNum.Text = "";
            }
        }

        private void AgregarTiempos(String Num, int Apuesta)
        {
            string Numero;
            int CantidadApuesta;
            int Control = 0;
            if (dataGridTiempos.Rows.Count > 1)
            {
                for (int counter = 0; counter < (dataGridTiempos.Rows.Count - 1); counter++)
                {
                    Numero = dataGridTiempos.Rows[counter].Cells[0].Value.ToString();
                    if (Numero == Num)
                    {
                        CantidadApuesta = int.Parse(dataGridTiempos.Rows[counter].Cells[1].Value.ToString());
                        CantidadApuesta += Apuesta;
                        dataGridTiempos.Rows[counter].Cells[1].Value = CantidadApuesta;
                        Control = 1;
                        break;
                    }
                }
                if (Control == 0)
                {
                    this.dataGridTiempos.Rows.Add(Num, Apuesta);
                }
            }
            else
            {
                this.dataGridTiempos.Rows.Add(Num, Apuesta);
            }
        }

    }
}
