namespace PartTemplateBox
{
    using System.Windows.Controls;

    public class FooControlTemplateSelector : ControlTemplateSelector<FooControl>
    {
        public ControlTemplate StringTemplate { get; set; }

        public ControlTemplate BoolTemplate { get; set; }

        public override void UpdateCurrentTemplate(FooControl container)
        {
            throw new System.NotImplementedException();
        }
    }
}