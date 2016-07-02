namespace PartTemplateBox
{
    using System.Windows.Controls;

    public class FooControlTemplateSelector : ControlTemplateSelector<FooControl>
    {
        public ControlTemplate StringTemplate { get; set; }

        public ControlTemplate BoolTemplate { get; set; }

        public override void UpdateCurrentTemplate(FooControl container)
        {
            if (this.Current == this.StringTemplate)
            {
                this.Current = this.BoolTemplate;
            }
            else
            {
                this.Current = this.StringTemplate;
            }
        }
    }
}