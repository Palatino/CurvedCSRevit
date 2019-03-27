using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using System.Windows.Forms;

namespace CurvedCS
{
    public partial class FrontForm : Form
    {
        public Autodesk.Revit.UI.UIDocument uidoc;
        public IList<Autodesk.Revit.DB.ViewSheet> viewsheets;
        public Autodesk.Revit.DB.Document doc;

        private Autodesk.Revit.DB.Curve crv;
        private int number_of_segments_val;
        private double height_val;
        private double elevation_val;
        private Autodesk.Revit.DB.ViewSheet sheet_val;
        private Autodesk.Revit.DB.ViewDetailLevel detail_level_val;
        private Autodesk.Revit.DB.DisplayStyle view_style_val;
        private int scale_val;
        private string name_val;
        private bool importedHidden_val;
        private bool annotationHidden_val;
        private bool all_data_correct = true;




        public FrontForm(Autodesk.Revit.UI.UIDocument document, IList<Autodesk.Revit.DB.ViewSheet> sheets)
        {
            uidoc = document;
            doc = uidoc.Document;
            viewsheets = sheets;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<string> view_names = new List<string>();
            foreach (Autodesk.Revit.DB.ViewSheet sht in viewsheets)
            {
                string name1 = string.Format("{0}-{1}", sht.SheetNumber.ToString(), sht.Name);
                view_names.Add(name1);
            }

            foreach (string code in view_names)
            {
                sheet_drop_down.Items.Add(code);
            }
        }

        private void SelectCurve_Click(object sender, EventArgs e)
        {
            try
            {
                Autodesk.Revit.DB.Reference eleR = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
                Autodesk.Revit.DB.Element ele = doc.GetElement(eleR);
                Autodesk.Revit.DB.ModelCurve curve = ele as Autodesk.Revit.DB.ModelCurve;
                crv = curve.GeometryCurve;
                CurveID.Text = string.Format("Curve: {0}", curve.Id.ToString());
                Show();

            }

            catch
            {
                TaskDialog.Show("Error", "Must select a model curve");
                Show();
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            // Validate number of elements
            Validate_NumberOfSegments();
            Validate_fromZ();
            Validate_toZ();

        }

        private bool Validate_NumberOfSegments()
        {
            try
            {
                int seg = Convert.ToInt32(NumericSegments.Text);

                if (seg <= 0)
                {
                    TaskDialog.Show("Error", "Number of elements must be a positive integer");

                    this.Show();
                    return false;
                }
                else
                {
                    number_of_segments_val = seg;
                    return true;
                }
            }

            catch
            {
                TaskDialog.Show("Error", "Number of elements must be a positive integer");
                this.Show();
                return false;
            }
        }
        private bool Validate_fromZ()
        {
            try
            {
                double z = Convert.ToDouble(fromZ_Input.Text);
                elevation_val = z;
                return true;

            }

            catch
            {
                TaskDialog.Show("Error", "From Z must be a number");
                this.Show();
                return false;
            }
        }
        private bool Validate_toZ()
        {
            try
            {
                double z = Convert.ToDouble(toZInput.Text);
                height_val = z - elevation_val;
                return true;

            }

            catch
            {
                TaskDialog.Show("Error", "From Z must be a number");
                this.Show();
                return false;
            }
        }


        private void sheet_drop_down_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
