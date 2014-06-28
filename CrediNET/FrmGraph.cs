using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using ZedGraph;

namespace CrediNET
{
    
    public partial class FrmGraph : Form
    {
        public FrmGraph(int graphType, Account cmpt)
        {
            InitializeComponent();

            if (graphType == 1)
                Camembert(cmpt);
            else if (graphType == 2)
                Courbes(cmpt);
            
        }

        public void Camembert(Account cmpt)
        {
            var a = zg1.GraphPane;
            zg1.Visible = false;
            lblLoading.Visible = true;

            zg1.GraphPane.GraphObjList.Clear();

            a.CurveList.Clear();

            a.Title.Text = "Compte : " + cmpt.Name;
            a.Title.FontSpec.StringAlignment = StringAlignment.Center;
            a.Title.FontSpec.Family = "Segoe UI Semilight";
            a.Title.FontSpec.Size = 21.75f;

            a.Fill = new Fill(SystemColors.Control);

            a.Chart.Fill.Type = FillType.None;

            a.Legend.Position = LegendPos.Float;
            a.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            a.Legend.FontSpec.Family = "Segoe UI";
            a.Legend.FontSpec.Size = 9f;
            a.Legend.IsHStack = false;

            var nb_seg = cmpt.Operations.Count;
            var segs = new PieItem[nb_seg];

            
            var rnd = new Random();

            var totalC = new Dictionary<string, decimal>();
            var totalD = new Dictionary<string, decimal>();

            // LINQ RULES!
            cmpt.Operations.All(x => 
            {
                if (!totalC.ContainsKey(x.Budget))
                    totalC.Add(x.Budget, 0);
                if (!totalD.ContainsKey(x.Budget))
                    totalD.Add(x.Budget, 0);

                totalC[x.Budget] += x.Credit;
                totalD[x.Budget] += x.Debit;
                return true; 
            });

            var ls = new List<string>();

            totalC.Where(x => x.Value == 0).All(x => { ls.Add(x.Key); return true; });
            ls.ForEach(x => totalC.Remove(x));
            ls.Clear();

            totalD.Where(x => x.Value == 0).All(x => { ls.Add(x.Key); return true; });
            ls.ForEach(x => totalD.Remove(x));
            ls.Clear();

            totalC.All(x => { a.AddPieSlice(Convert.ToDouble(x.Value), System.Drawing.Color.FromArgb(255, rnd.Next(0, 150), 255, rnd.Next(0, 150)), Color.White, 45.0f, 0, x.Key); return true; });
            totalD.All(x => { a.AddPieSlice(Convert.ToDouble(x.Value), System.Drawing.Color.FromArgb(255, 255, rnd.Next(0, 150), rnd.Next(0, 150)), Color.White, 45.0f, 0, x.Key); return true; });

            zg1.IsShowPointValues = true;
            zg1.AxisChange();
            zg1.Refresh();
            lblLoading.Visible = false;
            zg1.Visible = true;
        }

        public void Courbes(Account cmpt)
        {
            var a = zg1.GraphPane;
            zg1.Visible = false;
            lblLoading.Visible = true;

            zg1.GraphPane.GraphObjList.Clear();

            a.LineType = LineType.Normal;
            a.CurveList.Clear();
            a.Title.Text = "Compte : " + cmpt.Name;
            a.Title.FontSpec.StringAlignment = StringAlignment.Center;
            a.Title.FontSpec.Family = "Segoe UI Semilight";
            a.Title.FontSpec.Size = 21.75f;

            a.Fill = new Fill(SystemColors.Control);
            a.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

            a.XAxis.Title.Text = "Date";
            a.XAxis.Title.FontSpec.Family = "Segoe UI";
            a.XAxis.Title.FontSpec.Size = 9f;
            a.XAxis.Type = AxisType.Date;
            a.XAxis.Scale.MajorUnit = DateUnit.Month;
            a.XAxis.Scale.MinorUnit = DateUnit.Day;
            a.XAxis.MajorGrid.IsVisible = true;
            a.XAxis.MajorGrid.PenWidth = 1;
            a.XAxis.MajorGrid.DashOn = 2;
            a.XAxis.MajorGrid.DashOff = 2;
            a.XAxis.MinorGrid.IsVisible = true;
            a.XAxis.MajorTic.Size = 10;
            a.XAxis.IsVisible = true;

            a.YAxis.Title.Text = "€uro";
            a.YAxis.Title.FontSpec.Family = "Segoe UI";
            a.YAxis.Title.FontSpec.Size = 9f;
            a.YAxis.MajorGrid.Color = Color.Black;
            a.YAxis.MajorGrid.IsVisible = true;
            a.YAxis.Scale.FontSpec.FontColor = Color.Black;
            a.YAxis.Title.FontSpec.FontColor = Color.Black;
            a.YAxis.MajorTic.IsOpposite = false;
            a.YAxis.MinorTic.IsOpposite = false;
            a.YAxis.MajorGrid.IsZeroLine = true;
            a.YAxis.Scale.Align = AlignP.Inside;
            a.YAxis.MajorGrid.IsVisible = true;
            a.YAxis.IsVisible = true;


            var crP = new PointPairList();
            decimal Xp = 0;

            for(int l = 0; l<cmpt.Operations.Count; l++)
            {
                if (cmpt.Operations[l].Credit > 0) Xp += cmpt.Operations[l].Credit;
                if (cmpt.Operations[l].Debit > 0) Xp -= cmpt.Operations[l].Debit;

                crP.Add(cmpt.Operations[l].Date.ToOADate(), (double)Xp);
            }

            var cr = a.AddCurve("solde", crP, Color.Red, SymbolType.XCross);


            zg1.PointDateFormat = "dd/MM";
            zg1.IsShowPointValues = true;

            a.YAxis.Scale.MinAuto = true;
            a.YAxis.Scale.MaxAuto = true;

            a.XAxis.Scale.Min = cmpt.Operations.First().Date.ToOADate();
            a.XAxis.Scale.Max = DateTime.Now.ToOADate();

            zg1.AxisChange();
            lblLoading.Visible = false;
            zg1.Visible = true;
        }
    }

    public static class Extensions
    {
        public static void AddOrUpdate(this Dictionary<string, decimal> dic, string key, decimal value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }
    }
}
