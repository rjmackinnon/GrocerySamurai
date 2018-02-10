namespace MagicHamster.GrocerySamurai.PresentationLayer.Helpers
{
    using JetBrains.Annotations;

    [UsedImplicitly]
    public static class RequiredLabel
    {
        /*
        public static IHtmlContent RequiredLabelFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes, bool forceRequired = false)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metaData.DisplayName ?? metaData.PropertyName ?? htmlFieldName.Split('.').Last();

            if (metaData.IsRequired || forceRequired)
                labelText += "<span class=\"required\">*</span>";

            if (String.IsNullOrEmpty(labelText))
                return HtmlContent.Empty;

            var label = new TagBuilder("label");
            label.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(htmlAttributes))
            {
                label.MergeAttribute(prop.Name.Replace('_', '-'), prop.GetValue(htmlAttributes)?.ToString(), true);
            }

            label.InnerHtml = labelText;
            return IHtmlContent.Create(label.ToString());
        }
        */
    }
}