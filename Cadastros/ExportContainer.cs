using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastros
{
    public class ExportContainer
    {
        public string ExportName { get; set; }

        [Export]
        public string GetName()
        {
            this.ExportName = "Cadastros";

            if (this.MyActionDelegate != null)
            {
                this.MyActionDelegate(this.ExportName);
            }

            return this.ExportName;
        }
        public Action<string> MyActionDelegate { get; set; }

        public void carrega_form_usuario()
        {
            Form1 frm_usuario = new Form1();
            frm_usuario.ShowDialog();
        }
    }
}
