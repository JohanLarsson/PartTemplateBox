namespace PartTemplateBox
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;

    public class FooControlTemplateSelector : ControlTemplateSelector<FooControl>, IList
    {
        private readonly List<ControlTemplate> templates = new List<ControlTemplate>();

        public override ControlTemplate Current
        {
            get { return base.Current ?? this.templates.FirstOrDefault(); }
            protected set { base.Current = value; }
        }

        public int Count => this.templates.Count;

        object ICollection.SyncRoot => ((ICollection)this.templates).SyncRoot;

        public bool IsSynchronized => ((ICollection)this.templates).IsSynchronized;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public object this[int index]
        {
            get { return ((IList)this.templates)[index]; }
            set { ((IList)this.templates)[index] = value; }
        }

        public override void UpdateCurrentTemplate(FooControl container)
        {
            if (this.Current == this.templates[0])
            {
                this.Current = this.templates[1];
            }
            else
            {
                this.Current = this.templates[0];
            }
        }

        public IEnumerator GetEnumerator() => this.templates.GetEnumerator();

        void ICollection.CopyTo(Array array, int index) => ((IList)this.templates).CopyTo(array, index);

        public int Add(object value) => ((IList)this.templates).Add(value);

        public bool Contains(object value) => ((IList)this.templates).Contains(value);

        public void Clear() => ((IList)this.templates).Clear();

        public int IndexOf(object value) => ((IList)this.templates).IndexOf(value);

        public void Insert(int index, object value) => ((IList)this.templates).Insert(index, value);

        public void Remove(object value) => ((IList)this.templates).Remove(value);

        public void RemoveAt(int index) => ((IList)this.templates).RemoveAt(index);
    }
}