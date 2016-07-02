using System;
using System.IO;
using System.Linq;
using System.Xaml;
using System.Xml;
using System.Xml.Linq;

namespace PartTemplateBox.Tests
{
    using NUnit.Framework;

    public class UnitTest1
    {
        [Test]
        public void GetPartXaml()
        {
            var xaml =
                "<ControlTemplate TargetType=\"ptb:FooControl\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:ptb=\"clr-namespace:PartTemplateBox;assembly=PartTemplateBox\">\r\n" +
                "    <TextBox Text=\"{TemplateBinding FrameworkElement.ActualWidth}\" Name=\"PART_Foo\" />\r\n" +
                "</ControlTemplate>";
            var partXaml = PartControlTemplate.GetSinglePart(xaml, "PART_Foo");
            var expected = "<TextBox Text=\"{TemplateBinding FrameworkElement.ActualWidth}\" Name=\"PART_Foo\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" />";
            Assert.AreEqual(expected, partXaml);
        }

        [Test]
        public void GetPartXamlMissingName()
        {
            var xaml =
                "<ControlTemplate TargetType=\"ptb:FooControl\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:ptb=\"clr-namespace:PartTemplateBox;assembly=PartTemplateBox\">\r\n" +
                "    <TextBox Text=\"{TemplateBinding FrameworkElement.ActualWidth}\" />\r\n" +
                "</ControlTemplate>";
            var partXaml = PartControlTemplate.GetSinglePart(xaml, "PART_Foo");
            var expected = "<TextBox Text=\"{TemplateBinding FrameworkElement.ActualWidth}\" Name=\"PART_Foo\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" />";
            Assert.AreEqual(expected, partXaml);
        }

        [Test]
        public void ThrowsOnWrongName()
        {
            var xaml =
                "<ControlTemplate TargetType=\"ptb:FooControl\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:ptb=\"clr-namespace:PartTemplateBox;assembly=PartTemplateBox\">\r\n" +
                "    <TextBox Text=\"{TemplateBinding FrameworkElement.ActualWidth}\" Name=\"WRONG\"/>\r\n" +
                "</ControlTemplate>";
            var exception = Assert.Throws<XamlParseException>(() => PartControlTemplate.GetSinglePart(xaml, "PART_Foo"));
            string expected = "Expected name to be: 'PART_Foo' but was: 'WRONG'";
            Assert.AreEqual(expected, exception.Message);
        }
    }
}
