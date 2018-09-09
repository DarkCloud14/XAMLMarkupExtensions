namespace TestWPF
{
    using XAMLMarkupExtensions.Base;
    using System.Windows.Media;

    public class AddAlphaExtension : NestedMarkupExtension
    {
        public byte Alpha { get; set; }
        public SolidColorBrush Brush { get; set; }
        public SolidColorBrush SecondBrush { get; set; }

        public override object FormatOutput(TargetInfo endPoint, TargetInfo info)
        {
            // Check the correct type.
            if (!typeof(Brush).IsAssignableFrom(info.TargetPropertyType))
                return null;

            if (Brush == null && SecondBrush == null)
                return null;

            var color = SecondBrush?.Color ?? Brush.Color;
            color.A = Alpha;

            return new SolidColorBrush(color);
        }

        protected override bool UpdateOnEndpoint(TargetInfo endpoint)
        {
            return false;
        }

        public AddAlphaExtension()
        {
        }
    }
}
