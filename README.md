# Caeno Xamarin.Forms Toolkit
The Caeno Toolkit for Xamarin.Forms projects contains extensions and utilities for the platform. This is a early release where we are merging patterns identified in most of our projects and it's subject of change without previous notice. You're welcome to contribute with the platform.

## Setup
* Available on NuGet https://www.nuget.org/packages/Caeno.XamarinForms.Toolkit/ [![NuGet](https://img.shields.io/nuget/v/Caeno.XamarinForms.Toolkit.svg?label=NuGet)](https://www.nuget.org/packages/Caeno.XamarinForms.Toolkit/)
* Install into your PCL project and client projects

## Components
The current version of this library is comprised of several components broken into few categories.

### Controls
A set of additional controls to be used with Xamarin.Forms:

* **CarouselIndicators**: to be used in conjunction with Xamarin.Forms [CarouselView](https://www.nuget.org/packages/Xamarin.Forms.CarouselView) to provide custom Indicators for current item.
* **CircularImage**: extends *Image* control with the content rendered as a circle. Includes additional properties to control Border Color and Width. (**Note**: This component is dependent on the Custom Renderers provided by the Shared Libraries to work).
* **EnhancedFrame**: a enhanced version of Frame Control with additional properties like BordeRadius and BorderWidth.
* **EnhancedPicker**: an enhanced version of Picker Control that allows binding to it's items source and selection.
* **EnhancedTabbedPage**: extends *TabbedPage* to provide additional customization of appearance in iOS. The current version allow setting the TabBar background color and Selected Item highlight color. (**Note**: This component is dependent on the Custom Renderers provided by the Shared Libraries to work).

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
	xmlns:toolkit="clr-namespace:Caeno.XamarinForms.Toolkit;assembly=Caeno.XamarinForms.Toolkit">
```

Then you can declare then as Resources in the *ResourceDictionary* of a page or of the preferred context you might need:

```xaml
<ContentPage.Resources>
	<ResourceDictionary>
		<toolkit:BoolNegationConverter x:Key="boolNegationConverter" />
		<toolkit:ImageResourceConverter x:Key="imageResourceConverter" />
		<toolkit:NullToValueConverter x:Key="nullToValueConverter" />
	</ResourceDictionary>
</ContentPage.Resources>
```

#### BoolNegationConverter
Negates the value of a Boolean Property (True to False and vice-versa).

```xaml
<Label 
	IsVisible="{Binding [Boolean Property], 
			    		Converter={StaticResource boolNegationConverter}" />
```

#### ImageResourceConverter
Allow images to be loaded from Assembly Resources in Binding expressions. Usage: 

```xaml
<Image
	Source="{Binding [Property with Resource],
			 		 Converter={StaticResource imageResourceConverter}}" />
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

### Pages
Additional useful page classes.

* **BaseAsyncActivityContentPage**: a base page that shows an Activity Indicator when a background activity is running.


### Utility Classes
A set of helper and utilitary classes that aids working with Xamarin.Forms, MVVM and other patterns natural to this platform.

* **ViewModelBase / AsyncViewModelBase**: those base for View Model classes are inspired by the Charles Petzold's eBook on Xamarin Forms and provides an easy way to implement observable properties. *AsyncViewModelBase* provides some additional properties for View Models that involves background processing.
* **EnhancedObservableCollection<T>**: derives from *ObservableCollection<T>* and provides additional useful methods:
  * AddRange(): allow adding an range of elements to the collection that will generate notifications only after insertion.
  * Reset(): allow reseting the contents of the collection with a new set of items.
* **GroupingObservableCollection<K, T>**: used for grouping items in a ListView.

## Support and Feedback
Currently there's no support available for this libraries but you're welcome to record Issues and Pull Requests over problems you may find. You can also contact us by email at: [dev@caeno.io](mailto:dev@caeno.io). This library is a major work in progress but is one that we are very dedicated so you're welcome to star this project, follow along and contribute.
