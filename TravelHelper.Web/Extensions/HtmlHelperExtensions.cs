using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelHelper.Web.Models.Shared;

namespace TravelHelper.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent CheckBoxList<TValue>(
            this IHtmlHelper htmlHelper,
            IEnumerable<ListItem<TValue>> items,
            IEnumerable<TValue> selectedItems,
            string name,
            string containerId)
        {
            var ul = CreateContainer("ul");
            ul.Attributes.Add("id", containerId);
            selectedItems ??= new TValue [0];

            foreach (var rootItem in items)
            {
                var inputId = $"{name}{rootItem.Value}";
                var isChecked = selectedItems.Contains(rootItem.Value);

                var label = CreateLabel(rootItem.Key, inputId);
                var checkbox = CreateCheckbox(name, inputId, rootItem.Value.ToString(), isChecked);
                var li = CreateContainer("li", checkbox, label);

                ul.InnerHtml.AppendHtml(li);
            }

            var content = GetMarkup(ul);
            var markup = new HtmlString(content);

            return markup;
        }

        private static TagBuilder CreateContainer(string tagName = "div", params TagBuilder[] innerElements)
        {
            var container = new TagBuilder(tagName);
            container.AddCssClass("form-check");

            foreach (var innerElement in innerElements)
            {
                container.InnerHtml.AppendHtml(innerElement);
            }

            return container;
        }

        private static TagBuilder CreateCheckbox(string name, string id, string value, bool isChecked,
            string parentId = null)
        {
            var input = new TagBuilder("input");

            input.Attributes.Add("type", "checkbox");
            input.Attributes.Add("name", name);
            input.Attributes.Add("value", value);
            input.Attributes.Add("id", id);

            if (isChecked)
            {
                input.Attributes.Add("checked", string.Empty);
            }

            if (parentId != null)
            {
                input.Attributes.Add("data-parent-id", parentId);
            }

            input.AddCssClass("form-check-input");

            return input;
        }

        private static TagBuilder CreateLabel(string innerText, string @for)
        {
            var label = new TagBuilder("label");

            label.InnerHtml.Append(innerText);
            label.Attributes.Add("for", @for);
            label.AddCssClass("form-check-label");

            return label;
        }

        private static string GetMarkup(IHtmlContent parent)
        {
            using var writer = new StringWriter();
            parent.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}
