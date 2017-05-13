using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Losowe_figury_geometryczne
{
    public partial class LosoweFiguryGeometryczne : Form
    {
        const int pj_Margines = 20;
        static LosoweFiguryGeometryczne ReferencjeDoFormularza;
        static Graphics PlanszaGraf;
        TPunkt[] pj_TablicaFigur;
        int pj_IndexTablicyFigur;
        public LosoweFiguryGeometryczne()
        {
            InitializeComponent();
            btnRandom_los.Enabled = false;
            btnNew_place.Enabled = false;
            ReferencjeDoFormularza = this;
            PlanszaGraf = imgPlansza.CreateGraphics();
            this.Left = 15;
            this.Top = 15;
            this.MaximizeBox = false;
        }
        public class TPunkt
        {
            protected const int pj_RozmiarPunktu = 10;
            protected int pj_X, pj_Y;
            protected Color pj_kolor;
            protected bool pj_Widoczny;
            protected int pj_GruboscLinii;
            protected DashStyle pj_RodzajLinii;
            public TPunkt(int pj_X, int pj_Y)
            {
                this.pj_X = pj_X;
                this.pj_Y = pj_Y;
                pj_kolor = Color.Black;
            }
            public TPunkt(int pj_x, int pj_y, Color pj_KolorPunktu)
            {
                pj_X = pj_x;
                pj_Y = pj_y;
                pj_kolor = pj_KolorPunktu;
            }
            public void UstawXY(int pj_x, int pj_y)
            {
                pj_X = pj_x;
                pj_Y = pj_y;
            }
            public void UstawKolor(Color KolorPunktu)
            {
                pj_kolor = KolorPunktu;
            }
            public virtual void Wykresl()
            {
                SolidBrush Pedzel = new SolidBrush(pj_kolor);
                PlanszaGraf.FillEllipse(Pedzel, pj_X - pj_RozmiarPunktu / 2, pj_Y - pj_RozmiarPunktu / 2, pj_RozmiarPunktu, pj_RozmiarPunktu);
                pj_Widoczny = true;
                Pedzel.Dispose();
            }
            public virtual void Wymaz()
            {
                if (pj_Widoczny)
                {
                    
                    SolidBrush Pedzel = new SolidBrush(ReferencjeDoFormularza.imgPlansza.BackColor);
                    PlanszaGraf.FillEllipse(Pedzel, pj_X - pj_RozmiarPunktu / 2, pj_Y - pj_RozmiarPunktu / 2, pj_RozmiarPunktu, pj_RozmiarPunktu);
                    pj_Widoczny = false;
                    Pedzel.Dispose();
                }
            }
            public void PrzesundoXY(int pj_x, int pj_y)
            {
                Wymaz();
                UstawXY(pj_x, pj_y);
                Wykresl();
            }
            public void UstawieniaAtrybutowGraficznych(Color pj_KolorLinii, int pj_GruboscLinii, DashStyle pj_RodzajLinii)
            {
                pj_kolor = pj_KolorLinii;
                this.pj_GruboscLinii = pj_GruboscLinii;
                this.pj_RodzajLinii = pj_RodzajLinii;
            }
        }
        public class TOkrag : TPunkt
        {
            protected int pj_Promien;
            public TOkrag(int pj_x, int pj_y, int pj_R)
                : base(pj_x, pj_y)
            {
                pj_Promien = pj_R;
                pj_GruboscLinii = 1;
                pj_RodzajLinii = DashStyle.Solid;
            }
            public TOkrag(int pj_x, int pj_y, int pj_R, Color pj_KolorLinii, int pj_GruboscLinii, DashStyle pj_RodzajLinii)
                : base(pj_x, pj_y, pj_KolorLinii)
            {
                pj_Promien = pj_R;
                this.pj_GruboscLinii = pj_GruboscLinii;
                this.pj_RodzajLinii = pj_RodzajLinii;
            }
            public override void Wykresl()
            {
                Pen pioro = new Pen(pj_kolor, pj_GruboscLinii);
                pioro.DashStyle = pj_RodzajLinii;
                PlanszaGraf.DrawEllipse(pioro, pj_X - pj_Promien, pj_Y - pj_Promien, 2 * pj_Promien, 2 * pj_Promien);
                pj_Widoczny = true;
                pioro.Dispose();
            }
            public override void Wymaz()
            {
                if (pj_Widoczny)
                {
                    Pen Pioro = new Pen(ReferencjeDoFormularza.imgPlansza.BackColor, pj_GruboscLinii);
                    PlanszaGraf.DrawEllipse(Pioro, pj_X - pj_Promien, pj_Y - pj_Promien, 2 * pj_Promien, 2 * pj_Promien);
                    pj_Widoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        public class TFillOkrag : TPunkt
        {
            protected int pj_Promien;
            public TFillOkrag(int pj_x, int pj_y, int pj_R)
                : base(pj_x, pj_y)
            {
                pj_Promien = pj_R;
                pj_GruboscLinii = 1;
                pj_RodzajLinii = DashStyle.Solid;
            }
            public TFillOkrag(int pj_x, int pj_y, int pj_R, Color pj_KolorLinii, int pj_GruboscLinii, DashStyle pj_RodzajLinii)
                : base(pj_x, pj_y, pj_KolorLinii)
            {
                pj_Promien = pj_R;
                this.pj_GruboscLinii = pj_GruboscLinii;
                this.pj_RodzajLinii = pj_RodzajLinii;
            }
            public override void Wykresl()
            {
                SolidBrush Pedzel = new SolidBrush(pj_kolor);
                PlanszaGraf.FillEllipse(Pedzel, pj_X - pj_Promien, pj_Y - pj_Promien, 2 * pj_Promien, 2 * pj_Promien);
                pj_Widoczny = true;
                Pedzel.Dispose();
            }
            public override void Wymaz()
            {
                if (pj_Widoczny)
                {
                    SolidBrush Pedzel = new SolidBrush(ReferencjeDoFormularza.imgPlansza.BackColor);
                    PlanszaGraf.FillEllipse(Pedzel, pj_X - pj_Promien, pj_Y - pj_Promien, 2 * pj_Promien, 2 * pj_Promien);
                    pj_Widoczny = false;
                    Pedzel.Dispose();
                }
                
            }
        }
        public class TLinia : TPunkt
        {
            public TLinia(int pj_x, int pj_y)
                : base(pj_x, pj_y)
            {
                pj_GruboscLinii = 1;
                pj_RodzajLinii = DashStyle.Solid;
            }
            public TLinia(int pj_x, int pj_y, Color pj_KolorLinii, int pj_GruboscLinii, DashStyle pj_RodzajLinii)
                : base(pj_x, pj_y, pj_KolorLinii)
            {
                this.pj_GruboscLinii = pj_GruboscLinii;
                this.pj_RodzajLinii = pj_RodzajLinii;
            }
            public override void Wykresl()
            {
                Pen Pioro = new Pen(pj_kolor, pj_GruboscLinii);
                Pioro.DashStyle = pj_RodzajLinii;
                PlanszaGraf.DrawLine(Pioro, pj_X + 10, pj_Y + 10, pj_X - pj_RozmiarPunktu,
                    pj_Y - pj_RozmiarPunktu);
                pj_Widoczny = true;

                Pioro.Dispose();
            }
            public override void Wymaz()
            {
                if (pj_Widoczny)
                {
                    Pen Pioro = new Pen(ReferencjeDoFormularza.imgPlansza.BackColor, pj_GruboscLinii);
                    PlanszaGraf.DrawLine(Pioro, pj_X + 10, pj_Y + 10, pj_X - pj_RozmiarPunktu,
                    pj_Y - pj_RozmiarPunktu);
                    pj_Widoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        public class Ttrojkat : TPunkt
        {
            public Ttrojkat(int pj_x, int pj_y)
                : base(pj_x, pj_y)
            {
                pj_GruboscLinii = 1;
                pj_RodzajLinii = DashStyle.Solid;
            }
            public Ttrojkat(int pj_x, int pj_y, Color pj_KolorLinii, int pj_GruboscLinii, DashStyle pj_RodzajLinii)
                : base(pj_x, pj_y, pj_KolorLinii)
            {
                this.pj_GruboscLinii = pj_GruboscLinii;
                this.pj_RodzajLinii = pj_RodzajLinii;
            }
            public override void Wykresl()
            {
                Pen Pioro = new Pen(pj_kolor, pj_GruboscLinii);
                Pioro.DashStyle = pj_RodzajLinii;
                PlanszaGraf.DrawLine(Pioro, pj_X + 50 - pj_Margines/2, pj_Y - pj_Margines/2, pj_X - pj_Margines/2, pj_Y + 50 - pj_Margines/2);
                PlanszaGraf.DrawLine(Pioro, pj_X + 100 - pj_Margines/2, pj_Y + 50 - pj_Margines/2, pj_X + 50 - pj_Margines/2, pj_Y - pj_Margines/2);
                PlanszaGraf.DrawLine(Pioro, pj_X - pj_Margines/2, pj_Y + 50 - pj_Margines/2, pj_X + 100 - pj_Margines/2, pj_Y + 50 - pj_Margines/2);
                
                pj_Widoczny = true;

                Pioro.Dispose();
            }
            public override void Wymaz()
            {
                if (pj_Widoczny)
                {
                    Pen Pioro = new Pen(ReferencjeDoFormularza.imgPlansza.BackColor, pj_GruboscLinii);
                    PlanszaGraf.DrawLine(Pioro, pj_X + 50 - pj_Margines / 2, pj_Y - pj_Margines / 2, pj_X - pj_Margines / 2, pj_Y + 50 - pj_Margines / 2);
                    PlanszaGraf.DrawLine(Pioro, pj_X + 100 - pj_Margines / 2, pj_Y + 50 - pj_Margines / 2, pj_X + 50 - pj_Margines / 2, pj_Y - pj_Margines / 2);
                    PlanszaGraf.DrawLine(Pioro, pj_X - pj_Margines / 2, pj_Y + 50 - pj_Margines / 2, pj_X + 100 - pj_Margines / 2, pj_Y + 50 - pj_Margines / 2);
                
                    pj_Widoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        public class TtrojkatProstokatny : TPunkt
        {
            public TtrojkatProstokatny(int pj_x, int pj_y)
                : base(pj_x, pj_y)
            {
                pj_GruboscLinii = 1;
                pj_RodzajLinii = DashStyle.Solid;
            }
            public TtrojkatProstokatny(int pj_x, int pj_y, Color pj_KolorLinii, int pj_GruboscLinii, DashStyle pj_RodzajLinii)
                : base(pj_x, pj_y, pj_KolorLinii)
            {
                this.pj_GruboscLinii = pj_GruboscLinii;
                this.pj_RodzajLinii = pj_RodzajLinii;
            }
            public override void Wykresl()
            {
                Pen Pioro = new Pen(pj_kolor, pj_GruboscLinii);
                Pioro.DashStyle = pj_RodzajLinii;
                PlanszaGraf.DrawLine(Pioro, pj_X + 100 - pj_Margines, pj_Y + 30 - pj_Margines, pj_X + 30 - pj_Margines, pj_Y + 100 - pj_Margines);
                PlanszaGraf.DrawLine(Pioro, pj_X + 100 - pj_Margines, pj_Y + 30 - pj_Margines, pj_X + 100 - pj_Margines, pj_Y + 100 - pj_Margines);
                PlanszaGraf.DrawLine(Pioro, pj_X + 30 - pj_Margines, pj_Y + 100 - pj_Margines, pj_X + 100 - pj_Margines, pj_Y + 100 - pj_Margines);
                pj_Widoczny = true;

                Pioro.Dispose();
            }
            public override void Wymaz()
            {
                if (pj_Widoczny)
                {
                    Pen Pioro = new Pen(ReferencjeDoFormularza.imgPlansza.BackColor, pj_GruboscLinii);
                    PlanszaGraf.DrawLine(Pioro, pj_X + 100 - pj_Margines, pj_Y + 30 - pj_Margines, pj_X + 30 - pj_Margines, pj_Y + 100 - pj_Margines);
                    PlanszaGraf.DrawLine(Pioro, pj_X + 100 - pj_Margines, pj_Y + 30 - pj_Margines, pj_X + 100 - pj_Margines, pj_Y + 100 - pj_Margines);
                    PlanszaGraf.DrawLine(Pioro, pj_X + 30 - pj_Margines, pj_Y + 100 - pj_Margines, pj_X + 100 - pj_Margines, pj_Y + 100 - pj_Margines);
                    pj_Widoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        public class TProstokat : TPunkt
        {
            public TProstokat(int pj_x, int pj_y)
                : base(pj_x, pj_y)
            {
                pj_GruboscLinii = 1;
                pj_RodzajLinii = DashStyle.Solid;
            }
            public TProstokat(int pj_x, int pj_y, Color pj_KolorLinii, int pj_GruboscLinii, DashStyle pj_RodzajLinii)
                : base(pj_x, pj_y, pj_KolorLinii)
            {
                this.pj_GruboscLinii = pj_GruboscLinii;
                this.pj_RodzajLinii = pj_RodzajLinii;
            }
            public override void Wykresl()
            {
                Pen Pioro = new Pen(pj_kolor, pj_GruboscLinii);
                Pioro.DashStyle = pj_RodzajLinii;
                PlanszaGraf.DrawRectangle(Pioro, pj_X - pj_RozmiarPunktu / 2,
                    pj_Y - pj_RozmiarPunktu / 2, pj_RozmiarPunktu * 6, pj_RozmiarPunktu * 2);
                pj_Widoczny = true;

                Pioro.Dispose();
            }
            public override void Wymaz()
            {
                if (pj_Widoczny)
                {
                    Pen Pioro = new Pen(ReferencjeDoFormularza.imgPlansza.BackColor, pj_GruboscLinii);
                    PlanszaGraf.DrawRectangle(Pioro, pj_X - pj_RozmiarPunktu / 2,
                    pj_Y - pj_RozmiarPunktu / 2, pj_RozmiarPunktu * 6, pj_RozmiarPunktu * 2);
                    pj_Widoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        public class TKwadrat : TPunkt
        {
            public TKwadrat(int pj_x, int pj_y)
                : base(pj_x, pj_y)
            {
                pj_GruboscLinii = 1;
                pj_RodzajLinii = DashStyle.Solid;
            }
            public TKwadrat(int pj_x, int pj_y, Color pj_KolorLinii, int pj_GruboscLinii, DashStyle pj_RodzajLinii)
                : base(pj_x, pj_y, pj_KolorLinii)
            {
                this.pj_GruboscLinii = pj_GruboscLinii;
                this.pj_RodzajLinii = pj_RodzajLinii;
            }
            public override void Wykresl()
            {
                Pen Pioro = new Pen(pj_kolor, pj_GruboscLinii);
                Pioro.DashStyle = pj_RodzajLinii;
                PlanszaGraf.DrawRectangle(Pioro, pj_X - pj_RozmiarPunktu / 2,
                    pj_Y - pj_RozmiarPunktu / 2, pj_RozmiarPunktu * 5, pj_RozmiarPunktu * 5);
                pj_Widoczny = true;

                Pioro.Dispose();
            }
            public override void Wymaz()
            {
                if (pj_Widoczny)
                {
                    Pen Pioro = new Pen(ReferencjeDoFormularza.imgPlansza.BackColor, pj_GruboscLinii);
                    PlanszaGraf.DrawRectangle(Pioro, pj_X - pj_RozmiarPunktu / 2,
                    pj_Y - pj_RozmiarPunktu / 2, pj_RozmiarPunktu * 5, pj_RozmiarPunktu * 5);
                    pj_Widoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            //TPunkt A = new TPunkt(200, 100, Color.Red);
            //A.Wykresl();
            //TOkrag O1 = new TOkrag(100, 50, 30);
            //O1.Wykresl();
            //O1.UstawXY(150, 100);
            //TPunkt Figura = O1;
            //Figura.Wykresl();
            

            int pj_N;
            if (!int.TryParse(txtLiczbaFigur.Text, out pj_N))
            {
                ERROR.SetError(txtLiczbaFigur, "ERROR: Błąd w zapisie liczności figur");
                return;
            }
            else
            {
                txtLiczbaFigur.Enabled = false;
                ERROR.Dispose();
            }
            if (pj_N <= 0)
            {
                ERROR.SetError(txtLiczbaFigur, "ERROR: Liczba figur musi być > 0");
                return;
            }
            else
                ERROR.Dispose();
            if (chlbFigury.CheckedItems.Count <= 0)
            {
                ERROR.SetError(btnStart, "ERROR: Nie wybrano figury!");
                return;
            }
            else
                ERROR.Dispose();
            btnRandom_los.Enabled = true;
            btnNew_place.Enabled = true;
            btnStart.Enabled = false;
            pj_TablicaFigur = new TPunkt[pj_N];
            pj_IndexTablicyFigur = 0;
            int[] pj_TablicaWybranychFigur = new int[chlbFigury.CheckedItems.Count];
            int pj_IndexTablicyWybranychFigur = 0;

            foreach (object WybranaFigura in chlbFigury.CheckedItems)
            {
                pj_TablicaWybranychFigur[pj_IndexTablicyWybranychFigur++] = chlbFigury.Items.IndexOf(WybranaFigura);
            }

            int pj_Xp, pj_Yp;
            Color pj_Kolor;
            int pj_GruboscLinii;
            DashStyle pj_Dashstyle;
            int pj_R;
            Random pj_LiczbaLosowa = new Random();
            int pj_Xmax = this.imgPlansza.Width;
            int pj_Ymax = this.imgPlansza.Height;

            for (int i = 0; i < pj_TablicaFigur.Length; i++)
            {
                pj_Xp = pj_LiczbaLosowa.Next(pj_Margines, pj_Xmax - pj_Margines);
                pj_Yp = pj_LiczbaLosowa.Next(pj_Margines, pj_Ymax - pj_Margines);
                pj_Kolor = Color.FromArgb(pj_LiczbaLosowa.Next(0, 256), pj_LiczbaLosowa.Next(0, 256), pj_LiczbaLosowa.Next(0, 256));
                pj_GruboscLinii = pj_LiczbaLosowa.Next(1, 10);
                pj_R = pj_LiczbaLosowa.Next(5, pj_Ymax / 4);
                switch (pj_LiczbaLosowa.Next(1,5))
                {
                    case 1:
                        pj_Dashstyle = DashStyle.Solid;
                        break;
                    case 2:
                        pj_Dashstyle = DashStyle.Dot;
                        break;
                    case 3:
                        pj_Dashstyle = DashStyle.Dash;
                        break;
                    case 4:
                        pj_Dashstyle = DashStyle.DashDot;
                        break;
                    case 5:
                        pj_Dashstyle = DashStyle.DashDotDot;
                        break;
                    default:
                        pj_Dashstyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;
                }
                CheckedListBox.CheckedIndexCollection pj_WybranaFigura = chlbFigury.CheckedIndices;
                switch (pj_WybranaFigura[i % pj_WybranaFigura.Count])
                {
                    case 0:
                        pj_TablicaFigur[i] = new TPunkt(pj_Xp, pj_Yp);
                        pj_TablicaFigur[i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        TPunkt p1 = pj_TablicaFigur[i] as TPunkt;
                        p1.Wykresl();
                        break;
                    case 1:
                        pj_TablicaFigur[i] = new TLinia(pj_Xp, pj_Yp);
                        pj_TablicaFigur[i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        TPunkt l1 = pj_TablicaFigur[i] as TLinia;
                        l1.Wykresl();
                        break;
                    case 2:
                        pj_TablicaFigur[i] = new TOkrag(pj_Xp, pj_Yp, pj_R);
                        pj_TablicaFigur[i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        TPunkt o1 = pj_TablicaFigur[i] as TOkrag;
                        o1.Wykresl();
                        break;
                    case 3:
                        pj_TablicaFigur[i] = new TFillOkrag(pj_Xp, pj_Yp, pj_R);
                        pj_TablicaFigur[i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        TPunkt fo1 = pj_TablicaFigur[i] as TFillOkrag;
                        fo1.Wykresl();
                        break;
                    case 4:
                        pj_TablicaFigur[i] = new TProstokat(pj_Xp, pj_Yp);
                        pj_TablicaFigur[i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        TPunkt pr1 = pj_TablicaFigur[i] as TProstokat;
                        pr1.Wykresl();
                        break;
                    case 5:
                        pj_TablicaFigur[i] = new TKwadrat(pj_Xp, pj_Yp);
                        pj_TablicaFigur[i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        TPunkt k1 = pj_TablicaFigur[i] as TKwadrat;
                        k1.Wykresl();
                        break;
                    case 6:
                        pj_TablicaFigur[i] = new Ttrojkat(pj_Xp, pj_Yp);
                        pj_TablicaFigur[i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        TPunkt t1 = pj_TablicaFigur[i] as Ttrojkat;
                        t1.Wykresl();
                        break;
                    case 7:
                        pj_TablicaFigur[i] = new TtrojkatProstokatny(pj_Xp, pj_Yp);
                        pj_TablicaFigur[i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        TPunkt tp1 = pj_TablicaFigur[i] as TtrojkatProstokatny;
                        tp1.Wykresl();
                        break;
                    default:
                        ERROR.SetError(btnStart, "ERROR: nierozpoznana figura geometryczna");
                        return;
                }

            }
        }

        private void btnNew_place_Click(object sender, EventArgs e)
        {
            int pj_i, pj_N;
            pj_N = pj_TablicaFigur.Length;

            int pj_Xmax = this.imgPlansza.Width;
            int pj_Ymax = this.imgPlansza.Height;

            Random pj_LosowaLiczba = new Random();
            int pj_Xp, pj_Yp;

            for (pj_i = 0; pj_i < pj_N; pj_i++)
            {
                pj_Xp = pj_LosowaLiczba.Next(pj_Margines, pj_Xmax - pj_Margines);
                pj_Yp = pj_LosowaLiczba.Next(pj_Margines, pj_Ymax - pj_Margines);

                pj_TablicaFigur[pj_i].PrzesundoXY(pj_Xp, pj_Yp);
            }
        }

        private void btnRandom_los_Click(object sender, EventArgs e)
        {
            int pj_i, pj_N;
            Color pj_Kolor;
            pj_N = pj_TablicaFigur.Length;

            for (pj_i = 0; pj_i < pj_N; pj_i++)
            {
                pj_TablicaFigur[pj_i].Wymaz();
            }

            int pj_GruboscLinii;
            int pj_Xmax = this.imgPlansza.Width;
            int pj_Ymax = this.imgPlansza.Height;

            
            int pj_Xp, pj_Yp;
            DashStyle pj_StylLinii;
            

            Random LiczbaLosowa = new Random();

            for (pj_i = 0; pj_i < pj_N; pj_i++)
            {
                pj_Xp = LiczbaLosowa.Next(pj_Margines, pj_Xmax - pj_Margines);
                pj_Yp = LiczbaLosowa.Next(pj_Margines, pj_Ymax - pj_Margines);

                pj_Kolor = Color.FromArgb(LiczbaLosowa.Next(0, 255),
                                            LiczbaLosowa.Next(0, 255),
                                            LiczbaLosowa.Next(0, 255));

                switch (LiczbaLosowa.Next(1, 6))
                {
                    case 1:
                        pj_StylLinii = System.Drawing.Drawing2D.DashStyle.Dash;
                        break;
                    case 2:
                        pj_StylLinii = System.Drawing.Drawing2D.DashStyle.DashDot;
                        break;
                    case 3:
                        pj_StylLinii = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                        break;
                    case 4:
                        pj_StylLinii = System.Drawing.Drawing2D.DashStyle.Dot;
                        break;
                    case 5:
                        pj_StylLinii = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;
                    default:
                        pj_StylLinii = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;
                }
                pj_GruboscLinii = LiczbaLosowa.Next(1, 10);
                pj_TablicaFigur[pj_i].UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_StylLinii);
                pj_TablicaFigur[pj_i].UstawXY(pj_Xp, pj_Yp);
                pj_TablicaFigur[pj_i].Wykresl();
            }
        }

        private void btnLosowaFigura_Click(object sender, EventArgs e)
        {
            btnNew_place.Enabled = false;
            btnRandom_los.Enabled = false;
            chlbFigury.Enabled = false;
            int pj_Xp, pj_Yp;
            Color pj_Kolor;
            int pj_GruboscLinii;
            DashStyle pj_Dashstyle;
            int pj_R;
            Random pj_LiczbaLosowa = new Random();
            int pj_Xmax = this.imgPlansza.Width;
            int pj_Ymax = this.imgPlansza.Height;

                pj_Xp = pj_LiczbaLosowa.Next(pj_Margines, pj_Xmax - pj_Margines);
                pj_Yp = pj_LiczbaLosowa.Next(pj_Margines, pj_Ymax - pj_Margines);
                pj_Kolor = Color.FromArgb(pj_LiczbaLosowa.Next(0, 256), pj_LiczbaLosowa.Next(0, 256), pj_LiczbaLosowa.Next(0, 256));
                pj_GruboscLinii = pj_LiczbaLosowa.Next(1, 10);
                pj_R = pj_LiczbaLosowa.Next(5, pj_Ymax / 4);
                switch (pj_LiczbaLosowa.Next(1,5))
                {
                    case 1:
                        pj_Dashstyle = DashStyle.Solid;
                        break;
                    case 2:
                        pj_Dashstyle = DashStyle.Dot;
                        break;
                    case 3:
                        pj_Dashstyle = DashStyle.Dash;
                        break;
                    case 4:
                        pj_Dashstyle = DashStyle.DashDot;
                        break;
                    case 5:
                        pj_Dashstyle = DashStyle.DashDotDot;
                        break;
                    default:
                        pj_Dashstyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;
                }
                CheckedListBox.CheckedIndexCollection pj_WybranaFigura = chlbFigury.CheckedIndices;
                Random los = new Random();
                switch (los.Next(0,6))
                {
                    case 0:
                        TPunkt p1 = new TPunkt(pj_Xp, pj_Yp);
                        p1.UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        p1.Wykresl();
                        break;
                    case 1:
                        TLinia l1 = new TLinia(pj_Xp, pj_Yp);
                        l1.UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        l1.Wykresl();
                        break;
                    case 2:
                        TOkrag o1 = new TOkrag(pj_Xp, pj_Yp, pj_R);
                        o1.UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        o1.Wykresl();
                        break;
                    case 3:
                        TFillOkrag fo1 = new TFillOkrag(pj_Xp, pj_Yp, pj_R);
                        fo1.UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        fo1.Wykresl();
                        break;
                    case 4:
                        TProstokat pr1 = new TProstokat(pj_Xp, pj_Yp);
                        pr1.UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        pr1.Wykresl();
                        break;
                    case 5:
                        TKwadrat k1 = new TKwadrat(pj_Xp, pj_Yp);
                        k1.UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        k1.Wykresl();
                        break;
                    case 6:
                        Ttrojkat t1 = new Ttrojkat(pj_Xp, pj_Yp);
                        t1.UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        t1.Wykresl();
                        break;
                    case 7:
                        TtrojkatProstokatny tp1 = new TtrojkatProstokatny(pj_Xp, pj_Yp);
                        tp1.UstawieniaAtrybutowGraficznych(pj_Kolor, pj_GruboscLinii, pj_Dashstyle);
                        tp1.Wykresl();
                        break;
                    default:
                        ERROR.SetError(btnStart, "ERROR: nierozpoznana figura geometryczna");
                        return;
                }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            chlbFigury.Enabled = true;
            PlanszaGraf.Clear(ReferencjeDoFormularza.imgPlansza.BackColor);
            txtLiczbaFigur.Clear();
            btnStart.Enabled = true;
            btnRandom_los.Enabled = true;
            btnNew_place.Enabled = true;
            txtLiczbaFigur.Enabled = true;
            txtLiczbaFigur.Text = "";
            

        }
    }
}
