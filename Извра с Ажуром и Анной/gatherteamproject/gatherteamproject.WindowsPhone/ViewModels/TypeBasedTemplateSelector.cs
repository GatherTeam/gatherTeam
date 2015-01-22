namespace gatherteamproject.ViewModels
{

    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Markup;

    [ContentProperty(Name = "Templates")]
    class TypeBasedTemplateSelector : DataTemplateSelector
    {
         private readonly Dictionary<string, DataTemplate> _templates =
            new Dictionary<string, DataTemplate>();

        /// <summary>
        /// Gets a dictionary in which templates can be associated with type names.
        /// </summary>
        /// <summary>
        /// For each item, this selector will look for an entry in this dictionary
        /// in which the key matches the name of the item type.
        /// </summary>
        public Dictionary<string, DataTemplate> Templates
        {
            get { return _templates; }
        }

        /// <summary>
        /// Gets or sets the data template to use for items whose types do not match
        /// any of the type names in the <see cref="Templates"/> dictionary.
        /// </summary>
        public DataTemplate DefaultTemplate { get; set; }

        /// <inheritdoc/>
        protected override DataTemplate SelectTemplateCore(object item)
        {
            DataTemplate template;
            if (item == null || !Templates.TryGetValue(item.GetType().Name, out template))
            {
                template = DefaultTemplate;
            }

            return template;
        }
    }
}
