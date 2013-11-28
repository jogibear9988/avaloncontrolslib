using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace AC.AvalonControlsLibrary.Controls
{
    /// <summary>
    /// Contains attached properties to enable a Prompt
    /// </summary>
    public class InputPrompt : DependencyObject
    {
        #region Attached Properties

        /// <summary>
        /// Gets the Prompt font stretch
        /// </summary>
        /// <param name="obj">The object to get the value from</param>
        /// <returns>The font stretch set</returns>
        public static FontStretch GetPromptFontStretch(DependencyObject obj)
        {
            return (FontStretch)obj.GetValue(PromptFontStretchProperty);
        }

        /// <summary>
        /// Sets the Prompt font stretch
        /// </summary>
        /// <param name="obj">The element to set the font weight to</param>
        /// <param name="value">The font stretch to set</param>
        public static void SetPromptFontStretch(DependencyObject obj, FontStretch value)
        {
            obj.SetValue(PromptFontStretchProperty, value);
        }

        /// <summary>
        /// Gets or sets the font stretch for the prompt
        /// </summary>
        public static readonly DependencyProperty PromptFontStretchProperty =
            DependencyProperty.RegisterAttached("PromptFontStretch", typeof(FontStretch), typeof(InputPrompt),
            new UIPropertyMetadata(FontStretches.Normal));

        /// <summary>
        /// Gets the Prompt font weight
        /// </summary>
        /// <param name="obj">The object to get the value from</param>
        /// <returns>The font weight set</returns>
        public static FontWeight GetPromptFontWeight(DependencyObject obj)
        {
            return (FontWeight)obj.GetValue(PromptFontWeightProperty);
        }

        /// <summary>
        /// Sets the Prompt font weight
        /// </summary>
        /// <param name="obj">The element to set the font weight to</param>
        /// <param name="value">The font weight to set</param>
        public static void SetPromptFontWeight(DependencyObject obj, FontWeight value)
        {
            obj.SetValue(PromptFontWeightProperty, value);
        }

        /// <summary>
        /// Gets or sets the font weight for the prompt
        /// </summary>
        public static readonly DependencyProperty PromptFontWeightProperty =
            DependencyProperty.RegisterAttached("PromptFontWeight", typeof(FontWeight), typeof(InputPrompt),
            new UIPropertyMetadata(FontWeights.Normal));

        /// <summary>
        /// Gets the Prompt font style
        /// </summary>
        /// <param name="obj">The object to get the value from</param>
        /// <returns>The font style set</returns>
        public static FontStyle GetPromptFontStyle(DependencyObject obj)
        {
            return (FontStyle)obj.GetValue(PromptFontStyleProperty);
        }

        /// <summary>
        /// Sets the Prompt font style
        /// </summary>
        /// <param name="obj">The element to set the font style to</param>
        /// <param name="value">The font style to set</param>
        public static void SetPromptFontStyle(DependencyObject obj, FontStyle value)
        {
            obj.SetValue(PromptFontStyleProperty, value);
        }

        /// <summary>
        /// Gets or sets the font style for the prompt
        /// </summary>
        public static readonly DependencyProperty PromptFontStyleProperty =
            DependencyProperty.RegisterAttached("PromptFontStyle", typeof(FontStyle), typeof(InputPrompt),
            new UIPropertyMetadata(FontStyles.Normal));

        /// <summary>
        /// Gets the Prompt font family
        /// </summary>
        /// <param name="obj">The object to get the value from</param>
        /// <returns>The font family set</returns>
        public static FontFamily GetPromptFontFamily(DependencyObject obj)
        {
            return (FontFamily)obj.GetValue(PromptFontFamilyProperty);
        }

        /// <summary>
        /// Sets the Prompt font family
        /// </summary>
        /// <param name="obj">The element to set the font family to</param>
        /// <param name="value">The font family to set</param>
        public static void SetPromptFontFamily(DependencyObject obj, FontFamily value)
        {
            obj.SetValue(PromptFontFamilyProperty, value);
        }

        /// <summary>
        /// Gets or sets the font family for the prompt
        /// </summary>
        public static readonly DependencyProperty PromptFontFamilyProperty =
            DependencyProperty.RegisterAttached("PromptFontFamily", typeof(FontFamily), typeof(InputPrompt),
            new UIPropertyMetadata(new FontFamily("Arial")));


        /// <summary>
        /// Gets the Prompt font size
        /// </summary>
        /// <param name="obj">The element to get the value from</param>
        /// <returns>The font size of the prompt</returns>
        public static double GetPromptFontSize(DependencyObject obj)
        {
            return (double)obj.GetValue(PromptFontSizeProperty);
        }

        /// <summary>
        /// Sets the Prompt font size
        /// </summary>
        /// <param name="obj">The object to set the value to</param>
        /// <param name="value">The font size to set</param>
        public static void SetPromptFontSize(DependencyObject obj, double value)
        {
            obj.SetValue(PromptFontSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the Prompt font size
        /// </summary>
        public static readonly DependencyProperty PromptFontSizeProperty =
            DependencyProperty.RegisterAttached("PromptFontSize", typeof(double), typeof(InputPrompt), new UIPropertyMetadata(12.0));


        /// <summary>
        /// Gets the Prompt color
        /// </summary>
        /// <param name="obj">The element to get the prompt color from</param>
        /// <returns>Returns the color for the prompt</returns>
        public static Brush GetPromptColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PromptColorProperty);
        }

        /// <summary>
        /// Sets the prompt color for an element
        /// </summary>
        /// <param name="obj">The element to set the color for</param>
        /// <param name="value">The color to set</param>
        public static void SetPromptColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(PromptColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the Prompt Color
        /// </summary>
        public static readonly DependencyProperty PromptColorProperty =
            DependencyProperty.RegisterAttached("PromptColor", typeof(Brush), typeof(InputPrompt),
            new UIPropertyMetadata(Brushes.Gray));


        /// <summary>
        /// Gets the Prompt Back Color from a specific element
        /// </summary>
        /// <param name="obj">The element to get the prompt from</param>
        /// <returns>The back color used for prompt</returns>
        public static Brush GetPromptBackColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PromptBackColorProperty);
        }

        /// <summary>
        /// Sets the prompt back color for the specific element
        /// </summary>
        /// <param name="obj">The element to set the back color</param>
        /// <param name="value">The color for the prompt background</param>
        public static void SetPromptBackColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(PromptBackColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the Prompt back color for the UIElement
        /// </summary>
        public static readonly DependencyProperty PromptBackColorProperty =
            DependencyProperty.RegisterAttached("PromptBackColor", typeof(Brush), typeof(InputPrompt),
            new UIPropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Gets the Input Prompt from a specific element
        /// </summary>
        /// <param name="obj">The element to get the prompt from</param>
        /// <returns>The text used as prompt</returns>
        public static string GetPromptText(DependencyObject obj)
        {
            return (string)obj.GetValue(PromptTextProperty);
        }

        /// <summary>
        /// Sets the input prompt for the specific element
        /// </summary>
        /// <param name="obj">The element to set the input prompt</param>
        /// <param name="value">The text for the prompt</param>
        public static void SetPromptText(DependencyObject obj, string value)
        {
            obj.SetValue(PromptTextProperty, value);
        }

        /// <summary>
        /// Gets or sets the InputPrompt for the UIElement
        /// </summary>
        public static readonly DependencyProperty PromptTextProperty =
            DependencyProperty.RegisterAttached("PromptText", typeof(string), typeof(InputPrompt), new UIPropertyMetadata("",
                PromptTextChanged));


        /// <summary>
        /// gets the prompt adorner
        /// </summary>
        /// <param name="obj">The element to set</param>
        /// <returns>The prompt adorner</returns>
        internal static PromptAdorner GetPromptAdorner(DependencyObject obj)
        {
            return (PromptAdorner)obj.GetValue(PromptAdornerProperty);
        }

        /// <summary>
        /// Sets the prompt adorner
        /// </summary>
        /// <param name="obj">The element to set the adorner to</param>
        /// <param name="value">The adorner to set</param>
        internal static void SetPromptAdorner(DependencyObject obj, PromptAdorner value)
        {
            obj.SetValue(PromptAdornerProperty, value);
        }

        /// <summary>
        /// Gets or sets the Prompt Adorner
        /// </summary>
        internal static readonly DependencyProperty PromptAdornerProperty =
            DependencyProperty.RegisterAttached("PromptAdorner", typeof(PromptAdorner), typeof(InputPrompt),
            new UIPropertyMetadata(null));



        #endregion

        #region Property Event Handlers
        //Event handler for the Input Prompt text
        private static void PromptTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element != null)
            {
                AddPromptAdorner(element, e.NewValue.ToString());

                //handle the textbox text changed so that if no text is entered the prompt re appears
                TextBox textBox = element as TextBox;
                if (textBox != null)
                {
                    textBox.TextChanged += delegate(object textBoxSender, TextChangedEventArgs args)
                    {
                        //when the text is empty show the prompt
                        TextBox textSender = (TextBox)textBoxSender;
                        if (String.IsNullOrEmpty(textSender.Text))
                        {
                            AddPromptAdorner(textSender, e.NewValue.ToString());
                        }
                    };

                    //if the textbox looses focus re enable the prompt
                    textBox.LostFocus += delegate(object textBoxSender, RoutedEventArgs args)
                    {
                        TextBox textSender = (TextBox)textBoxSender;
                        if (String.IsNullOrEmpty(textSender.Text))
                        {
                            AddPromptAdorner(textSender, e.NewValue.ToString());
                        }
                    };
                }
            }
        }
        #endregion

        #region Helpers

        //helper method to add the prompt
        private static void AddPromptAdorner(UIElement element, string text)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(element);
            if (layer != null)
            {
                //try to get the prompt adorner and if it is not there create it
                PromptAdorner adorner = GetPromptAdorner(element);
                if (adorner == null)
                {
                    adorner = new PromptAdorner(element, text);
                    SetPromptAdorner(element, adorner);
                }
                else
                {
                    adorner.ShowAdorner();
                }

                //if the adorner is not already there add it
                Adorner[] adorners = layer.GetAdorners(element);
                if (adorners == null)
                    layer.Add(adorner);
                else if (!adorners.Contains(adorner))
                    layer.Add(adorner);
            }
        }

        #endregion
    }

    /// <summary>
    /// Prompt adorner to show the prompt text
    /// </summary>
    internal class PromptAdorner : Adorner
    {
        string promptText;
        static Pen backPen = new Pen(Brushes.Transparent, 0);
        static Point startPoint = new Point(0, 0);

        /// <summary>
        /// Constructor for the Adorner
        /// </summary>
        /// <param name="element">The element to adorn</param>
        /// <param name="text">The text to set as prompt</param>
        public PromptAdorner(UIElement element, string text)
            : base(element)
        {
            promptText = text;
            //Disbaled the adorned element so that no input can be set
            EnableDisableElement(element, true);
        }

        /// <summary>
        /// Makes sure that the adorner is ready to be shown
        /// </summary>
        public void ShowAdorner()
        {
            //Disbaled the adorned element so that no input can be set
            EnableDisableElement(AdornedElement, true);
        }

        /// <summary>
        /// Paints the Prompt Text
        /// </summary>
        /// <param name="drawingContext">The drawing context where to paint</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            FormattedText text = new FormattedText(promptText,
                Application.Current.Dispatcher.Thread.CurrentUICulture,
                FlowDirection.LeftToRight,
                new Typeface(
                    InputPrompt.GetPromptFontFamily(AdornedElement),
                    InputPrompt.GetPromptFontStyle(AdornedElement),
                    InputPrompt.GetPromptFontWeight(AdornedElement),
                    InputPrompt.GetPromptFontStretch(AdornedElement)
                    ),
                InputPrompt.GetPromptFontSize(AdornedElement),
                InputPrompt.GetPromptColor(AdornedElement));

            drawingContext.DrawRectangle(
                InputPrompt.GetPromptBackColor(AdornedElement)
                , backPen,
                new Rect(AdornedElement.RenderSize));

            drawingContext.DrawText(text, startPoint);
        }

        /// <summary>
        /// handle the mouse down so that the Prompt is disabled
        /// </summary>
        /// <param name="e">Event args</param>
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(AdornedElement);
            if (layer != null)
            {
                layer.Remove(this);
                EnableDisableElement(AdornedElement, false);
                AdornedElement.Focus();
            }
            base.OnMouseDown(e);
        }

        //Helper method to enable or disable the adorned element
        private static void EnableDisableElement(UIElement element, bool block)
        {
            TextBox textBox = element as TextBox;
            if (textBox != null)
                textBox.IsReadOnly = block;
        }
    }
}
