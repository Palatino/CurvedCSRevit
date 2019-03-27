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
    [TransactionAttribute(TransactionMode.Manual)]
    public class CurvedCS : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
  
            Reference crv = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
            Element crv2 = doc.GetElement(crv);
            ModelCurve crv3 = crv2 as ModelCurve;
            Curve lin3 = crv3.GeometryCurve;
            List<ElementId> sections = CurvedAux.SectionFromCurve(doc, 20, lin3, 3, -0.2, 1.0, false);

            bool all_changed = CurvedAux.SetSectionsProperties(doc, sections, "Prueba section", false, ViewDetailLevel.Fine, DisplayStyle.Realistic, true, true, 50);

            if (! all_changed)
            {
                TaskDialog.Show("Warning", "Some of the properties of the view couldn't be changed because they are protected, probably by view template applied to sections");
            }

            IList<Element> filviews = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).ToElements();

            ViewSheet vs = filviews[0] as ViewSheet;
            CurvedAux.AlignSectionsOnSheet(doc, sections,vs);
            return Result.Succeeded;

           
        }
    }
}
