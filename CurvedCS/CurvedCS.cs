using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;

namespace CurvedCS
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class CurvedCS : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;


            IList<Element>  e_viewSheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).ToElements();
            List<ViewSheet> viewSheets = new List<ViewSheet>();

            foreach(Element el in e_viewSheets)
            {
                ViewSheet view = el as ViewSheet;
                viewSheets.Add(view);
            }

            FrontForm form = new FrontForm(uidoc, viewSheets);
            Application.Run(form);
  

            return Result.Succeeded;

           
        }
    }
}
