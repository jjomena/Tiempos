using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
      

             printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                printDocument1.Print();
            }
         


        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {



            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 9,FontStyle.Bold);

            int startx = 10;
            int starty = 10;
            int offset = 200;
            string namestring = "Cliente: ";
            string cliente = comboBoxApostador.Text.PadRight(5);
            string paga = "Paga 80 veces";
            string nuevosTiempos = "Sorteo Nuevos Tiempos";
            string horaSorteo = "Sorteo de la " + comboBoxHoraSorteo.Text;

            //Paga 80 veces
            //sorteo de Nuevos Tiempos
            //Sorteo de: Tarde/Noche comboBoxHorasSorteo.Text

            //Cuanto paga el premio(primero paga 80 veces) con el sorteo de Nuevos Tiempos
            //Sorteo de tarde o noche
            //Esas dos debajo de fecha de sorteo
            string fecha = "Sorteo: " + dateTimePicker2.Value.ToString("dd-MM-yyyy");
            string total = "Total:  ₡"  + TotalTiempos.Text;
            int fontheight =Convert.ToInt32(font.GetHeight());

            
            //Aquí están los títulos de las columnas 
            string columntitles = "Número".PadRight(10) + "Monto";

            graphics.DrawString("Abastecedor Jazmín".PadLeft(12), font, new SolidBrush(Color.Black), startx, starty);

            graphics.DrawString(fecha, font, new SolidBrush(Color.Black), startx, starty + 30);
            graphics.DrawString(paga, font, new SolidBrush(Color.Black), startx, starty + 50);
            graphics.DrawString(nuevosTiempos, font, new SolidBrush(Color.Black), startx, starty + 70);
            graphics.DrawString(horaSorteo, font, new SolidBrush(Color.Black), startx, starty + 90);

            graphics.DrawString(namestring, font, new SolidBrush(Color.Black), startx, starty + 110);
            graphics.DrawString(cliente, font, new SolidBrush(Color.Black), startx, starty + 130);
     


            graphics.DrawString(columntitles, font, new SolidBrush(Color.Black), startx, starty + 180);

  
            for (int counter = 0; counter < (dataGridTiempos.Rows.Count - 1); counter++)
            {
              string Numero = dataGridTiempos.Rows[counter].Cells[0].Value.ToString();
              string Cantidad = dataGridTiempos.Rows[counter].Cells[1].Value.ToString();
                string linea = Numero.PadRight(10) + "₡" + Cantidad;
                graphics.DrawString(linea, font, new SolidBrush(Color.Black), startx, starty + offset);
                offset = offset + fontheight + 5;
            }



          


            offset = offset + 2;
            graphics.DrawString(total, font, new SolidBrush(Color.Black), startx, starty + offset);
            graphics.DrawString("Gracias por su compra", font, new SolidBrush(Color.Black), startx, starty + offset+20);
        }
    }
    }

