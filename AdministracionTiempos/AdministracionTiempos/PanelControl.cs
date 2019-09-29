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
    public partial class PanelControl : Form
    {
        public static String horaTarde = "12:00 PM";
        public static String horaNoche = "6:00 PM";
        public DateTime horaActual;
        public DateTime dtTarde;
        public DateTime dtNoche;
        public String vecesPaga="80";
        public String cantSeleccion;


        public PanelControl()
        {
            InitializeComponent();
        }

        private void Htarde_Click(object sender, EventArgs e)
        {

        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void PanelControl_Load(object sender, EventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnImprimir_Click_1(object sender, EventArgs e)
        {
            dtTarde = Convert.ToDateTime(horaTarde);
            dtNoche = Convert.ToDateTime(horaNoche);



            Boolean puedeVender = false;


            //Poner un if que vuelve puedeVender true si la fecha escogida es la de hoy

            if (dateTimePicker3.Text != dateTimePicker2.Text)
            {
                

                puedeVender = true;
            }

            if (comboBoxHoraSorteo.Text == "Tarde" && dateTimePicker3.Text == dateTimePicker2.Text)
            {
                if (dtTarde.TimeOfDay > DateTime.Now.TimeOfDay)
                {
                    

                    puedeVender = true;
                }


            }

            if (comboBoxHoraSorteo.Text == "Noche" && dateTimePicker3.Text == dateTimePicker2.Text)
            {
                if (dtNoche.TimeOfDay > DateTime.Now.TimeOfDay)
                {

                    

                    puedeVender = true;
                }
            }


            if (comboBoxHoraSorteo.Text == "")
            {
                MessageBox.Show("Debe ingresar la hora del sorteo");
                puedeVender = true;

            }

            if (comboBoxHoraSorteo.Text != "" && puedeVender == true)
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                    printDocument1.Print();
                }

            }

            if (puedeVender == false)
            {
                MessageBox.Show("La venta para el sorteo de la " + comboBoxHoraSorteo.Text + " ya está cerrada");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            horaTarde = ((UpDownBase)NUDHoraTarde).Text + ":" + ((UpDownBase)NUDMinTarde).Text+" "+cbHorarioTarde.Text;
            horaNoche = ((UpDownBase)NUDHoraNoche).Text + ":" + ((UpDownBase)NUDMinNoche).Text+" "+cbHorarioNoche.Text;
            MessageBox.Show("Se han guardado los cambios");
            vecesPaga = txtVecesPaga.Text;

          
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbHorarioTarde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            try
            {
                String Num = textBoxNum.Text;
                int pruebaNum = int.Parse(Num);
                if ((pruebaNum >= 0) && (pruebaNum <= 99))
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

            if (Num.Length == 1)
            {
                Num = "0" + Num;
            }

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


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {



            
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            textBoxNum.Clear();
            txtApuesta.Clear();
            comboBoxHoraSorteo.ResetText();
            dataGridTiempos.Rows.Clear();
            dateTimePicker2.ResetText();
            TotalTiempos.Text = "0";

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 9, FontStyle.Bold);

            int startx = 10;
            int starty = 10;
            int offset = 160;

            string paga = "Paga " + vecesPaga + " veces";
            string nuevosTiempos = "Con los Nuevos Tiempos";
            string horaSorteo = "Sorteo de la " + comboBoxHoraSorteo.Text;

            //Paga 80 veces
            //sorteo de Nuevos Tiempos
            //Sorteo de: Tarde/Noche comboBoxHorasSorteo.Text

            //Cuanto paga el premio(primero paga 80 veces) con el sorteo de Nuevos Tiempos
            //Sorteo de tarde o noche
            //Esas dos debajo de fecha de sorteo
            string fecha = "Sorteo: " + dateTimePicker2.Value.ToString("ddd,dd-MM-yyyy");
            string total = "Total:  ₡" + TotalTiempos.Text;
            int fontheight = Convert.ToInt32(font.GetHeight());


            //Aquí están los títulos de las columnas 
            string columntitles = "Número".PadRight(10) + "Monto";

            graphics.DrawString("Abastecedor Jazmín".PadLeft(12), font, new SolidBrush(Color.Black), startx, starty);

            graphics.DrawString(fecha, font, new SolidBrush(Color.Black), startx, starty + 30);
            graphics.DrawString(paga, font, new SolidBrush(Color.Black), startx, starty + 50);
            graphics.DrawString(nuevosTiempos, font, new SolidBrush(Color.Black), startx, starty + 90);
            graphics.DrawString(horaSorteo, font, new SolidBrush(Color.Black), startx, starty + 70);





            graphics.DrawString(columntitles, font, new SolidBrush(Color.Black), startx, starty + 140);


            for (int counter = 0; counter < (dataGridTiempos.Rows.Count - 1); counter++)
            {
                string Numero = dataGridTiempos.Rows[counter].Cells[0].Value.ToString();
                string Cantidad = dataGridTiempos.Rows[counter].Cells[1].Value.ToString();
                string linea = Numero.PadRight(10) + "₡" + Cantidad;
                graphics.DrawString(linea, font, new SolidBrush(Color.Black), startx, starty + offset);
                offset = offset + fontheight + 5;
            }






            offset = offset + 30;
            graphics.DrawString(total, font, new SolidBrush(Color.Black), startx, starty + offset);
            graphics.DrawString("Gracias por su compra", font, new SolidBrush(Color.Black), startx, starty + offset + 20);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int numTotal = int.Parse(TotalTiempos.Text);

        

            try
            {
                int rowindex = dataGridTiempos.CurrentCell.RowIndex;
                cantSeleccion = dataGridTiempos.Rows[rowindex].Cells[1].Value.ToString();
                int nuevoValor = numTotal - int.Parse(cantSeleccion);


                dataGridTiempos.Rows.RemoveAt(dataGridTiempos.SelectedRows[0].Index);



                TotalTiempos.Text = nuevoValor.ToString();

            }
            catch
            {
                MessageBox.Show("La lista de números está vacía");

            }

           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridTiempos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
    }
}
