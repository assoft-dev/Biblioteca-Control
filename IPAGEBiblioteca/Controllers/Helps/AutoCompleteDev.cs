using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IPAGEBiblioteca.Controllers.Helps
{
    public class AutoCompleteDev
    {
        public static void Autocomplete(TextEdit edit, List<string> listF)
        {
            if (listF.Count == 0)
                return;
            else
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                foreach (var item in listF)
                    collection.Add(item);
                edit.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                edit.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                edit.MaskBox.AutoCompleteCustomSource = collection;
            }
        }
    }
}
