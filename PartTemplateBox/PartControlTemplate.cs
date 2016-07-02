using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Linq;
using XamlParseException = System.Windows.Markup.XamlParseException;
using XamlWriter = System.Windows.Markup.XamlWriter;
using XamlReader = System.Windows.Markup.XamlReader;

namespace PartTemplateBox
{
    using System.Windows.Controls;

    public class PartControlTemplate : DependencyObject, ISupportInitialize
    {
        public static readonly DependencyProperty RootProperty = DependencyProperty.Register(
            "Root", 
            typeof(ControlTemplate), 
            typeof(PartControlTemplate), 
            new PropertyMetadata(default(ControlTemplate)),
            OnVerifyTemplate);

        public static readonly DependencyProperty FooPartProperty = DependencyProperty.Register(
            "FooPart", 
            typeof(ControlTemplate),
            typeof(PartControlTemplate), 
            new PropertyMetadata(default(ControlTemplate)),
            OnVerifyTemplate);

        public static readonly DependencyProperty BarPartProperty = DependencyProperty.Register(
            "BarPart", 
            typeof(ControlTemplate), 
            typeof(PartControlTemplate), 
            new PropertyMetadata(
                default(ControlTemplate), 
                OnBarPartChanged),
            OnVerifyTemplate);

        private static readonly DependencyPropertyKey CurrentPropertyKey = DependencyProperty.RegisterReadOnly(
            "Current",
            typeof(ControlTemplate),
            typeof(PartControlTemplate),
            new PropertyMetadata(default(ControlTemplate)));

        public static readonly DependencyProperty CurrentProperty = CurrentPropertyKey.DependencyProperty;

        public ControlTemplate Root
        {
            get { return (ControlTemplate)this.GetValue(RootProperty); }
            set {
                this.SetValue(RootProperty, value); }
        }

        public ControlTemplate FooPart
        {
            get { return (ControlTemplate)this.GetValue(FooPartProperty); }
            set {
                this.SetValue(FooPartProperty, value); }
        }

        public ControlTemplate BarPart
        {
            get { return (ControlTemplate)this.GetValue(BarPartProperty); }
            set {
                this.SetValue(BarPartProperty, value); }
        }

        //public ControlTemplate Current => CreateTemplate();

        void ISupportInitialize.BeginInit()
        {
            this.Current = this.CreateTemplate();
        }

        void ISupportInitialize.EndInit()
        {
        }

        public ControlTemplate Current
        {
            get { return (ControlTemplate)this.GetValue(CurrentProperty); }
            protected set { this.SetValue(CurrentPropertyKey, value); }
        }

        internal static string GetSinglePart(string xaml, string partName)
        {
            var element = XElement.Parse(xaml).Elements().Single();
            var name = element.Attribute("Name");
            if (name != null)
            {
                if (name.Value != partName)
                {
                    throw new XamlParseException($"Expected name to be: '{partName}' but was: '{name.Value}'");
                }
            }
            else
            {
                element.Add(new XAttribute("Name", partName));
            }


            return element.ToString(SaveOptions.DisableFormatting);
        }

        private static bool OnVerifyTemplate(object o)
        {
            if (o == null)
            {
                return true;
            }

            var template = o as ControlTemplate;
            if (template?.TargetType != null)
            {
                if (typeof(FooControl).IsAssignableFrom(template.TargetType))
                {
                    return true;
                }
            }

            return false;
        }

        private static void OnBarPartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Dump((ControlTemplate)e.NewValue, BarPartProperty.Name);
        }

        private ControlTemplate CreateTemplate()
        {
            var rootElement = XElement.Parse(XamlWriter.Save(this.Root));
            //rootElement.DescendantNodes().OfType<XElement>().Where(e=>e.Attribute())
            var template = (ControlTemplate)XamlReader.Parse(rootElement.ToString());
            return template;
        }

        private static void Dump(ControlTemplate template, string templateName = null)
        {
            if (template != null)
            {
                File.WriteAllText($@"C:\Temp\Parts\{templateName}.xml", XamlWriter.Save(template));
            }
        }
    }
}