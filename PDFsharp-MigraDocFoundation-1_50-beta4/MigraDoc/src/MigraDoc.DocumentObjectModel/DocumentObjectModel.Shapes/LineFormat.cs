#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Stefan Lange
//   Klaus Potzesny
//   David Stephensen
//
// Copyright (c) 2001-2016 empira Software GmbH, Cologne Area (Germany)
//
// http://www.pdfsharp.com
// http://www.migradoc.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using MigraDoc.DocumentObjectModel.Internals;

namespace MigraDoc.DocumentObjectModel.Shapes
{
    /// <summary>
    /// Defines the format of a line in a shape object.
    /// </summary>
    public class LineFormat : DocumentObject
    {
        /// <summary>
        /// Initializes a new instance of the LineFormat class.
        /// </summary>
        public LineFormat()
        { }

        /// <summary>
        /// Initializes a new instance of the Lineformat class with the specified parent.
        /// </summary>
        internal LineFormat(DocumentObject parent) : base(parent) { }

        #region Methods
        /// <summary>
        /// Creates a deep copy of this object.
        /// </summary>
        public new LineFormat Clone()
        {
            return (LineFormat)DeepCopy();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether the line should be visible.
        /// </summary>
        public bool Visible
        {
            get { return _visible.Value; }
            set { _visible.Value = value; }
        }
        [DV]
        internal NBool _visible = NBool.NullValue;

        /// <summary>
        /// Gets or sets the width of the line in Unit.
        /// </summary>
        public Unit Width
        {
            get { return _width; }
            set { _width = value; }
        }
        [DV]
        internal Unit _width = Unit.NullValue;

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        [DV]
        internal Color _color = Color.Empty;

        /// <summary>
        /// Gets or sets the dash style of the line.
        /// </summary>
        public DashStyle DashStyle
        {
            get { return (DashStyle)_dashStyle.Value; }
            set { _dashStyle.Value = (int)value; }
        }
        [DV(Type = typeof(DashStyle))]
        internal NEnum _dashStyle = NEnum.NullValue(typeof(DashStyle));

        /// <summary>
        /// Gets or sets the style of the line.
        /// </summary>
        public LineStyle Style
        {
            get { return (LineStyle)_style.Value; }
            set { _style.Value = (int)value; }
        }
        [DV(Type = typeof(LineStyle))]
        internal NEnum _style = NEnum.NullValue(typeof(LineStyle));
        #endregion

        #region Internal
        /// <summary>
        /// Converts LineFormat into DDL.
        /// </summary>
        internal override void Serialize(Serializer serializer)
        {
            int pos = serializer.BeginContent("LineFormat");
            if (!_visible.IsNull)
                serializer.WriteSimpleAttribute("Visible", Visible);
            if (!_style.IsNull)
                serializer.WriteSimpleAttribute("Style", Style);
            if (!_dashStyle.IsNull)
                serializer.WriteSimpleAttribute("DashStyle", DashStyle);
            if (!_width.IsNull)
                serializer.WriteSimpleAttribute("Width", Width);
            if (!_color.IsNull)
                serializer.WriteSimpleAttribute("Color", Color);
            serializer.EndContent();
        }

        /// <summary>
        /// Returns the meta object of this instance.
        /// </summary>
        internal override Meta Meta
        {
            get { return _meta ?? (_meta = new Meta(typeof(LineFormat))); }
        }
        static Meta _meta;
        #endregion
    }
}
