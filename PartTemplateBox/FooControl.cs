namespace PartTemplateBox
{
    using System.Windows;
    using System.Windows.Controls;

    public class FooControl : Control
    {
        public static readonly DependencyProperty StringTemplateProperty = DependencyProperty.Register(
            "StringTemplate", 
            typeof(ControlTemplate),
            typeof(FooControl),
            new PropertyMetadata(default(ControlTemplate)));

        public static readonly DependencyProperty BoolTemplateProperty = DependencyProperty.Register(
            nameof(BoolTemplate),
            typeof(ControlTemplate),
            typeof(FooControl),
            new PropertyMetadata(default(ControlTemplate)));

        public static readonly DependencyProperty ControlTemplateSelectorProperty = DependencyProperty.Register(
            nameof(ControlTemplateSelector),
            typeof(FooControlTemplateSelector),
            typeof(FooControl),
            new PropertyMetadata(default(FooControlTemplateSelector)));

        public PartControlTemplate StringTemplate
        {
            get { return (PartControlTemplate)this.GetValue(StringTemplateProperty); }
            set { this.SetValue(StringTemplateProperty, value); }
        }

        public ControlTemplate BoolTemplate
        {
            get { return (ControlTemplate)this.GetValue(BoolTemplateProperty); }
            set { this.SetValue(BoolTemplateProperty, value); }
        }

        public FooControlTemplateSelector ControlTemplateSelector
        {
            get { return (FooControlTemplateSelector)this.GetValue(ControlTemplateSelectorProperty); }
            set { this.SetValue(ControlTemplateSelectorProperty, value); }
        }
    }
}
