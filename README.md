# Caeno Xamarin.Forms Toolkit
The caeno Toolkit for Xamarin.Forms projects contains extensions and utilities for the platform. This is a very early release where we are merging patterns identified in most of our projects and it's subject of change without previous notice. You're welcome to contribute with the platform.

## Project Structure
Actually this Toolkit is broken in three libraries:

1. **Caeno.XamarinForms.Toolkit**: this a PCL (Profile111) library that contains custom Controls, MarkupExtensions and ValueConverters to be used by Xamarin.Forms projects. Some custom controls are powered by Renderers that is contained in the Shared Projects of each platform.
2. **Caeno.XamarinForms.Toolkit.Android**: this is a Shared project aimed to be referenced by Xamarin.Android Forms projects that uses the Toolkit components as it contains the custom renderers for most of Pages and Views.
3. **Caeno.XamarinForms.Toolkit.iOS**: this is a Shared project aimed to be referenced by Xamarin.iOS Forms projects that uses the Toolkit components as it contains the custom renderers for most of Pages and Views.

>**Note**: Neither Xamarin Studio or Visual Studio enforces compatibility of Shared Projects so be sure to reference each one with the right Project type.

Future versions are planned to migrate Native implementations to specific libraries.

## Installation
This early codebase doesn't provide NuGet distribution which will come after it's more stable. You should clone this repository, submodule or subtree in your project.

## Components
The current version of this library is comprised of several components broken into few categories.

### Controls
A set of additional controls to be used with Xamarin.Forms:

* *CircularImage*: extends *Image* control with the content rendered as a circle. Includes additional properties to control Border Color and Width. (**Note**: This component is dependent on the Custom Renderers provided by the Shared Libraries to work).
* *SuperTabbedPage*: extends *TabbedPage* to provide additional customization of appearance in iOS. The current version allow setting the TabBar background color and Selected Item highlight color. (**Note**: This component is dependent on the Custom Renderers provided by the Shared Libraries to work).

### Markup Extensions
Allows extending the XAML with custom processing of Attributes:

* *ImageResourceExtension*: allow images to be loaded from Assembly Resources in Markup. Additional setup is required. Follow the instructions along:

First you need to reference the Toolkit namespace on the XAML that will use the component:
```xaml
<ContentPage
	xmlns="http://xamarin.com/schemas/2014/forms"
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
	x:Class="[PageClass]"
	xmlns:toolkit="clr-namespace:Caeno.Xamarin.FormsToolkit;assembly=Caeno.Xamarin.FormsToolkit">
```

Then you use the Markup extensions directly in the *Source* Property of an Image element:

```xaml
<Image
	Source="{toolkit:ImageResource ResourceName}">
```

Since resources are loaded by default from the Assembly where the extension was created, you need to configure *ImageResourceExtension* to load information from the correct assembly. We suggest you to do that in the App Constructor, as sampled by the following Snippet:

```csharp
// Setup the SourceAssembly where ImageResourceExtension will load resources from
var currentAssembly = typeof(App).GetTypeInfo().Assembly;
ImageResourceExtension.SourceAssembly = currentAssembly;
```

### Value Converters
Value converters aids XAML Data Binding with automatic conversion of model values to expected View property types.

To use the value converters first you need to reference the Toolkit namespace on the XAML that will use the component:
```xaml
<ContentPage
	xmlns="http://xamarin.com/schemas/2014/forms"
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
	x:Class="[PageClass]"
	xmlns:toolkit="clr-namespace:Caeno.Xamarin.FormsToolkit;assembly=Caeno.Xamarin.FormsToolkit">
```

Then you can declare then as Resources in the *ResourceDictionary* of a page or of the preferred context you might need:

```xaml
<ContentPage.Resources>
	<ResourceDictionary>
		<toolkit:ImageResourceConverter x:Key="imageResourceConverter" />
		<toolkit:NullToValueConverter x:Key="nullToValueConverter" />
	</ResourceDictionary>
</ContentPage.Resources>
```


#### ImageResourceConverter
Allow images to be loaded from Assembly Resources in Binding expressions. Usage: 

```xaml
<Image
	Source="{Binding [Property with Resource],Converter={StaticResource imageResource}}" />
```

Additional setup is required, since resources are loaded by default from the Assembly where the extension was created, you need to configure *ImageResourceExtension* to load information from the correct assembly. We suggest you to do that in the App Constructor, as sampled by the following Snippet:

```csharp
// Setup the SourceAssembly where ImageResourceExtension will load resources from
var currentAssembly = typeof(App).GetTypeInfo().Assembly;
ImageResourceConverter.SourceAssembly = currentAssembly;
```

#### NullToValueConverter
Returns an Optional value when the binded value is null. Usage:

```xaml
<Label
	Text="{Binding [PropertyName],
				   Converter={StaticResource nullToValueConverter},
				   ConverterParameter='Optional Text Value That you want to be passed when null'}}" />
```


### Utility Classes
A set of helper and utilitary classes that aids working with Xamarin.Forms, MVVM and other patterns natural to this platform.

* *ViewModelBase / AsyncViewModelBase*: those base for View Model classes are inspired by the Charles Petzold's eBook on Xamarin Forms and provides an easy way to implement observable properties. *AsyncViewModelBase* provides some additional properties for View Models that involves background processing.
* *EnhancedObservableCollection<T>*: derives from *ObservableCollection<T>* and provides additional useful methods:
  * AddRange(): allow adding an range of elements to the collection that will generate notifications only after insertion.
  * Reset(): allow reseting the contents of the collection with a new set of items.

## Support and Feedback
Currently there's no support available for this libraries but you're welcome to record Issues and Pull Requests over problems you may find. You can also contact us by email at: [dev@caeno.io](mailto:dev@caeno.io). This library is a major work in progress but is one that we are very dedicated so you're welcome to star this project, follow along and contribute.
