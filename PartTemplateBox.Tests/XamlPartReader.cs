using System;
using System.Xaml;

namespace PartTemplateBox.Tests
{
    internal static class XamlPartReader
    {
        internal static string SinglePart(string xaml, string partName)
        {
            const string controltemplate = "ControlTemplate";
            int position = 0;
            SkipStartElement(xaml, controltemplate, ref position);
            SkipWhiteSpace(xaml, ref position);
            var startPos = position;
            //SkipSubTree(xaml, ref position);
            var endPos = position;
            SkipEndElement(xaml, controltemplate, ref position);
            SkipWhiteSpace(xaml, ref position);
            if (position != xaml.Length - 1)
            {
                throw new XamlParseException();
            }

            throw new NotImplementedException();
            //return xaml.Slice(startPos, endPos);
        }

        private static void SkipEndElement(string xaml, string elementName, ref int position)
        {
            SkipWhiteSpace(xaml, ref position);
            SkipChar(xaml, '<', ref position);
            SkipChar(xaml, '/', ref position);
            SkipWord(xaml, elementName, ref position);
            SkipChar(xaml, '>', ref position);
        }

        internal static void SkipStartElement(string xaml, string elementName, ref int position)
        {
            SkipChar(xaml,'<', ref position);
            SkipWord(xaml, elementName, ref position);
            SkipTo(xaml, '>', ref position);
            position++;
            SkipWhiteSpace(xaml, ref position);
        }

        private static void SkipChar(string xaml, char c, ref int position)
        {
            if (xaml[position] != c)
            {
                throw new XamlException($"Expected '<' at position {position} in {xaml}");
            }

            position++;
        }

        private static void SkipTo(string xaml, char c, ref int position)
        {
            while (xaml[position] != c)
            {
                position++;
            }
        }

        internal static void SkipWhiteSpace(string xaml, ref int position)
        {
            while (position < xaml.Length)
            {
                if (char.IsWhiteSpace(xaml[position]))
                {
                    position++;
                }
            }
        }

        internal static void SkipWord(string xaml, string word, ref int position)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (xaml[position + i] != word[i])
                {
                    throw new XamlException();
                }
            }

            position += word.Length;
        }
    }
}