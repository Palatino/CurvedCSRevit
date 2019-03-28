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
        private double view_depth_val;
        private Autodesk.Revit.DB.ViewSheet sheet_val;
        private Autodesk.Revit.DB.ViewDetailLevel detail_level_val;
        private Autodesk.Revit.DB.DisplayStyle view_style_val;
        private int scale_val;
        private string name_val;
        private bool importedHidden_val;
        private bool annotationHidden_val;
        private bool reverse;




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

            sheet_drop_down.SelectedIndex = 0;
            view_style_dropdown.SelectedIndex = 0;
            detail_level_dropdown.SelectedIndex = 0;
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
                this.BringToFront();

            }

            catch
            {
                TaskDialog.Show("Error", "Must select a model curve");
                this.BringToFront();
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            // Validate and set number of elements
            bool noS_OK = Validate_NumberOfSegments();

            // Validate view detph
            bool vdepth_ok = Validate_view_depth();

            //Validate and set from Z
            bool fromZ_OK = Validate_fromZ();

            //Validate and set to Z
            bool toZ_OK = Validate_toZ();

            // Validate to Z > from Z

            bool toZ_fZ;

            if(height_val <= 0)
            {
                toZ_fZ = false;
            }

            else
            {
                toZ_fZ = true;
            }
            //Set view
            sheet_val = viewsheets[sheet_drop_down.SelectedIndex];

            // Set display Style

            switch(view_style_dropdown.SelectedIndex)
            {
                case 0:
                    view_style_val = Autodesk.Revit.DB.DisplayStyle.Wireframe;
                    break;

                case 1:
                    view_style_val = Autodesk.Revit.DB.DisplayStyle.HLR;
                    break;

                case 2:
                    view_style_val = Autodesk.Revit.DB.DisplayStyle.Shading;
                    break;

                case 3:
                    view_style_val = Autodesk.Revit.DB.DisplayStyle.FlatColors;
                    break;

                case 4:
                    view_style_val = Autodesk.Revit.DB.DisplayStyle.Realistic;
                    break;

            }

            // Set detail level

            switch(detail_level_dropdown.SelectedIndex)
            {
                case 0:
                    detail_level_val = Autodesk.Revit.DB.ViewDetailLevel.Coarse;
                    break;

                case 1:
                    detail_level_val = Autodesk.Revit.DB.ViewDetailLevel.Medium;
                    break;

                case 2:
                    detail_level_val = Autodesk.Revit.DB.ViewDetailLevel.Fine;
                    break;
            }

            //Validate and set scale

            bool scale_OK  = Validate_scale();

            // Validate and set name

            bool name_OK = Validate_name();

            //Set boolean values

            annotationHidden_val = !showAnnotations.Checked;
            importedHidden_val = !showLinks.Checked;
            reverse = reverse_input.Checked;

            if(name_OK & vdepth_ok & scale_OK & toZ_fZ & toZ_OK & fromZ_OK & noS_OK & !(crv == null))
            {
                try
                {
                    List<Autodesk.Revit.DB.ElementId> views = CurvedAux.SectionFromCurve(doc, number_of_segments_val, crv, this.height_val, this.elevation_val, view_depth_val, this.reverse);
                    CurvedAux.SetSectionsProperties(doc, views, this.name_val, false, this.detail_level_val, this.view_style_val, this.annotationHidden_val, this.importedHidden_val, this.scale_val);
                    CurvedAux.AlignSectionsOnSheet(doc, views, this.sheet_val);
                    TaskDialog.Show("Curved cross section", "Cross sections created and added to sheet");
                    this.BringToFront();
                    //this.Dispose();
                }

                catch
                {
                    TaskDialog.Show("Erro","Something went wrong");
                    this.BringToFront();
                }
            }

            else
            {
                TaskDialog.Show("Error", error_message(name_OK,vdepth_ok, scale_OK, toZ_fZ, toZ_OK, fromZ_OK, noS_OK, !(crv==null)));
                this.BringToFront();
            }


            
        }

        private bool Validate_NumberOfSegments()
        {
            try
            {
                int seg = Convert.ToInt32(NumericSegments.Text);

                if (seg <= 0)
                {
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
                return false;
            }
        }
        private bool Validate_view_depth()
        {
            try
            {
                double vd = Convert.ToDouble(viewDepth_BOX.Text);
                if (vd < 0.6)
                {
                    view_depth_val = 7;
                }
                else
                {
                    view_depth_val = vd;
                }
                
                return true;

            }

            catch
            {
                return false;
            }
        }
        private bool Validate_scale()
        {
            try
            {
                int scl= Convert.ToInt32(scale_input.Text);

                if (scl <= 0)
                {
                    return false;
                }
                else
                {
                    scale_val = scl;
                    return true;
                }
            }

            catch
            {

                return false;
            }

        }
        private bool Validate_name()
        {
            if (string.IsNullOrEmpty(secName.Text)  ||string.IsNullOrWhiteSpace(secName.Text))
            {
                return false;
            }

            else
            {
                name_val = secName.Text;
                return true;
            }
        }
        private void sheet_drop_down_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private string error_message(bool name_OK, bool view_depth_OK ,bool scale_OK, bool toZ_fZ, bool toZ_OK, bool fromZ_OK , bool noS_OK, bool crv_OK)
        {
            string output = string.Empty;
            
            if (!name_OK)
            {
                output += "Provide valid name for views" + Environment.NewLine;
            }
            if (!scale_OK)
            {
                output += "Scale must be a positive integer" + Environment.NewLine;
            }
            if (!view_depth_OK)
            {
                output += "View depth must me a positve number > 0.6 mm" + Environment.NewLine;
            }
            if (!toZ_OK)
            {
                output += "To Z must be a number" + Environment.NewLine;
            }
            if (!fromZ_OK)
            {
                output += "From Z must be a number" + Environment.NewLine;
            }
            if (!fromZ_OK)
            {
                output += "To Z value must be a higher than from Z" + Environment.NewLine;
            }
            if (!noS_OK)
            {
                output += "Number of segments must be a positive integer" + Environment.NewLine;
            }
            if (!crv_OK)
            {
                output += "You have not selected a valid model curve" + Environment.NewLine;
            }

            return output;
        }

        private void viewDepth_BOX_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
