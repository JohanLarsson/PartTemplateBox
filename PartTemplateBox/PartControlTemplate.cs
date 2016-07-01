using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace PartTemplateBox
{
    using System.Windows.Controls;

    public class PartControlTemplate
    {
        private ControlTemplate root;
        private ControlTemplate fooPart;
        private ControlTemplate barPart;

        public PartControlTemplate()
        {
        }

        public ControlTemplate Root
        {
            get { return root; }
            set
            {
                root = value;
                Dump(value);
            }
        }

        public ControlTemplate FooPart
        {
            get { return fooPart; }
            set
            {
                fooPart = value;
                Dump(value);
            }
        }

        public ControlTemplate BarPart
        {
            get { return barPart; }
            set
            {
                barPart = value;
                Dump(value);
            }
        }

        public ControlTemplate Current { get; set; }

        private static void Dump(ControlTemplate o, [CallerMemberName] string caller = null)
        {
            File.WriteAllText($@"C:\Temp\Parts\{caller}.xml", XamlWriter.Save(o));
        }
    }
}