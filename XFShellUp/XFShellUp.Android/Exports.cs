using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace XFShellUp.Droid
{
    public static class Exports
	{
		public static readonly HandlerAttribute[] Handlers = new HandlerAttribute[]
		{
			new ExportRendererAttribute(typeof(BoxView), typeof(BoxRenderer)),
			new ExportRendererAttribute(typeof(CheckBox), typeof(CheckBoxRenderer)),
            new ExportRendererAttribute(typeof(Entry), typeof(EntryRenderer)),
			new ExportRendererAttribute(typeof(Label), typeof(LabelRenderer)),
			new ExportRendererAttribute(typeof(Image), typeof(ImageRenderer)),
			new ExportRendererAttribute(typeof(Button), typeof(ButtonRenderer)),
			new ExportRendererAttribute(typeof(ImageButton), typeof(ImageButtonRenderer)),
			new ExportRendererAttribute(typeof(TableView), typeof(TableViewRenderer)),
			new ExportRendererAttribute(typeof(ListView), typeof(ListViewRenderer)),
			new ExportRendererAttribute(typeof(CollectionView), typeof(CollectionViewRenderer)),
			new ExportRendererAttribute(typeof(CarouselView), typeof(CarouselViewRenderer)),
			new ExportRendererAttribute(typeof(Slider), typeof(SliderRenderer)),
			new ExportRendererAttribute(typeof(WebView), typeof(WebViewRenderer)),
			new ExportRendererAttribute(typeof(SearchBar), typeof(SearchBarRenderer)),
			new ExportRendererAttribute(typeof(Switch), typeof(SwitchRenderer)),
			new ExportRendererAttribute(typeof(DatePicker), typeof(DatePickerRenderer)),
			new ExportRendererAttribute(typeof(TimePicker), typeof(TimePickerRenderer)),
			new ExportRendererAttribute(typeof(Picker), typeof(PickerRenderer)),
			new ExportRendererAttribute(typeof(Stepper), typeof(StepperRenderer)),
			new ExportRendererAttribute(typeof(ProgressBar), typeof(ProgressBarRenderer)),
			new ExportRendererAttribute(typeof(ScrollView), typeof(ScrollViewRenderer)),
			new ExportRendererAttribute(typeof(ActivityIndicator), typeof(ActivityIndicatorRenderer)),
			new ExportRendererAttribute(typeof(Frame), typeof(FrameRenderer)),
			//new ExportRendererAttribute(typeof(OpenGLView), typeof(OpenGLViewRenderer)),

			new ExportRendererAttribute(typeof(TabbedPage), typeof(TabbedRenderer)),
			new ExportRendererAttribute(typeof(NavigationPage), typeof(NavigationRenderer)),
			new ExportRendererAttribute(typeof(CarouselPage), typeof(CarouselPageRenderer)),
			new ExportRendererAttribute(typeof(Page), typeof(PageRenderer)),
			new ExportRendererAttribute(typeof(MasterDetailPage), typeof(MasterDetailRenderer)),

			new ExportRendererAttribute(typeof(Shell), typeof(ShellRenderer)),
			new ExportRendererAttribute(typeof(NativeViewWrapper), typeof(NativeViewWrapperRenderer)),

			new ExportCellAttribute(typeof(Cell), typeof(CellRenderer)),
			new ExportCellAttribute(typeof(EntryCell), typeof(EntryCellRenderer)),
			new ExportCellAttribute(typeof(SwitchCell), typeof(SwitchCellRenderer)),
			new ExportCellAttribute(typeof(TextCell), typeof(TextCellRenderer)),
			new ExportCellAttribute(typeof(ImageCell), typeof(ImageCellRenderer)),
			new ExportCellAttribute(typeof(ViewCell), typeof(ViewCellRenderer)),

			new ExportImageSourceHandlerAttribute(typeof(FileImageSource), typeof(FileImageSourceHandler)),
			new ExportImageSourceHandlerAttribute(typeof(StreamImageSource), typeof(StreamImagesourceHandler)),
			new ExportImageSourceHandlerAttribute(typeof(UriImageSource), typeof(ImageLoaderSourceHandler)),
			new ExportImageSourceHandlerAttribute(typeof(FontImageSource), typeof(FontImageSourceHandler)),
		};
	}
}