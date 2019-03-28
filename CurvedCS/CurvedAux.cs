using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace CurvedCS
{
    class CurvedAux
    {
        private static ElementId SectionFromTwoPoints(Document doc, XYZ p1, XYZ p2, double height, double elevation, double view_depth)
        {

            //Convert all numeric values to internal units
            height = UnitUtils.ConvertToInternalUnits(height, DisplayUnitType.DUT_METERS);
            elevation = UnitUtils.ConvertToInternalUnits(elevation, DisplayUnitType.DUT_METERS);
            view_depth = UnitUtils.ConvertToInternalUnits(view_depth, DisplayUnitType.DUT_MILLIMETERS);

            //Filtered the document and get the view section, get its ID
            FilteredElementCollector filter = new FilteredElementCollector(doc);

            Element view1 = filter.OfClass(typeof(ViewFamilyType))
                .WhereElementIsElementType()
                .Cast<ViewFamilyType>()
                .First(x => x.ViewFamily == ViewFamily.Section);


            ElementId viewId = view1.Id;

            //Create a bounding box on the origin

            BoundingBoxXYZ bBox = new BoundingBoxXYZ();
            bBox.Min = new XYZ(0, 0, 0);
            bBox.Max = new XYZ(p1.DistanceTo(p2), height, view_depth);

            //Cartesian transform for the BBox, from 0,0,0 to line initial point
            Transform t = new Transform(Transform.Identity);


            XYZ bb_x = (p2 - p1).Normalize();
            XYZ bb_y = XYZ.BasisZ;
            XYZ bb_z = bb_x.CrossProduct(bb_y);

            t.Origin = new XYZ(p1.X, p1.Y, elevation);
            t.BasisX = bb_x;
            t.BasisY = bb_y;
            t.BasisZ = bb_z;


            bBox.Transform = t;
            //try
            //{
            using (Transaction trans = new Transaction(doc, "Create cross section"))
            {
                trans.Start();

                ViewSection sec = ViewSection.CreateSection(doc, viewId, bBox);
                trans.Commit();
                return sec.Id;
            }
            //}

            // catch
            // {
            //     return null;
            // }

        }

        public static List<ElementId> SectionFromCurve(Document doc, int numberOfSegments, Curve curve, double height, double elevation, double view_depth, bool reverse)
        {
            //Get value of curve parameter
            double step = 1.0 / numberOfSegments;
            IEnumerable<double> parameters = from x in Enumerable.Range(0, numberOfSegments + 1) select x * step;

            //Get points along the curve and project them to zero elevation
            List<XYZ> points = new List<XYZ>();
            foreach (double param in parameters)
            {
                XYZ pt = curve.Evaluate(param, true);
                points.Add(new XYZ(pt.X, pt.Y, 0));

            }

            if (reverse)
            {
                points.Reverse();
            }
            //Create list of Ids and generate sections

            List<ElementId> sections = new List<ElementId>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                ElementId view = SectionFromTwoPoints(doc, points[i], points[i + 1], height, elevation, view_depth);
                sections.Add(view);
            }

            return sections;
        }

        public static bool SetSectionProperties(Document doc, ElementId viewId, string name, bool cropboxvis, ViewDetailLevel detail, DisplayStyle viewstyle, bool annotationHid, bool importedHid, int scale)
        {
            //Retrieve view

            View view = doc.GetElement(viewId) as View;
            bool all_changed = true;

            using( Transaction trans = new Transaction(doc, "Rename view"))
            {
                trans.Start();
                view.Name = name;
                view.CropBoxVisible = cropboxvis;
                try
                {
                    view.DetailLevel = detail;
                }
                catch
                {
                    all_changed = false;
                }

                try
                {
                    view.DisplayStyle = viewstyle;
                }
                catch
                {
                    all_changed = false;
                }

                try
                {
                    view.AreAnnotationCategoriesHidden = annotationHid;
                }
                catch
                {
                    all_changed = false;
                }

                try
                {
                    view.AreImportCategoriesHidden = importedHid;
                }
                catch
                {
                    all_changed = false;
                }

                try
                {
                    view.Scale = scale;
                }
                catch
                {
                    all_changed = false;
                }
                

                trans.Commit();
            }


            return all_changed;
        }

        public static bool SetSectionsProperties(Document doc, List<ElementId> viewIds, string name, bool cropboxvis, ViewDetailLevel detail, DisplayStyle viewstyle, bool annotationHid, bool importedHid, int scale)
        {
            bool all_changed = true;

            List<string> names = new List<string>();
            for (int i=0; i< viewIds.Count; i++ )
            {
                string nam = string.Format("{0} {1}", name, (i + 1).ToString());
                names.Add(nam);
            }

            for (int i = 0; i < viewIds.Count; i++)
            {
                bool result = SetSectionProperties(doc, viewIds[i], names[i], cropboxvis, detail, viewstyle, annotationHid, importedHid, scale);
                if (result != true)
                {
                    all_changed = false;
                }
            }

            return all_changed;
        }

        public static void AlignSectionsOnSheet(Document doc, List<ElementId> viewsIds, ViewSheet sheet)
        {

            //Get scale value of first view

            ViewSection sec1 = doc.GetElement(viewsIds[0]) as ViewSection;
            int scale = sec1.Scale;

            //Get sheet id
            ElementId sheetId = sheet.Id;

            //Get length of views
            List<double> lengths = new List<double>();
            foreach(ElementId idview in viewsIds)
            {
                Element viewEl = doc.GetElement(idview);
                ViewSection viewsec = viewEl as ViewSection;
                double length = viewsec.CropBox.Max.X - viewsec.CropBox.Min.X;
                lengths.Add((length / scale));

            }

            double x_coord = 0;  

            for (int i = 0; i < viewsIds.Count(); i++)
            {
                

                if (i == 0)
                {
                    x_coord = 0;
                }

                else
                {
                    x_coord += (lengths[i - 1] + lengths[i]) / 2.0;
                }

                using (Transaction trans = new Transaction(doc, "Place section in sheet"))
                {
                    trans.Start();
                    XYZ point = new XYZ(x_coord, 0, 0);
                    Viewport v = Viewport.Create(doc, sheetId, viewsIds[i], point);
                    trans.Commit();
                }
            }
        }

    }
}
