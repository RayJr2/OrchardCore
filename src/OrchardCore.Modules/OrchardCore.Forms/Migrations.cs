using System.ComponentModel;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace OrchardCore.Forms
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            // Form
            _contentDefinitionManager.AlterPartDefinition("FormPart", part => part
                .Attachable()
                .WithDescription("Turns your content item into a form."));

            _contentDefinitionManager.AlterTypeDefinition("Form", type => type
                .WithPart("TitlePart", part => part
                    .WithSettings(new TitlePartSettings { RenderTitle = false })
                    .WithPosition("0")
                )
                .WithPart("FormElementPart", part =>
                   part.WithPosition("1")
                )
                .WithPart("FormPart")
                .WithPart("FlowPart")
                .Stereotype("Widget"));

            // FormElement
            _contentDefinitionManager.AlterPartDefinition("FormElementPart", part => part
                .WithDescription("Provides attributes common to all form elements."));

            _contentDefinitionManager.AlterPartDefinition("FormElementLabelPart", part => part
                .Attachable()
                .WithDescription("Provides a way to capture element's label.")
            );

            _contentDefinitionManager.AlterPartDefinition("FormElementValidationPart", part => part
                .Attachable()
                .WithDescription("Provides validation options to form elements.")
            );

            // FormInputElement
            _contentDefinitionManager.AlterPartDefinition("FormInputElementPart", part => part
                .WithDescription("Provides attributes common to all input form elements."));

            // Label
            _contentDefinitionManager.AlterPartDefinition("LabelPart", part => part
                .WithDescription("Provides label properties."));

            _contentDefinitionManager.AlterTypeDefinition("Label", type => type
                .WithPart("TitlePart", part => part
                    .WithSettings(new TitlePartSettings { RenderTitle = false })
                )
                .WithPart("FormElementPart")
                .WithPart("LabelPart")
                .Stereotype("Widget"));

            // Input
            _contentDefinitionManager.AlterPartDefinition("InputPart", part => part
                .WithDescription("Provides input field properties."));

            _contentDefinitionManager.AlterTypeDefinition("Input", type => type
                .WithPart("FormInputElementPart", part => part
                    .WithPosition("1")
                )
                .WithPart("FormElementPart", part => part
                    .WithPosition("2")
                )
                .WithPart("FormElementLabelPart", part => part
                    .WithPosition("3")
                )
                .WithPart("InputPart", part => part
                    .WithPosition("4")
                )
                .WithPart("FormElementValidationPart", part => part
                    .WithPosition("5")
                )
                .Stereotype("Widget"));

            // TextArea
            _contentDefinitionManager.AlterPartDefinition("TextAreaPart", part => part
                .WithDescription("Provides text area properties."));

            _contentDefinitionManager.AlterTypeDefinition("TextArea", type => type
                .WithPart("FormInputElementPart", part => part
                    .WithPosition("1")
                )
                .WithPart("FormElementPart", part => part
                    .WithPosition("2")
                )
                .WithPart("FormElementLabelPart", part => part
                    .WithPosition("3")
                )
                .WithPart("TextAreaPart", part => part
                    .WithPosition("4")
                )
                .WithPart("FormElementValidationPart", part => part
                    .WithPosition("5")
                )
                .Stereotype("Widget"));

            // Select
            _contentDefinitionManager.AlterPartDefinition("SelectPart", part => part
                .WithDescription("Provides select field properties."));

            _contentDefinitionManager.AlterTypeDefinition("Select", type => type
                .WithPart("FormInputElementPart", part => part
                    .WithPosition("1")
                )
                .WithPart("FormElementPart", part => part
                    .WithPosition("2")
                )
                .WithPart("FormElementLabelPart", part => part
                    .WithPosition("3")
                )
                .WithPart("SelectPart", part => part
                    .WithPosition("4")
                )
                .WithPart("FormElementValidationPart", part => part
                    .WithPosition("5")
                )
                .Stereotype("Widget"));

            // Button
            _contentDefinitionManager.AlterPartDefinition("ButtonPart", part => part
                .WithDescription("Provides button properties."));

            _contentDefinitionManager.AlterTypeDefinition("Button", type => type
                .WithPart("FormInputElementPart")
                .WithPart("FormElementPart")
                .WithPart("ButtonPart")
                .Stereotype("Widget"));

            // Validation Summary
            _contentDefinitionManager.AlterPartDefinition("ValidationSummaryPart", part => part
                .WithDescription("Displays a validation summary."));

            _contentDefinitionManager.AlterTypeDefinition("ValidationSummary", type => type
                .WithPart("ValidationSummaryPart")
                .Stereotype("Widget"));

            // Validation
            _contentDefinitionManager.AlterPartDefinition("ValidationPart", part => part
                .WithDescription("Displays a field validation error."));

            _contentDefinitionManager.AlterTypeDefinition("Validation", type => type
                .WithPart("ValidationPart")
                .Stereotype("Widget"));

            // Shortcut other migration steps on new content definition schemas.
            return 4;
        }

        // This code can be removed in a later version.
        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinition("Form", type => type
                .WithPart("TitlePart", part => part.MergeSettings<TitlePartSettings>(setting => setting.RenderTitle = false))
            );

            _contentDefinitionManager.AlterTypeDefinition("Label", type => type
                .WithPart("TitlePart", part => part.MergeSettings<TitlePartSettings>(setting => setting.RenderTitle = false))
            );

            return 2;
        }

        // This code can be removed in a later version.
        public int UpdateFrom2()
        {
            _contentDefinitionManager.AlterTypeDefinition("Form", type => type
                .WithPart("TitlePart", part => part
                    .WithPosition("0")
                )
                .WithPart("FormElementPart", part =>
                   part.WithPosition("1")
                )
            );

            return 3;
        }

        // This code can be removed in a later version.
        public int UpdateFrom3()
        {
            _contentDefinitionManager.AlterPartDefinition("FormElementLabelPart", part => part
                .Attachable()
                .WithDescription("Provides a way to capture element's label.")
            );

            _contentDefinitionManager.AlterPartDefinition("FormElementValidationPart", part => part
                .Attachable()
                .WithDescription("Provides validation options to form elements.")
            );

            _contentDefinitionManager.AlterTypeDefinition("Select", type => type
                .WithPart("FormInputElementPart", part => part
                    .WithPosition("1")
                )
                .WithPart("FormElementPart", part => part
                    .WithPosition("2")
                )
                .WithPart("FormElementLabelPart", part => part
                    .WithPosition("3")
                )
                .WithPart("SelectPart", part => part
                    .WithPosition("4")
                )
                .WithPart("FormElementValidationPart", part => part
                    .WithPosition("5")
                )
            );

            _contentDefinitionManager.AlterTypeDefinition("Input", type => type
                .WithPart("FormInputElementPart", part => part
                    .WithPosition("1")
                )
                .WithPart("FormElementPart", part => part
                    .WithPosition("2")
                )
                .WithPart("FormElementLabelPart", part => part
                    .WithPosition("3")
                )
                .WithPart("InputPart", part => part
                    .WithPosition("4")
                )
                .WithPart("FormElementValidationPart", part => part
                    .WithPosition("5")
                )
            );

            _contentDefinitionManager.AlterTypeDefinition("TextArea", type => type
                .WithPart("FormInputElementPart", part => part
                    .WithPosition("1")
                )
                .WithPart("FormElementPart", part => part
                    .WithPosition("2")
                )
                .WithPart("FormElementLabelPart", part => part
                    .WithPosition("3")
                )
                .WithPart("TextAreaPart", part => part
                    .WithPosition("4")
                )
                .WithPart("FormElementValidationPart", part => part
                    .WithPosition("5")
                )
            );

            return 4;
        }

        internal class TitlePartSettings
        {
            public int Options { get; set; }

            public string Pattern { get; set; }

            [DefaultValue(true)]
            public bool RenderTitle { get; set; }
        }
    }
}
