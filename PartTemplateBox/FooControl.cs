namespace PartTemplateBox
{
    using System.Windows;
    using System.Windows.Controls;

    public class FooControl : Control
    {
        public static readonly DependencyProperty PartTemplateProperty = DependencyProperty.Register(
            "PartTemplate", 
            typeof(PartControlTemplate),
            typeof(FooControl),
            new PropertyMetadata(default(PartControlTemplate)));

        public PartControlTemplate PartTemplate
        {
            get { return (PartControlTemplate) GetValue(PartTemplateProperty); }
            set { SetValue(PartTemplateProperty, value); }
        }
    }
}
