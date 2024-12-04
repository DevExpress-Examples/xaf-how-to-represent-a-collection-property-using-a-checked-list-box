<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592642/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1807)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# XAF - How to display a collection property as a checked list box

This example illustrates how to display a [collection property](https://docs.devexpress.com/eXpressAppFramework/113568/business-model-design-orm/data-types-supported-by-built-in-editors/collection-properties) as a checked list box in XAF applications.

![image](https://user-images.githubusercontent.com/14300209/229557843-6b3586a5-319f-45a2-b4aa-37935dda28ed.png)

The example application:

* Shows the collection of all existing `Detail` objects as a checked list box.
* Allows you to link/unlink child `Detail` records to/from the `Master` object using checkboxes.

## Implementation Details

1. Implement [Master](./CS/EFCore/CheckedListEF/CheckedListEF.Module/BusinessObjects/Master.cs) and [Detail](./CS/EFCore/CheckedListEF/CheckedListEF.Module/BusinessObjects/Detail.cs) business object classes, where `Master` contains a collection of `Detail` objects.
2. Copy the implementation of one of the following [custom property editors](https://docs.devexpress.com/eXpressAppFramework/113097/ui-construction/view-items-and-property-editors/property-editors#custom-property-editors):

    * For Blazor applications, use [CheckedListBoxEditor](./CS/EFCore/CheckedListEF/CheckedListEF.Blazor.Server/Editors/CheckedListBoxEditor).
    * For Windows Forms applications, use [WinCheckedListBoxPropertyEditor.cs](./CS/EFCore/CheckedListEF/CheckedListEF.Win/Editors/WinCheckedListBoxPropertyEditor.cs).
3. Run the application.
4. Create several `Detail` objects, then create a new `Master` object. You can link/unlink existing `Detail` objects using editor checkboxes.

## Files to Review

* Blazor - [CheckedListBoxEditor](./CS/EFCore/CheckedListEF/CheckedListEF.Blazor.Server/Editors/CheckedListBoxEditor/)
* Windows Forms - [WinCheckedListBoxPropertyEditor.cs](./CS/EFCore/CheckedListEF/CheckedListEF.Win/Editors/WinCheckedListBoxPropertyEditor.cs) 

## Documentation

* [Collection Properties](https://docs.devexpress.com/eXpressAppFramework/113568/business-model-design-orm/data-types-supported-by-built-in-editors/collection-properties)
* [Property Editors](https://docs.devexpress.com/eXpressAppFramework/113097/ui-construction/view-items-and-property-editors/property-editors)

## More Examples

* [XAF Blazor - How to use a TagBox to view and edit a collection property in Detail Views](https://github.com/DevExpress-Examples/XAF-Blazor-How-to-use-a-TagBox-to-view-and-edit-a-collection-property-in-Detail-Views)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-display-a-collection-property-as-a-checked-list-box&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-display-a-collection-property-as-a-checked-list-box&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
