namespace PartTemplateBox
{
    using System.ComponentModel;
    using System.Windows.Controls;

    public abstract class ControlTemplateSelector<T> : INotifyPropertyChanged
        where T : Control
    {
        private ControlTemplate current;

        public event PropertyChangedEventHandler PropertyChanged;

        public ControlTemplate Current
        {
            get
            {
                return this.current;
            }
            private set
            {
                if (value == this.current)
                {
                    return;
                }

                this.current = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Current)));
            }
        }

        public abstract void UpdateCurrentTemplate(T container);
    }
}
