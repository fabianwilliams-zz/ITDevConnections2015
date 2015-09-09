using System;
using Xamarin.Forms;

namespace fgwdevcone
{
	public class CustomerCell: ViewCell
	{
		public CustomerCell ()
		{
			var ContactNameLabel = new Label {

				Font = Font.SystemFontOfSize (NamedSize.Medium)
			};
			ContactNameLabel.SetBinding (Label.TextProperty, new Binding ("ContactName"));
			//ContactNameLabel.SetBinding (Label.TextProperty, new Binding ("EvaluatedServer"));

			var ContactTitleLabel = new Label {
				Font = Font.SystemFontOfSize (NamedSize.Medium),
				XAlign = TextAlignment.End,
				HorizontalOptions = LayoutOptions.FillAndExpand

			};
			ContactTitleLabel.SetBinding (Label.TextProperty, new Binding ("ContactTitle"));
			//ContactTitleLabel.SetBinding (Label.TextProperty, new Binding ("EvaluationDateTime"));

			View = new StackLayout {
				Children = {ContactNameLabel, ContactTitleLabel},
				Orientation = StackOrientation.Horizontal

			};
		}
	}
}

