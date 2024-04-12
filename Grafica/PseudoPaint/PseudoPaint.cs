using DevExpress.Utils.MVVM.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PseudoPaint
{
    public partial class PseudoPaint : DevExpress.XtraEditors.XtraForm
    {
        public PseudoPaint()
        {
            InitializeComponent();
        }
        //Punto actual
        int Px = 0;
        int Py = 0;
        //Punto centro
        int Cx = 0;
        int Cy = 0;

        bool clicked = false;
        //Pluma
        Color Col = Color.Black;
        int Grosor = 1;
        //Opción
        char Op;
        public String sTexto;
        public int iFuente;

        Graphics Puntero;
        SolidBrush Brocha = new SolidBrush(Color.Black);
        Pen Pluma;
        //Punto anterior
        Point PPoint;

        Point previousPoint;

        Button Btn = new Button();
        PictureBox Pb = new PictureBox();





        Image ImagenLapiz;
        
        

        void DeclaraPluma(Color C, int G)
        {
            Pluma = new Pen(C, G);
            Pluma.StartCap = Pluma.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        void Opc()
        {
            switch (Op)
            {
                case 'a':
                    {

                    }break;
            }
        }

















        private void PseudoPaint_Load(object sender, EventArgs e)
        {
            DeclaraPluma(Col, Grosor);
            Puntero = PicMain.CreateGraphics();
            Puntero.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            SelecColor.EditValue = Color.Black;
        }

        void MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                if (ImagenLapiz == null)
                    ImagenLapiz = new Bitmap(this.Width, this.Height);
                using (Graphics g = Graphics.FromImage(ImagenLapiz))
                {
                    Pen pluma = new Pen(Color.Black, 4);
                    g.DrawLine(pluma, previousPoint, e.Location);
                    previousPoint = e.Location;
                    this.Invalidate();
                }
            }
        }

        //=================================================[ Abrir/Guardar ]==========================================================================
        private void BtnAbre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Abrir.ShowDialog();
                PicMain.SizeMode = PictureBoxSizeMode.AutoSize;
                PicMain.ImageLocation = Abrir.FileName;
                PicMain.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                MessageBox.Show("Error al momento de cargar la imagen especificada", "ERROR", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            
        }
        private void BtnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Save.ShowDialog();
                if (Save.FileName != "")
                {
                    //Creamos un BitMap
                    Bitmap Bm = new Bitmap(Pb.Width, Pb.Height);
                    //Cargamos al BitMap
                    Pb.DrawToBitmap(Bm, new Rectangle(0, 0, Pb.Width, Pb.Height));
                    //Creamos un flujo para guardar los datos
                    FileStream Fs = new FileStream(Save.FileName, FileMode.Create, FileAccess.Write);
                    //Guardamos el BitMap en el flujo de datos
                    Bm.Save(Fs, System.Drawing.Imaging.ImageFormat.Png);
                    
                    //Cerramos el flujo
                    Fs.Close();
                    //Limpiamos la imagen de la memoria
                    Bm.Dispose();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al momento de guardar:\n{ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        //=================================================[ Pluma ]==========================================================================
        private void SelecColor_EditValueChanged(object sender, EventArgs e)
        {
            Col = (Color)SelecColor.EditValue;
        }
        private void BarGrueso_EditValueChanged(object sender, EventArgs e)
        {
            BarGrueso.Caption = BarGrueso.EditValue.ToString();
            Grosor = int.Parse(BarGrueso.EditValue.ToString());
        }
        private void BtnPluma_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Col = (Color)SelecColor.EditValue;
            Op = 'P';
        }

        //=================================================[ Borrador ]==========================================================================
        private void BtnBorrador_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Col = Color.White;
            Op = 'B';
        }

        //=================================================[ Texto ]==========================================================================
        private void BtnTexto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Op = 'T';
            Texto T = new Texto();
            T.ShowDialog();
            T.sTexto = sTexto;
            iFuente = iFuente;
            //T.Show();
        }

        //=================================================[ Figuras ]==========================================================================
        
        private void BtnElipse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Op = 'E';
        }
        private void BtnRectangulo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Op = 'R';
        }
        private void BtnLinea_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Op = 'L';
        }
        private void BtnTriangulo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Op = 'T';
        }
        private void BtnExagono_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Op = 'e';
        }

        //=================================================[ Pintar ]==========================================================================
        #region
        private void PicMain_Click(object sender, EventArgs e)
        {
            Pluma = new Pen(Col, Grosor);

         
        }
        private void PicMain_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            Px = e.X;
            Py = e.Y;
            PPoint.X = e.X;
            PPoint.Y = e.Y;
        }
        private void PicMain_MouseMove(object sender, MouseEventArgs e)
        {
            DeclaraPluma(Col, Grosor);
            if (clicked && Px != 0 && Py != 0)
            {
                if (Op == 'P')
                {
                    Col = (Color)SelecColor.EditValue;
                    DeclaraPluma(Col, Grosor);
                    Puntero.DrawLine(Pluma, new Point(Px, Py), e.Location);
                    Px = e.X;
                    Py = e.Y;
                }
                else if(Op == 'B')
                {
                    Puntero.DrawLine(Pluma, new Point(Px, Py), e.Location);
                    Px = e.X;
                    Py = e.Y;
                }
                Pb = (PictureBox)sender;
            }


        }

        private void PicMain_MouseUp(object sender, MouseEventArgs e)
        {
            void Concol()
            {
                Col = (Color)SelecColor.EditValue;
                DeclaraPluma(Col, Grosor);
            }
            
            switch (Op)
            {
                case 'L':
                    {
                        Concol();
                        Puntero.DrawLine(Pluma, PPoint, e.Location);
                    }
                    break;
                case 'E':
                    {
                        Concol();
                        Puntero.DrawEllipse(Pluma, PPoint.X, PPoint.Y, (e.Location.X - PPoint.X), (e.Location.Y - PPoint.Y));
                    }
                    break;
                case 'R':
                    {
                        Concol();
                        Puntero.DrawRectangle(Pluma, PPoint.X, PPoint.Y, (e.Location.X - PPoint.X), (e.Location.Y - PPoint.Y));
                    }
                    break;
                case 'T':
                    {
                        Concol();
                        Point[] P =
                        {
                            new Point(PPoint.X, PPoint.Y),
                            new Point(e.X, e.Y),
                            new Point(PPoint.X, e.Y)
                        };

                        Puntero.DrawPolygon(Pluma, P);
                    }
                    break;
                case 'e':
                    {
                        Concol();
                        Point[] P =
                        {
                            new Point((PPoint.X + ((e.X-PPoint.X)/2)), PPoint.Y),

                            new Point(e.X, PPoint.Y + ((e.Y-PPoint.Y)/4)),
                            new Point(e.X, PPoint.Y + ((e.Y-PPoint.Y)/4)*3),

                            new Point((PPoint.X + ((e.X-PPoint.X)/2)), e.Y),

                            new Point(PPoint.X, PPoint.Y + ((e.Y-PPoint.Y)/4)*3),
                            new Point(PPoint.X, PPoint.Y + ((e.Y-PPoint.Y)/4))

                        };

                        Puntero.DrawPolygon(Pluma, P);
                    }
                    break;
            }

            Pb = (PictureBox)sender;
            Px = 0;
            Py = 0;

        }

        #endregion

        private void BtnComodin_Click(object sender, EventArgs e)
        {
            Btn = (Button)sender;
        }

        private void PicMain_MouseClick(object sender, MouseEventArgs e)
        {
            lbtexto.Text = "cadena generada";
            lbtexto.ForeColor = (Color)Col;
            lbtexto.Location = new System.Drawing.Point(e.Location.X, e.Location.Y);
            this.lbtexto.Font = new System.Drawing.Font("Centuriy Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }













        //    private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //    {
        //        AbrirArchivo.ShowDialog();
        //        string ruta = AbrirArchivo.FileName;

        //    }

        //    private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //    {
        //        saveFileDialog1.ShowDialog();
        //        string ruta = saveFileDialog1.FileName;

        //        ImagenLapiz.Save(ruta);

        //    }

        //}
        ////===================================================================================================================
        //private void PnlMain_MouseMove(object sender, MouseEventArgs e)
        //    {
        //        if (clicked)
        //        {
        //            if (ImagenLapiz == null)
        //                ImagenLapiz = new Bitmap(this.Width, this.Height);
        //            using (Graphics g = Graphics.FromImage(ImagenLapiz))
        //            {
        //                Pen pluma = new Pen(Color.Black, 4);
        //                g.DrawLine(pluma, previousPoint, e.Location);
        //                previousPoint = e.Location;
        //                this.Invalidate();
        //            }
        //        }
        //    }

        //    void Paint(object sender, PaintEventArgs e)
        //    {
        //        if (ImagenLapiz != null)
        //            e.Graphics.DrawImage(ImagenLapiz, 0, 0);
        //    }

        //    void MouseDown(object sender, MouseEventArgs e)
        //    {
        //        clicked = true;
        //        previousPoint = e.Location;
        //    }

        //    void MouseLeave(object sender, EventArgs e)
        //    {
        //        clicked = false;
        //    }

        //    void MouseUp(object sender, MouseEventArgs e)
        //    {
        //        clicked = false;
        //    }



        //    private void BtnPegar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //    {

        //    }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------





    }
}
